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
    public partial class frmProductList : Form
    {
        POSEntities db = new POSEntities();
        public frmProductEntry frmProductEntry = null;
        public frmProductList()
        {
            InitializeComponent();
        }

        private void frmProductList_Load(object sender, EventArgs e)
        {
            foreach (Product p in db.Products)
            {
                dgvProduct.Rows.Add(p.ProductId,
                                    p.ProductName,
                                    p.CategoryId,
                                    p.CostPrice,
                                    p.SellingPrice,
                                    p.Unit,
                                    p.Created,
                                    p.Updated);
            }
        }

        private void dgvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure that the row index is valid
            {
                // Get the currently selected row
                DataGridViewRow selectedRow = dgvProduct.Rows[e.RowIndex];

                // Retrieve values from the selected row
                int id = Convert.ToInt32(selectedRow.Cells[0].Value);

                frmProductEntry.LoadDataFromProductId(id);

                Close();
                // Display the values (for demonstration purposes)
                //MessageBox.Show($"ID: {id}, Name: {name}, Age: {age}");
            }
        }
    }
}
