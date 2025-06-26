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
    public partial class frmCustomerList : Form
    {
        POSEntities db=new POSEntities();
        public frmCustomerEntry frmCustomerEntry;
        public frmCustomerList()
        {
            InitializeComponent();
        }

        private void frmCustomerList_Load(object sender, EventArgs e)
        {
            foreach (var c in db.Customers)
            {
                dgvCustomer.Rows.Add(c.CustomerId,c.CustomerName,c.Phone,c.Address,c.Created,c.Updated);
            }
        }

        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the DataGridView control
                //DataGridView dataGridView = (DataGridView)sender;

                // Get the value of the first column in the selected row
                int customerId = Convert.ToInt32(dgvCustomer.Rows[e.RowIndex].Cells[0].Value);

                // Use the value as needed (e.g., display in a textbox)
                frmCustomerEntry.LoadDataFromCustomerId(customerId);

                Close();
            }
        }
    }
}
