using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConnectedMode.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }    
        public string Created { get; set; }
        public string Updated { get; set; }

        public Category()
        {

        }

        public Category(int categoryId, string categoryName, string created, string updated)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
            Created = created;
            Updated = updated;
        }

        public Category(SqlDataReader reader)
        {
            CategoryId = (int)reader["CategoryId"];
            CategoryName = reader["CategoryName"].ToString();
            Created = reader["Created"].ToString();
            Updated = reader["Updated"].ToString();
        }

        public void Show()
        {
            Console.WriteLine("Id : {0},Name : {1}, Created : {2}, Updated : {3}",
                CategoryId,CategoryName,Created,Updated);
        }
    }
}
