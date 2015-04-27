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

        public Dictionary<int, Collar2VmFull> CollarList
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
        public int minShowedRow { get; set; }
        public int maxShowedRow { get; set; }
        
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
        public event EventHandler<NumRowEventArgs> showAnyScreen;
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


        private void btCloseForm_Click(object sender, EventArgs e)
        {
            if (clickCloseForm != null)
            {
                clickCloseForm(this, EventArgs.Empty);
            }
        }

        private void dataGVCollar2_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {

            Collar2VmFull tmp;
            if (CollarList.TryGetValue(e.RowIndex, out tmp))
            {
                string propName = Collar2VmFull.header.ElementAt(e.ColumnIndex).fieldName;
                e.Value = tmp.GetType().GetProperty(propName).GetValue(tmp, null);
            }
            else
            {
                if (e.RowIndex == maxShowedRow+1)
                {
                    if (showNextScreen != null)
                    {
                        showNextScreen(this, EventArgs.Empty);
                    }
                }
                else if (e.RowIndex == minShowedRow-1)
                {
                    if (showPrevScreen != null)
                    {
                        showPrevScreen(this, EventArgs.Empty);
                    }
                }
                else
                {
                    if (showAnyScreen != null)
                    {
                        showAnyScreen(this, new NumRowEventArgs (e.RowIndex));
                    }
                }

                if (CollarList.TryGetValue(e.RowIndex, out tmp))
                {
                    string propName = Collar2VmFull.header.ElementAt(e.ColumnIndex).fieldName;
                    e.Value = tmp.GetType().GetProperty(propName).GetValue(tmp, null);
                }
                
            }
        }


    }
}
