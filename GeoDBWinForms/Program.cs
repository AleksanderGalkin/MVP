using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Ninject;
using GeoDB.View;
using GeoDB.Service.DataAccess.Interface;
using GeoDB.Model;
using GeoDB.Presenter;
using GeoDB.Service.DataAccess;



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

            Application.Run(new ViewMainForm());
  

        }
    }
}
