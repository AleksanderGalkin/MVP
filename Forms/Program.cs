using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using testForms;
using presenter;


namespace Forms
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
              //Application.Run(new FormView());

              IView view = new FormView();
              Presenter presenter = new Presenter(view);
              //   Application.Run(view);
              presenter.Show();

        }
    }
}
