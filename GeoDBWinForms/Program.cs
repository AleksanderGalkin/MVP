using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GeoDB.Presenter;

namespace GeoDBWinForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            IViewCollar2 view = new ViewCollar2();
           // view.Show();
            PDrillHoles presenter = new PDrillHoles(view);
          //  Application.Run();
            presenter.Show();
        }
    }
}
