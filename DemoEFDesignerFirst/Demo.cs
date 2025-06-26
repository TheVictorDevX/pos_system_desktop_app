using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEFDesignerFirst
{
    internal class Demo
    {
        private POSModelContainer db = new POSModelContainer();
        public void Run()
        {
            InsertCategory();
            DisplayCategory();
        }

        private void InsertCategory()
        {
            Category category = new Category();
            category.Name = "Drink";
            category.Created= DateTime.Now;
            category.Updated= DateTime.Now;
            db.Categories.Add(category);
            db.SaveChanges();
            Console.WriteLine("Add Success");
        }

        private void DisplayCategory()
        {
            foreach(Category c in db.Categories)
            {
                Console.WriteLine("Id : {0}, Name : {1}",
                            c.Id,c.Name);
            }
        }
    }
}
