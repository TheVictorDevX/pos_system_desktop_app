using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSEF
{
    public partial class frmEmployeeEntry : Form
    {
        POSEntities db = new POSEntities();
        public frmEmployeeEntry()
        {
            InitializeComponent();
        }
        int GetLastestEmployeeId()
        {
            var id = db.Employees
              .OrderByDescending(em => em.EmployeeId)
              .Select(em => (int)em.EmployeeId) // Convert Id to int and select
              .FirstOrDefault();

            return id;
        }
        void Clear()
        {
            tbEmployeeId.Text = (GetLastestEmployeeId() + 1).ToString();
            tbEmployeeName.Text = "";
            tbUsername.Text = "";
            tbPassword.Text = "";
            nudSalary.Value = 0;
            tbPhone.Text = "";
            tbAddress.Text = "";
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void frmEmployeeEntry_Load(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee
            {
                EmployeeId = Convert.ToInt32(tbEmployeeId.Text),
                EmployeeName = tbEmployeeName.Text,
                Username = tbUsername.Text,
                Password = tbPassword.Text,
                Salary = (double)nudSalary.Value,
                Phone = tbPhone.Text,
                Address = tbAddress.Text,
                Created = DateTime.Now,
                Updated = DateTime.Now,
            };
            // Add the entity to the DbSet
            db.Employees.Add(employee);

            // Save changes to the database
            db.SaveChanges();

            Clear();

            MessageBox.Show("Employee added successfully.");
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            frmEmployeeList frm = new frmEmployeeList();
            frm.frmEmployeeEntry = this;
            frm.ShowDialog();
        }
        public void LoadDataFromEmployeeId(int employeeId)
        {
            var employee = db.Employees.Find(employeeId);

            tbEmployeeId.Text = employee.EmployeeId.ToString();
            tbEmployeeName.Text = employee.EmployeeName.ToString();
            tbUsername.Text = employee.Username.ToString();
            tbPassword.Text = employee.Password.ToString();
            nudSalary.Value = (int)(employee.Salary);
            tbPhone.Text = employee.Phone.ToString();
            tbAddress.Text = employee.Address.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var employee = db.Employees.Find(Convert.ToInt32(tbEmployeeId.Text));

            employee.EmployeeId = Convert.ToInt32(tbEmployeeId.Text);
            employee.EmployeeName = tbEmployeeName.Text;
            employee.Username = tbUsername.Text;
            employee.Password = tbPassword.Text;
            employee.Salary = (double)nudSalary.Value;
            employee.Phone = tbPhone.Text;
            employee.Address = tbAddress.Text;
            employee.Updated = DateTime.Now;

            // Save changes to the database
            db.SaveChanges();

            Clear();

            MessageBox.Show("Employee updated successfully.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var employee = db.Employees.Find(Convert.ToInt32(tbEmployeeId.Text));

            db.Employees.Remove(employee);

            // Save changes to the database
            db.SaveChanges();

            Clear();

            MessageBox.Show("Employee deleted successfully.");
        }
    }
}
