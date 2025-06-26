using DemoConnectedMode.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConnectedMode
{
    public class Database
    {
        string connectionStr = "data source=DESKTOP-3CG136T; database=MPOS; integrated security=true;";
        public List<Category> ReadData()
        {
            List<Category> categories= new List<Category>();    

            SqlConnection sqlConnection = new SqlConnection(connectionStr);
            string command = "SELECT * FROM Category";
            SqlCommand sqlCommand = new SqlCommand(command);
            sqlCommand.Connection= sqlConnection;

            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while(reader.Read())
            {
                //Console.WriteLine(reader.GetValue(2));
                //Console.WriteLine(reader["CategoryId"]); ;
                Category category = new Category(reader);
                categories.Add(category);
            }
            sqlConnection.Close();

            return categories;
        }

        public Category GetCategoryByCategoryId(int categoryId)
        { 
            Category category = new Category();
            SqlConnection sqlConnection = new SqlConnection(connectionStr);
            string command = "SELECT * FROM Category WHERE CategoryId = @CategoryId";
            SqlCommand sqlCommand = new SqlCommand(command);
            sqlCommand.Parameters.AddWithValue("@CategoryId", categoryId);
            sqlCommand.Connection = sqlConnection;

            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                category = new Category(reader);
            }
            sqlConnection.Close();

            return category;
        }

        public void InsertData(int categoryId,string categoryName)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionStr);
            string command = "INSERT INTO Category VALUES(@id,@name,@created,@updated)";
            SqlCommand sqlCommand = new SqlCommand(command);
            sqlCommand.Connection= sqlConnection;
            sqlConnection.Open();

            sqlCommand.Parameters.AddWithValue("@id",categoryId);
            sqlCommand.Parameters.AddWithValue("@name",categoryName);
            sqlCommand.Parameters.AddWithValue("@created",DateTime.Now);
            sqlCommand.Parameters.AddWithValue("@updated",DateTime.Now);

            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void UpdateData(Category category)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionStr);
            string command = "UPDATE Category SET CategoryName=@name,Updated = @updated WHERE CategoryId = @id";
            SqlCommand sqlCommand = new SqlCommand(command);
            sqlCommand.Connection= sqlConnection;
            sqlConnection.Open();

            sqlCommand.Parameters.AddWithValue("@id", category.CategoryId);
            sqlCommand.Parameters.AddWithValue("@name", category.CategoryName);
            sqlCommand.Parameters.AddWithValue("@updated", DateTime.Now);

            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void DeleteData(int categoryId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionStr);
            string command = "DELETE Category WHERE CategoryId = @id";
            SqlCommand sqlCommand = new SqlCommand(command);
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            sqlCommand.Parameters.AddWithValue("@id", categoryId);

            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            Console.WriteLine("Delete successfully!");
        }

        //view
        public void ReadDataFromView()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionStr);
            string command = "SELECT * FROM vCategory";
            SqlCommand sqlCommand = new SqlCommand(command);
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while(reader.Read())
            {
                Console.WriteLine(reader.GetString(1));
            }
            sqlConnection.Close();
        }

        //store
        public void ReadDataFromStoreProcedure()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionStr);
            string storeName = "spCategory";
            SqlCommand sqlCommand = new SqlCommand(storeName);
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while(reader.Read())
            {
                Console.WriteLine(reader.GetString(1));
            }
        }

        //store with parameters
        public void ReadDataFromStoreProcedureWithParameter()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionStr);
            string storeName = "spGetProductDetailByCategoryName";
            SqlCommand sqlCommand = new SqlCommand(storeName);
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@name", "Immediate Family");

            SqlDataReader reader = sqlCommand.ExecuteReader();
            while(reader.Read())
            {
                Console.WriteLine(reader.GetString(1));
            }
        }

        //function
        public void ReadDataFromScalarFunction()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionStr);
            string command = "SELECT dbo.FuncCountCategory()";
            SqlCommand sqlCommand= new SqlCommand(command);
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            //execute
            int count = (int)sqlCommand.ExecuteScalar();
            Console.WriteLine("category count : " + count);
            sqlConnection.Close();
        }


        public int GetLatestCategoryId()
        {
            int categoryId = 1;
            SqlConnection sqlConnection= new SqlConnection(connectionStr);
            string command = "SELECT TOP 1 CategoryId FROM Category ORDER BY CategoryId DESC";
            SqlCommand sqlCommand= new SqlCommand(command);
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while(reader.Read())
            {
                categoryId = reader.GetInt32(0);
                return categoryId;
            }

            return categoryId;
        }
    }
}
