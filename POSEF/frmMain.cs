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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void categoryEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoryEntry cat = new frmCategoryEntry();
            cat.Show();
        }

        private void categoryListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoryList cat = new frmCategoryList();
            cat.Show();
        }

        private void productListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductList cat = new frmProductList();
            cat.Show();
        }

        private void productEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductEntry cat = new frmProductEntry();
            cat.Show();
        }

        private void employeeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeList cat = new frmEmployeeList();
            cat.Show();
        }

        private void employeeEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeEntry cat = new frmEmployeeEntry();
            cat.Show();
        }

        private void customerListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerList cat = new frmCustomerList();
            cat.Show();
        }

        private void customerEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerEntry cat = new frmCustomerEntry();
            cat.Show();
        }

        private void supplierListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplierList cat = new frmSupplierList();
            cat.Show();
        }

        private void supplierEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplierEntry cat = new frmSupplierEntry();
            cat.Show();
        }
    }
}
