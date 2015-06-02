using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GeoDbUserInterface.View;


namespace GeoDBWinForms
{
    public partial class ViewException : Form, IViewException
    {
        public event EventHandler<EventArgs> _formClosing;

        public ViewException()
        {
            InitializeComponent();
        }

        public string message
        {
            set
            {
                rtbError.Text = value;
            }
        }

        public new void ShowDialog()
        {
            base.ShowDialog();
        }

        private void ViewException_FormClosing(object sender, FormClosingEventArgs e)
        {
            var ev = _formClosing;
            if (ev != null)
            {
                ev(this, EventArgs.Empty);
            }
        }

    }
}
