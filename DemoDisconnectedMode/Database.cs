using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDisconnectedMode
{
    //disconnected mode
    internal class Database
    {
        string connectionStr = "data source=DESKTOP-3CG136T; database=MPOS; integrated security=true;";

        public void ReadCategoryData()
        {
            SqlConnection sqlConnection= new SqlConnection(connectionStr);
            string command = "SELECT * FROM Category";

            //object control connection and command.
            SqlDataAdapter adapter = new SqlDataAdapter(command, sqlConnection);

            //collection of tables = database
            DataSet dataSet = new DataSet();
           
            //fill data to table Category in Dataset
            adapter.Fill(dataSet,"Category");

            //datatable store record as row and column = table
            DataTable dt = dataSet.Tables["Category"];
           
            //loop everu record using Datarow = record
            foreach(DataRow dr in dt.Rows)
            {
                Console.WriteLine("name : " + dr.Field<string>("CategoryName"));
            }
        }

        public void InsertCategoryData()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionStr);
            string command = "SELECT * FROM Category";
            SqlDataAdapter adapter = new SqlDataAdapter(command, sqlConnection);

            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "Category");

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.SelectCommand = builder.GetInsertCommand();

            DataTable dt = dataSet.Tables["Category"];

            DataRow dr = dt.NewRow();
            dr["CategoryId"] = 100;
            dr["CategoryName"] = "New Category Disconnected Mode";
            dr["Created"] = DateTime.Now.ToString();
            dr["Updated"] = DateTime.Now.ToString();
            dt.Rows.Add(dr);
            adapter.Update(dt);
            Console.WriteLine("Insert category succesfull!");
        }

        public void UpdateCategoryData()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionStr);
            string command = "SELECT * FROM Category";
            SqlDataAdapter adapter = new SqlDataAdapter(command, sqlConnection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "Category");

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.SelectCommand = builder.GetUpdateCommand();

            DataTable dt = dataSet.Tables["Category"];

            foreach(DataRow dr in dt.Rows)
            {
                int categoryId = dr.Field<int>("CategoryId");
                if(categoryId == 100)
                {
                    dr["CategoryName"] = "Demo Category Disconnected Mode";
                    dr["Updated"] = DateTime.Now.ToString();
                }
            }
            adapter.Update(dataSet,"Category");
            Console.WriteLine("Update category name success.");
        }

        public void DeleteCategoryData()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionStr);
            string command = "SELECT * FROM Category";
            SqlDataAdapter adapter = new SqlDataAdapter(command, sqlConnection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "Category");

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.SelectCommand = builder.GetDeleteCommand();
            DataTable dt = dataSet.Tables["Category"];

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                int categoryId = dr.Field<int>("CategoryId");
                if(categoryId == 100)
                {
                    dr.Delete();
                }
            }
            adapter.Update(dataSet,"Category");
        }
    }
}
