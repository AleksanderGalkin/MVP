using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GeoDB.Model;
using GeoDB.View;

namespace GeoDBWinForms
{
    public partial class ViewCollar2 : Form,IViewCollar2
    {
        public ViewCollar2()
        {
            InitializeComponent();
        }

        public List<Collar2VmFull> CollarList
        {
            get;
            set;
            //  set { dataGVCollar2.DataSource = value; }
            //  get { return dataGVCollar2.DataSource as List<Collar2VmFull>; }
        }

        public int rowCount
        {
            set { dataGVCollar2.RowCount = value; }
            get { return dataGVCollar2.RowCount; }
        }

        public List<DGVHeader> CollarHeader
        {
            set
            {
                dataGVCollar2.Columns.Clear();
                foreach (var i in value)
                {
                    dataGVCollar2.Columns.Add(i.fieldName, i.fieldHeader);
                }
            }
            
        }
        public event EventHandler<EventArgs> clickCollarList;
        public event EventHandler<EventArgs> clickCloseForm;
        public event EventHandler<EventArgs> clickHeader;
        public event EventHandler<EventArgs> clickFilters;
        public event EventHandler<EventArgs> showNextScreen;
        public event EventHandler<EventArgs> showPrevScreen;
        public event EventHandler<EventArgs> openForm;


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (clickCollarList != null)
            {
                clickCollarList(this, EventArgs.Empty);
            }
        }

        private void dataGridView1_CellContentClick2(object sender, DataGridViewCellEventArgs e)
        {
            if (showNextScreen != null)
            {
                showNextScreen(this, EventArgs.Empty);
            }
        }

        public new void Show()
        {
            Application.Run(this);
        }

        private void dataGVCollar2_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(e.RowIndex.ToString()+" ");
        }

        private void btCloseForm_Click(object sender, EventArgs e)
        {
            if (clickCloseForm != null)
            {
                clickCloseForm(this, EventArgs.Empty);
            }
        }


    }
}
