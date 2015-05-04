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
using System.Reflection;

namespace GeoDBWinForms
{
    public partial class ViewCollar2 : Form,IViewDrillHoles2
    {
        public ViewCollar2()
        {
            InitializeComponent();
        }

        public Dictionary<int, Collar2VmFull> CollarList
        {
            get;
            set;
        }

        public int rowCollarCount
        {
            set { dataGVCollar2.RowCount = value; }
            get { return dataGVCollar2.RowCount; }
        }
        public int minCollarRow { get; set; }
        public int maxCollarRow { get; set; }
        
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
        public event EventHandler<EventArgs> clickCollarData;
        
        public event EventHandler<EventArgs> clickCollarHeader;
        public event EventHandler<EventArgs> clickCollarFilters;
        public event EventHandler<EventArgs> showNextCollarScreen;
        public event EventHandler<EventArgs> showPrevCollarScreen;
        public event EventHandler<NumRowEventArgs> showAnyCollarScreen;
        public event EventHandler<NumRowEventArgs> setCurrentRow;
        public event EventHandler<EventArgs> openForm;
        public event EventHandler<EventArgs> clickCloseForm;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (clickCollarData != null)
            {
                clickCollarData(this, EventArgs.Empty);
            }
        }


        public new void Show()
        {
            Application.Run(this);
        }

        public void RefreshCollar()
        {
            dataGVCollar2.Refresh();
        }
        public void RefreshAssays()
        {
            dataGVAssays2.Refresh();
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
                if (showAnyCollarScreen != null)
                {
                    showAnyCollarScreen(this, new NumRowEventArgs(e.RowIndex));
                }
                

                if (CollarList.TryGetValue(e.RowIndex, out tmp))
                {
                    string propName = Collar2VmFull.header.ElementAt(e.ColumnIndex).fieldName;
                    e.Value = tmp.GetType().GetProperty(propName).GetValue(tmp, null);
                }
                
            }
        }


        public Dictionary<int, Assays2VmFull> AssaysList
        { get; set; }

        private void SetRowCountTo0()
        {
            dataGVAssays2.RowCount = 0;
        }
        delegate void dSetRowCountTo0();

        public int rowAssaysCount
        {
            set {dataGVAssays2.RowCount = value > 0 ? value : 1 ;}
            get { return dataGVAssays2.RowCount; }
        }
        public int minAssaysRow { get; set; }
        public int maxAssaysRow { get; set; }

        public List<DGVHeader> AssaysHeader
        {
            set
            {
                dataGVAssays2.Columns.Clear();
                foreach (var i in value)
                {
                    dataGVAssays2.Columns.Add(i.fieldName, i.fieldHeader);
                }
            }

        }

        public event EventHandler<EventArgs> clickAssaysData;

        public event EventHandler<EventArgs> clickAssaysHeader;
        public event EventHandler<EventArgs> clickAssaysFilters;
        public event EventHandler<EventArgs> showNextAssaysScreen;
        public event EventHandler<EventArgs> showPrevAssaysScreen;
        public event EventHandler<NumRowEventArgs> showAnyAssaysScreen;


        private void dataGVAssays2_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {

            Assays2VmFull tmp;
            if (AssaysList.TryGetValue(e.RowIndex, out tmp))
            {
                string propName = Assays2VmFull.header.ElementAt(e.ColumnIndex).fieldName;
                e.Value = tmp.GetType().GetProperty(propName).GetValue(tmp, null);
            }
            else
            {
             
                if (showAnyAssaysScreen != null)
                {
                    showAnyAssaysScreen(this, new NumRowEventArgs(e.RowIndex));
                }
           
                if (AssaysList.TryGetValue(e.RowIndex, out tmp))
                {
                    string propName = Assays2VmFull.header.ElementAt(e.ColumnIndex).fieldName;
                    e.Value = tmp.GetType().GetProperty(propName).GetValue(tmp, null);
                }

            }
        }

        private void dataGVCollar2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (setCurrentRow != null)
            {
               int  CollarID = (int)(dataGVCollar2[0, e.RowIndex].Value);
               setCurrentRow(this, new NumRowEventArgs(CollarID));
            }
        }

        private void btShowData_Click(object sender, EventArgs e)
        {
            clickCollarFilters(this, EventArgs.Empty);
        }

        private void dataGVCollar2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 && e.ColumnIndex == 0)
            {
                Image res = Properties.Resources.ResourceManager.GetObject("Very_Basic_Filter_Filled_icon") as Image;
                Point pt = e.CellBounds.Location;  // where you want the bitmap in the cell

                int offset = e.CellBounds.Width - res.Width;
                pt.X += offset;
                pt.Y += 2;
                Rectangle b = e.CellBounds;
                e.PaintBackground(b, true);
                e.Paint(b, DataGridViewPaintParts.ContentForeground);
                e.Graphics.DrawImage(res,new Rectangle(pt,new Size(15,15)));
                e.Handled = true;

            }
        }

    }
}
