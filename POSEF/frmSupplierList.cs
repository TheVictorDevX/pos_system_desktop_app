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
    public partial class frmSupplierList : Form
    {
        POSEntities db=new POSEntities();
        public frmSupplierEntry frmSupplierEntry;

        public frmSupplierList()
        {
            InitializeComponent();
        }

        private void frmSupplierList_Load(object sender, EventArgs e)
        {
            foreach (var s in db.Suppliers)
            {
                dgvSupplier.Rows.Add(s.SupplierId,
                                        s.SupplierName,
                                        s.Phone,
                                        s.Address,
                                        s.Created,
                                        s.Updated);
            }
        }

        private void dgvSupplier_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the DataGridView control
                //DataGridView dataGridView = (DataGridView)sender;

                // Get the value of the first column in the selected row
                int supplierId = Convert.ToInt32(dgvSupplier.Rows[e.RowIndex].Cells[0].Value);

                // Use the value as needed (e.g., display in a textbox)
                frmSupplierEntry.LoadDataFromSupplierId(supplierId);

                Close();
            }
        }
    }
}
