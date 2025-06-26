using DemoConnectedMode.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConnectedMode
{
    public class Demo
    {
        public void Run()
        {
            Database db = new Database();

            //read data
            /*List<Category> categories = db.ReadData();
            foreach (Category category in categories)
            {
                category.Show();
            }
            */

            //insert data
            //db.InsertData();
            //List<Category> categories = db.ReadData();

            //var category = categories.OrderByDescending(c => c.CategoryId).FirstOrDefault();
            //if (category != null)
            //    category.Show();

            //if (categories.Count > 0)
            //    categories[categories.Count - 1].Show();


            //update
            //db.UpdateData();
            //List<Category> categories = db.ReadData();

            //var category = categories.OrderByDescending(c => c.CategoryId).FirstOrDefault();
            //if (category != null)
            //    category.Show();

            //delete
            //db.DeleteData();

            //demo view
            //db.ReadDataFromView();


            //demo procedure
            //db.ReadDataFromStoreProcedure();

            //call scalar function
            db.ReadDataFromScalarFunction();
        }
    }
}
