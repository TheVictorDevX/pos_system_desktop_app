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
    public partial class frmEmployeeList : Form
    {
        POSEntities db=new POSEntities();
        public frmEmployeeEntry frmEmployeeEntry=null;
        public frmEmployeeList()
        {
            InitializeComponent();
        }

        private void frmEmployeeList_Load(object sender, EventArgs e)
        {
            foreach (Employee em in db.Employees)
            {
                dgvEmployee.Rows.Add(em.EmployeeId,
                                    em.EmployeeName,
                                    em.Username,
                                    em.Password,
                                    em.Salary,
                                    em.Phone,
                                    em.Address,
                                    em.Created,
                                    em.Updated);
            }
        }

        private void dgvEmployee_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the DataGridView control
                //DataGridView dataGridView = (DataGridView)sender;

                // Get the value of the first column in the selected row
                int employeeId = Convert.ToInt32(dgvEmployee.Rows[e.RowIndex].Cells[0].Value);

                // Use the value as needed (e.g., display in a textbox)
                frmEmployeeEntry.LoadDataFromEmployeeId(employeeId);

                Close();
            }
        }
    }
}
