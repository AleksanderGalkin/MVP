using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GeoDB.Presenter;
using GeoDBWinForms;


namespace GeoDB
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ViewMainForm mainForm = new ViewMainForm();
            PMainForm PMainForm = new PMainForm(mainForm);
            if (!mainForm.IsDisposed)
            {
                PMainForm.Show();
            }



        }
    }
}
