using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEFDBFirst
{
    internal class Demo
    {
        private MPOSEntities db = new MPOSEntities();
        public void Run()
        {

            //ReadProduct();

            //InsertCategory();
            //UpdateCategory();
            DeleteCategory();
            DisplayCategory();
        }

        private void InsertCategory()
        {
            int categoryId = db.Categories
                        .OrderByDescending(cat => cat.CategoryId)
                        .FirstOrDefault().CategoryId +1;

            Category c = new Category();
            c.CategoryId = categoryId;
            c.CategoryName = "New CategoryName";
            c.Created = DateTime.Now;
            c.Updated = DateTime.Now;

            db.Categories.Add(c);
            db.SaveChanges();
            Console.WriteLine("Add success");
        }

        private void DisplayCategory()
        {
            foreach(Category c in db.Categories)
            {
                Console.WriteLine("Id : {0}, Name:{1},",
                                    c.CategoryId,c.CategoryName);
            }
        }

        private void ReadProduct()
        {
            foreach(Product p in db.Products)
            {
                if(p.Category != null)
                    Console.WriteLine("Name : {0}, Category : {1}",
                    p.ProductName,p.Category.CategoryName);
            }
        }

        private void UpdateCategory()
        {
            var category = db.Categories
                .Where(c => c.CategoryId == 62)
                .FirstOrDefault();
            if(category != null)
            {
                category.CategoryName = "Update Category Name 123";
                category.Updated = DateTime.Now;
                db.SaveChanges();
            }
        }

        private void DeleteCategory()
        {
            var category = db.Categories
                .Where(c => c.CategoryId == 62)
                .FirstOrDefault();
            if (category != null)
            {
                db.Categories.Remove(category);
                db.SaveChanges();
            }
        }

        private Category GetCategory()
        {
            foreach(Category c in db.Categories)
            {
                if (c.CategoryId == 62)
                    return c;

            }
            return null;
        }
    }
}
