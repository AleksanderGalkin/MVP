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
    public partial class ViewDrillHoles2PrintSet : Form,IViewDrillHoles2PrintSet
    {

        public List<string> benchList 
        {
            set
            {
                cbBench.DataSource = value;
            }
        }
        public string bench 
        {
            get { return cbBench.SelectedValue.ToString(); }
            set { cbBench.SelectedText =value; }
        }
        public List<string> blastList 
        {
            set
            {
                cbBlast.DataSource = value;
            }
        }
        public string blast
        {
            get { return cbBlast.SelectedValue.ToString(); }
            set { cbBlast.SelectedText = value; }
        }
        public IView _MdiParent { set { this.MdiParent = value as Form; } }
        public IView OwnerForm { get; set; }


        public event EventHandler<EventArgs> _selectBench;
        public event EventHandler<EventArgs> _clickOk;
        public event EventHandler<EventArgs> _clickCancel;

        public event EventHandler<EventArgs> _formClosing;

        public ViewDrillHoles2PrintSet()
        {
            InitializeComponent();
        }

        
        public new void Show()
        {
            (OwnerForm as Form).Enabled = false;
            base.Show();
        }

        private void cbBench_SelectedValueChanged(object sender, EventArgs e)
        {
            var ev = _selectBench;
            if (ev != null)
            {
                ev(this, EventArgs.Empty);
            }
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            var ev = _clickOk;
            if (ev != null)
            {
                ev(this, EventArgs.Empty);
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            var ev = _clickCancel;
            if (ev != null)
            {
                ev(this, EventArgs.Empty);
            }
            base.Close();
        }

        private void ViewDrillHoles2PrintSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            (OwnerForm as Form).Enabled = true;
            var ev = _formClosing;
            if (ev != null)
            {
                ev (this, EventArgs.Empty);
            }
            
        }


    }
}
