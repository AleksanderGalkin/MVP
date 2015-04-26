using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Gui;

namespace ConsoleApplication1
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            
            NUnit.Gui.AppEntry.Main(args);
        }

        # region Вариант для консоли с using NUnit.ConsoleRunner;
        //static void Main(string[] args)
        //{
            
        //     Runner.Main(args);
        //    Console.ReadLine();
        //}
        #endregion
    }
}
