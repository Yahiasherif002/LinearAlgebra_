using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            //GaussianJordanElimination a = new GaussianJordanElimination(2);

            //a.show();
            //Console.ReadKey();
            MainGUI main = new MainGUI();
            Application.Run(main);
        }
    }
}
