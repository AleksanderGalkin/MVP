using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GeoDB.Model;

namespace GeoDBWinForms
{
    public partial class ViewCollar2 : Form,IViewCollar2
    {
        public ViewCollar2()
        {
            InitializeComponent();
        }

        public List<COLLAR2> CollarList
        {
            set { dataGVCollar2.DataSource = value; }
        }
        public event EventHandler<EventArgs> clickCollarList;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (clickCollarList != null)
            {
                clickCollarList(this, EventArgs.Empty);
            }
        }

        public new void Show()
        {
            Application.Run(this);
        }
    }
}
