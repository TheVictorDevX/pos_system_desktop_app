using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDisconnectedMode
{
    public class Demo
    {
        private Database db = new Database();
        public void Run()
        {
            //db.ReadCategoryData();
            //db.InsertCategoryData();

            //db.UpdateCategoryData();
            db.DeleteCategoryData();
            db.ReadCategoryData();
        }
    }
}
