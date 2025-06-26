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
    public partial class frmCustomerEntry : Form
    {
        POSEntities db=new POSEntities();

        public frmCustomerEntry()
        {
            InitializeComponent();
        }

        int GetLastestCustomerId()
        {
            var id = db.Customers
              .OrderByDescending(e => e.CustomerId)
              .Select(e => (int)e.CustomerId) // Convert Id to int and select
              .FirstOrDefault();

            return id;
        }

        void Clear()
        {
            tbCustomerId.Text=(GetLastestCustomerId()+1).ToString();
            tbCustomerName.Text = "";
            tbPhone.Text = "";
            tbAddress.Text = "";
        }

        private void frmCustomerEntry_Load(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer
            {
                CustomerId=Convert.ToInt32(tbCustomerId.Text),
                CustomerName=tbCustomerName.Text,
                Phone=tbPhone.Text,
                Address=tbAddress.Text,
                Created=DateTime.Now,
                Updated=DateTime.Now
            };

            db.Customers.Add(customer);
            db.SaveChanges();
            MessageBox.Show("Customer added successfully.");
            Clear();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            frmCustomerList frmCustomerList = new frmCustomerList();
            frmCustomerList.frmCustomerEntry = this;
            frmCustomerList.ShowDialog();
        }

        public void LoadDataFromCustomerId(int customerId)
        {
            var customer = db.Customers.Find(customerId);

            tbCustomerId.Text=customer.CustomerId.ToString();
            tbCustomerName.Text=customer.CustomerName.ToString();
            tbPhone.Text=customer.Phone.ToString();
            tbAddress.Text=customer.Address.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var customer = db.Customers.Find(Convert.ToInt32(tbCustomerId.Text));

            customer.CustomerId= Convert.ToInt32(tbCustomerId.Text);
            customer.CustomerName= tbCustomerName.Text;
            customer.Phone=tbPhone.Text;
            customer.Address=tbAddress.Text;
            customer.Updated=DateTime.Now;

            // Save changes to the database
            db.SaveChanges();

            Clear();

            MessageBox.Show("Customer updated successfully.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var customer = db.Customers.Find(Convert.ToInt32(tbCustomerId.Text));

            db.Customers.Remove(customer);

            // Save changes to the database
            db.SaveChanges();

            Clear();

            MessageBox.Show("Customer deleted successfully.");
        }
    }
}
