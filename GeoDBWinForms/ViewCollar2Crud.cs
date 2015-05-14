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
    public partial class ViewCollar2Crud : Form,IViewCollar2Crud
    {
        public ViewCollar2Crud()
        {
            InitializeComponent();
        }


        public string Tittle 
        { 
            set
            {
                this.Text=value;
            }
        }
        public int id { get; set; }
        public string bhid
        {
            get
            {
                return tbBhid.Text;
            }
            set
            {
                tbBhid.Text = value;
            }
        }
        public Dictionary<int, string> gorizontList
        {
            set
            {
                foreach (var i in value)
                {
                    cbGorizont.Items.Add(new {key=i.Key,display=i.Value});
                    cbGorizont.ValueMember = "key";
                    cbGorizont.DisplayMember = "display";
                }
            }
            private get
            {
                return gorizontList ;
            }
        }
        public int gorizontID {
            get
            {
                return (int)cbGorizont.SelectedValue;
            }
            set
            {
                cbGorizont.SelectedItem = gorizontList.Select(x=>x.Key==value).FirstOrDefault();
            }
        }
        
        

        public Dictionary<int, string> blastList
        {
            set
            {
                foreach (var i in value)
                {
                    cbBlast.Items.Add(new { key = i.Key, display = i.Value });
                    cbBlast.ValueMember = "key";
                    cbBlast.DisplayMember = "display";
                }
            }
            private get
            {
                return blastList;
            }
        }
        public int blast
        {
            get
            {
                return cbBlast.SelectedIndex;
            }
            set
            {
                cbBlast.SelectedItem = blastList.Select(x => x.Key == value).FirstOrDefault();
            }
        }


        public int hole 
        {
            get
            {
                return  Convert.ToInt32( tbHole.Text) ;
            }
            set
            {
                tbHole.Text = value.ToString();
            }
        }
        public double xcollar 
        {
            get
            {
                return Convert.ToDouble(tbX.Text);
            }
            set
            {
                tbX.Text = value.ToString();
            }
        }
        public double ycollar
        {
            get
            {
                return Convert.ToDouble(tbY.Text);
            }
            set
            {
                tbY.Text = value.ToString();
            }
        }
        public double zcollar
        {
            get
            {
                return Convert.ToDouble(tbZ.Text);
            }
            set
            {
                tbZ.Text = value.ToString();
            }
        }
        public double enddepth
        {
            get
            {
                return Convert.ToDouble(tbEndDepth.Text);
            }
            set
            {
                tbEndDepth.Text = value.ToString();
            }
        }
        public Dictionary<int, string> drillTypeList
        {
            set
            {
                foreach (var i in value)
                {
                    cbDrillType.Items.Add(new { key = i.Key, display = i.Value });
                    cbDrillType.ValueMember = "key";
                    cbDrillType.DisplayMember = "display";
                }
            }
            private get
            {
                return drillTypeList;
            }
        }
        public int drillType
        {
            get
            {
                return cbDrillType.SelectedIndex;
            }
            set
            {
                cbDrillType.SelectedItem = drillTypeList.Select(x => x.Key == value).FirstOrDefault();
            }
        }

        public event EventHandler<EventArgs> openForm;
        public event EventHandler<EventArgs> clickOk;
        public event EventHandler<EventArgs> clickCloseForm;

        public new void Show()
        {
            this.ShowDialog();
        }
        
        public void Refresh()
        {
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            var ev = clickCloseForm;
            if (ev != null)
            {
                ev(this, EventArgs.Empty);
            }
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            var ev = clickOk;
            if (ev != null)
            {
                ev(this, EventArgs.Empty);
            }
        }


    }
}
