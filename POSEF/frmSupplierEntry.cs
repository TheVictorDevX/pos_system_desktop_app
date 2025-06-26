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
    public partial class frmSupplierEntry : Form
    {
        POSEntities db=new POSEntities();

        public frmSupplierEntry()
        {
            InitializeComponent();
        }

        int GetLastestSupplierId()
        {
            var id = db.Suppliers
              .OrderByDescending(e => e.SupplierId)
              .Select(e => (int)e.SupplierId) // Convert Id to int and select
              .FirstOrDefault();

            return id;
        }

        void Clear()
        {
            tbSupplierId.Text=(GetLastestSupplierId()+1).ToString();
            tbSupplierName.Text = "";
            tbPhone.Text = "";
            tbAddress.Text = "";
        }

        private void frmSupplierEntry_Load(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier
            {
                SupplierId=Convert.ToInt32(tbSupplierId.Text),
                SupplierName=tbSupplierName.Text,
                Phone=tbPhone.Text,
                Address=tbAddress.Text,
                Created=DateTime.Now,
                Updated=DateTime.Now,
            };

            db.Suppliers.Add(supplier);
            db.SaveChanges();
            MessageBox.Show("Supplier added successfully.");
            Clear();
        }

        public void LoadDataFromSupplierId(int supplierId)
        {
            var supplier = db.Suppliers.Find(supplierId);

            tbSupplierId.Text=supplier.SupplierId.ToString();
            tbSupplierName.Text=supplier.SupplierName;
            tbPhone.Text=supplier.Phone;
            tbAddress.Text=supplier.Address;
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            frmSupplierList frmSupplierList = new frmSupplierList();
            frmSupplierList.frmSupplierEntry = this;
            frmSupplierList.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var supplier = db.Suppliers.Find(Convert.ToInt32(tbSupplierId.Text));

            supplier.SupplierName= tbSupplierName.Text;
            supplier.Phone= tbPhone.Text;
            supplier.Address= tbAddress.Text;
            supplier.Updated= DateTime.Now;

            // Save changes to the database
            db.SaveChanges();

            Clear();

            MessageBox.Show("Supplier updated successfully.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var supplier = db.Suppliers.Find(Convert.ToInt32(tbSupplierId.Text));

            db.Suppliers.Remove(supplier);

            // Save changes to the database
            db.SaveChanges();

            Clear();

            MessageBox.Show("Supplier deleted successfully.");
        }
    }
}
