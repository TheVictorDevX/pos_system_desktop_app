using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSEF
{
    public partial class frmCategoryEntry : Form
    {
        public frmCategoryEntry()
        {
            InitializeComponent();
        }

        private POSEntities db = new POSEntities();

        private void frmCategoryEntry_Load(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            txtCategoryId.Text = (GetLatestCategoryId() + 1).ToString();
            txtCategoryName.Text = "";
        }

        private int GetLatestCategoryId()
        {
            var category = db.Categories
                .OrderByDescending(c => c.CategoryId)
                .FirstOrDefault();
            if(category != null )
                return category.CategoryId;
            return 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.CategoryId = GetLatestCategoryId()+ 1;
            category.CategoryName = txtCategoryName.Text;
            category.Created= DateTime.Now;
            category.Updated=DateTime.Now;
            db.Categories.Add(category);
            db.SaveChanges();
            MessageBox.Show("Add success");
            Clear();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            frmCategoryList categoryList = new frmCategoryList();
            categoryList.categoryEntry = this;
            categoryList.Show();
        }

        public void LoadDataFromCategoryId(int categoryId)
        {
            var category = db.Categories
                            .Where(c => c.CategoryId == categoryId)
                            .FirstOrDefault();
            if(category != null)
            {
                txtCategoryId.Text = category.CategoryId.ToString();
                txtCategoryName.Text = category.CategoryName.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int categoryId = int.Parse(txtCategoryId.Text);
            string categoryName = txtCategoryName.Text;

            var category = db.Categories
                            .Where(c => c.CategoryId == categoryId) 
                            .FirstOrDefault();
            if(category != null)
            {
                category.CategoryName = categoryName;
                category.Updated = DateTime.Now;
                db.SaveChanges();
                MessageBox.Show("Update Success");
                Clear();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int categoryId = int.Parse(txtCategoryId.Text);

            var category = db.Categories
                            .Where(c => c.CategoryId == categoryId)
                            .FirstOrDefault();
            if (category != null)
            {
                db.Categories.Remove(category);
                db.SaveChanges();
                MessageBox.Show("Delete Success");
                Clear();
            }
        }
    }
}
