using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Forms;
using testForms;


namespace test
{

    static class Program
    {
        [STAThread]
        static void Main()
        {
            FormView view = new FormView();
            Presenter presenter = new Presenter(view);
          //   Application.Run(view);
            presenter.Show();
        }
    }
}