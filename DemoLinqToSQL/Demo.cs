using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLinqToSQL
{
    internal class Demo
    {
        private POSModelDataContext db = new POSModelDataContext();
        public void Run()
        {
            Menu menu = new Menu();
            menu.StartMenu();
        }
    }
}
