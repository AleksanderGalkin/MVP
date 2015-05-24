using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GeoDB.View;

namespace GeoDBWinForms
{
    public partial class ViewLogin : Form,IViewLogin
    {
        public ViewLogin()
        {
            InitializeComponent();
        }

        public List<string> userNames { set; private get; }
        public string userName 
        {
            get { return tbUserName.Text; }
            set { tbUserName.Text = value; }
        }
        public string password 
        {
            get { return tbPassword.Text; }
            set { tbPassword.Text = value; }
        }
        public List<string> serverNames { set; private get; }
        public string serverName
        {
            get { return tbServerName.Text; }
            set { tbServerName.Text = value; }
        }
        public List<string> dbNames { set; private get; }
        public string dbName 
        {
            get { return tbDbName.Text; }
            set { tbDbName.Text = value; }
        }

        public bool propVisible
        {
            get { return this.Visible; }
            set { this.Visible = value; }
        }

        public event EventHandler<EventArgs> clickOk;
        public event EventHandler<EventArgs> clickCancel;

        public new void Show()
        {
            base.ShowDialog(); ;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            var ev = clickOk;
            if (ev != null)
            {
                ev(this, EventArgs.Empty);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var ev = clickCancel;
            if (ev != null)
            {
                ev(this, EventArgs.Empty);
            }
        }
    }
}
