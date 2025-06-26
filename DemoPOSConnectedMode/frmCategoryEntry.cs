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
    public partial class frmCategoryEntry : Form
    {
        public frmCategoryEntry()
        {
            InitializeComponent();
        }

        private Database db = new Database();

        private void frmCategoryEntry_Load(object sender, EventArgs e)
        {
            Init();
        }

        public void Init()
        {
            int categoryId = db.GetLatestCategoryId();
            categoryId += 1;
            txtCategoryId.Text = categoryId.ToString();
            txtCategoryName.Text = "";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int categoryId = int.Parse( txtCategoryId.Text);
            string categoryName = txtCategoryName.Text;

            db.InsertData(categoryId, categoryName);
            MessageBox.Show("Insert new category success!");

            Init();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            frmCategoryList frm = new frmCategoryList();
            frm.categoryEntry = this;
            frm.Show();
        }

        public void RefreshDataByCategoryId(int categoryId)
        {
            //MessageBox.Show("CategoryId : " + categoryId);
            Category category = db.GetCategoryByCategoryId(categoryId);
            if(category != null)
            {
                txtCategoryId.Text = category.CategoryId.ToString();
                txtCategoryName.Text = category.CategoryName;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int categoryId = int.Parse(txtCategoryId.Text);
            string categoryName = txtCategoryName.Text.Trim();

            if(!string.IsNullOrEmpty(categoryName) ) { 
                //update data to database

                Category category = new Category();
                category.CategoryId = categoryId;
                category.CategoryName = categoryName;

                db.UpdateData(category);
                MessageBox.Show("Update success!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int categoryId = int.Parse(txtCategoryId.Text);
                db.DeleteData(categoryId);
                MessageBox.Show("Delete successful");
                Init();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
