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
    public partial class frmCategoryList : Form
    {
        public frmCategoryList()
        {
            InitializeComponent();
        }

        private POSEntities db = new POSEntities();

        public frmCategoryEntry categoryEntry = null;

        private void frmCategoryList_Load(object sender, EventArgs e)
        {
            foreach(Category c in db.Categories)
            {
                dgvCategory.Rows.Add(c.CategoryId,
                                        c.CategoryName,
                                        c.Created,
                                        c.Updated);
            }
        }

        private void dgvCategory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(categoryEntry !=null)
            {
                if( dgvCategory.SelectedRows.Count > 0)
                {
                    string value = dgvCategory.SelectedRows[0].Cells[0].Value.ToString();
                    int categoryId = int.Parse(value);
                    
                    categoryEntry.LoadDataFromCategoryId(categoryId);
                    Close();
                }
            }
        }
    }
}
