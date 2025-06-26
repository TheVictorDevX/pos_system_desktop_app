using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLinqToSQL
{
    internal class Menu
    {
        private POSModelDataContext db = new POSModelDataContext();
        public void StartMenu()
        {
            Console.WriteLine("WELCOME TO CONSOLE MENU");
            Console.WriteLine("1) Add Customer");
            Console.WriteLine("2) Update Customer");
            Console.WriteLine("3) Delete Customer");
            Console.WriteLine("4) Disply Customers");
            Console.WriteLine("5) Disply Customer By Name");

            Console.Write("Enter choice : ");

            string choice = Console.ReadLine();
            switch(choice)
            {
                case "1": AddCustomer(); break;
                case "2": UpdateCustomer(); break;
                case "3": DeleteCustomer(); break;
                case "4": DisplayCustomers(); break;
                case "5": DisplayCustomerByName(); break;
                default: Console.WriteLine("Invalid choice");
                         StartMenu();
                            break;
            }
        }

        private void AddCustomer()
        {
            int newCustomerId = GetLatestCustomerId() + 1;
            Console.WriteLine("Add Customer");
            Console.WriteLine("CustomerId : " + newCustomerId);
            Console.Write("Enter customer Name : ");
            string customerName = Console.ReadLine();
            Console.Write("Enter Phone : ");
            string phone = Console.ReadLine();
            Console.Write("Enter Address : ");
            string address = Console.ReadLine();

            Customer newCustomer = new Customer();
            newCustomer.CustomerId = newCustomerId;
            newCustomer.CustomerName = customerName;
            newCustomer.Phone = phone;
            newCustomer.Address = address;
            newCustomer.Created = DateTime.Now;
            newCustomer.Updated= DateTime.Now;
            db.Customers.InsertOnSubmit(newCustomer);
            db.SubmitChanges();

            Console.WriteLine("Add success");
            StartMenu();
        }

        private int GetLatestCustomerId()
        {
            //var customer = db.Customers.Max(x => x.CustomerId);

            //SELECT TOP 1 CustomerId FROM Customer ORDER BY CustomerId DESC
            var customer = db.Customers.OrderByDescending(x => x.CustomerId).FirstOrDefault();
            if(customer != null)
                return customer.CustomerId;
            return 1;
        }

        public void UpdateCustomer()
        {
            Console.WriteLine("Update Customer");
            Console.Write("Enter CustomerId : ");
            string customerIdStr = Console.ReadLine();
            int customerId = Convert.ToInt32(customerIdStr);
            var customer = db.Customers.Where(c =>c.CustomerId == customerId).FirstOrDefault();
            if(customer != null)
            {
                Console.WriteLine("CustomerId : " + customerId);
                Console.Write("Enter customer Name : ");
                string customerName = Console.ReadLine();
                Console.Write("Enter Phone : ");
                string phone = Console.ReadLine();
                Console.Write("Enter Address : ");
                string address = Console.ReadLine();

                customer.CustomerName= customerName;
                customer.Address = address;
                customer.Phone = phone;
                customer.Updated = DateTime.Now;
                db.SubmitChanges();
                Console.WriteLine("Update success");
            }
            else
            {
                Console.WriteLine("CustomerId : {0} Not found",customerId);
            }

            Console.WriteLine();
            StartMenu();

        }
        public void DeleteCustomer()
        {
            Console.WriteLine("Delete Customer");
            Console.Write("Enter CustomerId : ");
            string customerIdStr = Console.ReadLine();
            int customerId = Convert.ToInt32(customerIdStr);
            var customer = db.Customers.Where(c => c.CustomerId == customerId).FirstOrDefault();
            if(customer != null)
            {
                db.Customers.DeleteOnSubmit(customer);
                db.SubmitChanges();
                Console.WriteLine("Customer : {0} has been deleted.",customerId);
            }
            else
            {
                Console.WriteLine("CustomerId : {0} Not found", customerId);
            }

            StartMenu();
        }

        public void DisplayCustomers()
        {
            Console.WriteLine("Display All Customes");
            foreach(Customer c in db.Customers)
            {
                Console.WriteLine("Id:{0},Name:{1},Phone:{2},Address:{3}",
                    c.CustomerId,c.CustomerName,c.Phone,c.Address);
            }

            Console.WriteLine();
            StartMenu();
        }
        public void DisplayCustomerByName()
        {
            Console.WriteLine("Display Custome by Name");
            Console.Write("Enter customer name : ");
            string customerName = Console.ReadLine();

            //linq
            var customer = db.Customers.Where(c => c.CustomerName == customerName).FirstOrDefault();

            if(customer != null)
            {
                Console.WriteLine("Id:{0},Name:{1},Phone:{2},Address:{3}",
                   customer.CustomerId, customer.CustomerName, customer.Phone, customer.Address);
            }
            else 
            {
                Console.WriteLine("Customer name : {0} Not found!", customerName); ;
            }

            Console.WriteLine();
            StartMenu();
        }
    }
}
