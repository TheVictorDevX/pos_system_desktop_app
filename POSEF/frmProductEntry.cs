using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSEF
{
    public partial class frmProductEntry : Form
    {
        private POSEntities db = new POSEntities();

        public frmProductEntry()
        {
            InitializeComponent();
        }
        int GetLastestProductId()
        {
            if (db.Products.Any())
                return db.Products.OrderByDescending(e => e.ProductId).Select(e => e.ProductId).FirstOrDefault();
            return 1;
        }
        void Clear()
        {
            tbProductId.Text = (GetLastestProductId()+1).ToString();
            tbProductName.Text = "";
            cbCategory.SelectedIndex = -1;
            nudCostPrice.Value = 0;
            nudSellingPrice.Value = 0;
            tbUnit.Text = "";
        }
        int GetCategoryId(string categoryName)
        {
            int? categoryId = db.Categories
                .Where(c => c.CategoryName == categoryName)
                .Select(c => (int?)c.CategoryId)
                .FirstOrDefault();
            return categoryId.Value;
        }
        private void frmProductEntry_Load(object sender, EventArgs e)
        {
            tbProductId.Text = (GetLastestProductId() + 1).ToString();
            foreach (var c in db.Categories)
            {
                cbCategory.Items.Add(c.CategoryName);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Create a new product instance
            var newProduct = new Product
            {
                ProductId= int.Parse(tbProductId.Text),
                ProductName = tbProductName.Text,
                CategoryId= GetCategoryId(cbCategory.Text),
                CostPrice= Convert.ToDouble(nudCostPrice.Value),
                SellingPrice= Convert.ToDouble(nudSellingPrice.Value),
                Unit= tbUnit.Text,
                Created= DateTime.Now,
                Updated= DateTime.Now,
            };

            // Add the new product to the Products DbSet
            db.Products.Add(newProduct);

            // Save changes to the database
            db.SaveChanges();

            MessageBox.Show("The software has added the data with success.");

            Clear();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            frmProductList frm = new frmProductList();
            frm.frmProductEntry = this;
            frm.ShowDialog();
        }
        public void LoadDataFromProductId(int id)
        {
            Product product = db.Products.Find(id);
            tbProductId.Text = $"{product.ProductId}";
            tbProductName.Text=$"{product.ProductName}";
            tbProductName.Text=$"{product.ProductName}";

            Category category=db.Categories.Find(product.CategoryId);
            cbCategory.SelectedItem = $"{category.CategoryName}";

            nudCostPrice.Value=Convert.ToDecimal(product.CostPrice);
            nudSellingPrice.Value=Convert.ToDecimal(product.SellingPrice);
            tbUnit.Text= $"{product.Unit}";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var product = db.Products.Find(Convert.ToInt32(tbProductId.Text));

            // Update the properties of the entity
            product.ProductName = tbProductName.Text;
            var category = db.Categories.FirstOrDefault(c => c.CategoryName == cbCategory.SelectedItem.ToString());
            product.CategoryId = category.CategoryId;
            product.CostPrice=Convert.ToDouble(nudCostPrice.Value);
            product.SellingPrice=Convert.ToDouble(nudSellingPrice.Value);
            product.Unit=tbUnit.Text;
            product.Updated=DateTime.Now;

            // Save changes to persist updates in the database
            db.SaveChanges();
            MessageBox.Show("The software has updated the data with success.");
            Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var product = db.Products.Find(Convert.ToInt32(tbProductId.Text));

            // Remove the entity from the DbContext
            db.Products.Remove(product);

            // Save changes to persist deletion in the database
            db.SaveChanges();
            MessageBox.Show("The software has deleted the data with success.");
            Clear();
        }
    }
}
