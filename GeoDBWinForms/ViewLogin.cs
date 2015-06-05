using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GeoDbUserInterface.View;
using System.Deployment.Application;

namespace GeoDBWinForms
{
    public partial class ViewLogin : Form,IViewLogin
    {
        public ViewLogin()
        {
            InitializeComponent();
        }

        public List<string> userNames 
        {
            set
            {
                cbUserName.DataSource=value;
            }
        }
        public string userName 
        {
            get { return cbUserName.Text; }
            set { cbUserName.Text = value; }
        }
        public string password 
        {
            get { return tbPassword.Text; }
            set { tbPassword.Text = value; }
        }
        public List<string> serverNames
        {
            set
            {
                cbServerName.DataSource = value;
            }
        }
        public string serverName
        {
            get { return cbServerName.Text; }
            set { cbServerName.Text = value; }
        }
        public List<string> dbNames
        {
            set
            {

                cbDbName.DataSource = value;
            }
        }
        public string dbName 
        {
            get { return cbDbName.Text; }
            set { cbDbName.Text = value; }
        }
        public List<string> dbFileNames
        {
            set
            {
                List<string> isolatedStoragep = new List<string>();
                if (ApplicationDeployment.IsNetworkDeployed)
                {
                    isolatedStoragep.Add(Application.LocalUserAppDataPath + @"\DB\bl_TEST.mdf");
                }
                cbDbFileName.DataSource = isolatedStoragep.Union(value).ToList(); ;
            }
        }
        public string dbFileName
        {
            get { return cbDbFileName.Text; }
            set { cbDbFileName.Text = value; }
        }

        public bool locationServerDb 
        {
            get
            {
                return rbServer.Checked;
            }
            set
            {
                rbServer.Checked = value;
                rbDesktop.Checked = !value;
                rbServer_CheckedChanged(this, EventArgs.Empty);
            }
        }

        public bool isWindowsAuthentication 
        {
            get
            {
                return rbWindowsAuthentication.Checked;
            }
            set
            {
                rbWindowsAuthentication.Checked = value;
                rbSQLAuthentication.Checked = !value;
              //  rbWindowsAuthentication_CheckedChanged(this, EventArgs.Empty);
            }
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
            List<string> isolatedStoragep = new List<string>();
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                isolatedStoragep.Add(Application.LocalUserAppDataPath + @"\DB\bl_TEST.mdf");
                dbFileNames = isolatedStoragep;
            }
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

        private void rbServer_CheckedChanged(object sender, EventArgs e)
        {
            
            cbDbName.Enabled = locationServerDb;
            cbDbFileName.Enabled = !locationServerDb;
            btDbFileName.Enabled = !locationServerDb;
        }

        private void rbDesktop_CheckedChanged(object sender, EventArgs e)
        {
            
            cbDbName.Enabled = locationServerDb;
            cbDbFileName.Enabled = !locationServerDb;
            btDbFileName.Enabled = !locationServerDb;
        }


        private void btDbFileName_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "MS SQL DBF files(*.mdf)|*.mdf|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = false;
            openFileDialog1.ValidateNames = false;
            DialogResult r = openFileDialog1.ShowDialog();
            if (r == DialogResult.OK)
                {
                    cbDbFileName.Text = openFileDialog1.FileName;
                }
        }

        private void rbWindowsAuthentication_CheckedChanged(object sender, EventArgs e)
        {
            cbUserName.Enabled = !isWindowsAuthentication;
            tbPassword.Enabled = !isWindowsAuthentication;
        }

        private void rbSQLAuthentication_CheckedChanged(object sender, EventArgs e)
        {
            cbUserName.Enabled = !isWindowsAuthentication;
            tbPassword.Enabled = !isWindowsAuthentication;
        }



 
    }
}
