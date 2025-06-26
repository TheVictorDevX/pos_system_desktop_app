using DemoConnectedMode;
using DemoConnectedMode.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoPOSConnectedMode
{
    public partial class frmCategoryList : Form
    {

        public frmCategoryEntry categoryEntry = null;

        public frmCategoryList()
        {
            InitializeComponent();
        }

        private Database db = new Database();

        private void frmCategoryList_Load(object sender, EventArgs e)
        {
            List<Category> categories = db.ReadData();
            foreach (Category c in categories)
            {
                dgvCategory.Rows.Add(c.CategoryId,
                                        c.CategoryName,
                                        c.Created,
                                        c.Updated);
            }
        }

        private void dgvCategory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (categoryEntry == null)
                return;

            if(dgvCategory.SelectedRows.Count == 0) 
                return;

            var selectedItem = dgvCategory.SelectedRows[0];
            int categoryId = (int)selectedItem.Cells[0].Value;
            //MessageBox.Show("CategoryId : " + categoryId);
            categoryEntry.RefreshDataByCategoryId(categoryId);
            this.Close();
        }
    }
}
