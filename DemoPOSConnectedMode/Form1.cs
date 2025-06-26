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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void categoryListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoryList frm = new frmCategoryList();
            frm.Show();
        }

        private void categoryEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoryEntry frm = new frmCategoryEntry();
            frm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
