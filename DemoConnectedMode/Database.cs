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

        public void InsertData()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionStr);
            string command = "INSERT INTO Category VALUES(@id,@name,@created,@updated)";
            SqlCommand sqlCommand = new SqlCommand(command);
            sqlCommand.Connection= sqlConnection;
            sqlConnection.Open();

            sqlCommand.Parameters.AddWithValue("@id",57);
            sqlCommand.Parameters.AddWithValue("@name","New Category C#");
            sqlCommand.Parameters.AddWithValue("@created",DateTime.Now);
            sqlCommand.Parameters.AddWithValue("@updated",DateTime.Now);

            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void UpdateData()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionStr);
            string command = "UPDATE Category SET CategoryName=@name WHERE CategoryId = @id";
            SqlCommand sqlCommand = new SqlCommand(command);
            sqlCommand.Connection= sqlConnection;
            sqlConnection.Open();

            sqlCommand.Parameters.AddWithValue("@id", 57);
            sqlCommand.Parameters.AddWithValue("@name", "New Category Java");

            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void DeleteData()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionStr);
            string command = "DELETE Category WHERE CategoryId = @id";
            SqlCommand sqlCommand = new SqlCommand(command);
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            sqlCommand.Parameters.AddWithValue("@id", 57);

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
    }
}
