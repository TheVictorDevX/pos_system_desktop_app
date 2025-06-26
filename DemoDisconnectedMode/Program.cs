using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDisconnectedMode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Demo demo = new Demo();
            demo.Run();

            Console.ReadLine();
        }
    }
}
