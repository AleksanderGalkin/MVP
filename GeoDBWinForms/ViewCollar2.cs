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
using GeoDB.Extensions;

namespace GeoDBWinForms
{
    public partial class ViewCollar2 : Form,IViewDrillHoles2
    {
        // Collar interface
        #region Collar
        public ViewCollar2()
        {
            InitializeComponent();
        }
        public Dictionary<int, Collar2VmFull> CollarList
        {private  get; set;}
        public int rowCollarCount
        {
            set { dataGVCollar2.RowCount = value; }
            private get { return dataGVCollar2.RowCount; }
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
        public int sortedCollarNumField { set; private get; }
        public LinqExtensionSorterCriterion.TypeCriterion
            SortedCollarCriterion { set; private get; }
        public bool[] filteredCollarNumField { set; private get; }
        

        public event EventHandler<EventArgs> clickCollarData;
        public event EventHandler<NumSortedFieldEventArgs> clickCollarHeader;
        public event EventHandler<EventArgs> clickCollarFilters;
        public event EventHandler<NumRowEventArgs> showAnyCollarScreen;
        public event EventHandler<NumRowEventArgs> setCurrentRow;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (clickCollarData != null)
            {
                clickCollarData(this, EventArgs.Empty);
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
        # endregion Collar

        public event EventHandler<EventArgs> openForm;
        public event EventHandler<EventArgs> clickCloseForm;
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


        // Assays interface
        #region Assays 

        public Dictionary<int, Assays2VmFull> AssaysList
        { private get; set; }

        private void SetRowCountTo0()
        {
            dataGVAssays2.RowCount = 0;
        }
        delegate void dSetRowCountTo0();

        public int rowAssaysCount
        {
            set {dataGVAssays2.RowCount = value > 0 ? value : 1 ;}
            private get { return dataGVAssays2.RowCount; }
        }

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

        public int sortedAssaysNumfield { set; private get; }
        public LinqExtensionSorterCriterion.TypeCriterion
            SortedAssaysCriterion { set; private get; }

        public event EventHandler<EventArgs> clickAssaysData;

        public event EventHandler<NumSortedFieldEventArgs> clickAssaysHeader;
        public event EventHandler<EventArgs> clickAssaysFilters;
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


        private void dataGVCollar2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.RowIndex < 0 && e.ColumnIndex > -1)
            {

               
                int width = e.CellBounds.Width;
                Rectangle b = e.CellBounds;
                e.PaintBackground(b, true);
                e.Paint(b, DataGridViewPaintParts.ContentForeground);
                {
                    Image imgFilter;
                    Point ptFilter = e.CellBounds.Location;

                    if (filteredCollarNumField[e.ColumnIndex])
                    {
                        imgFilter = Properties.Resources.ResourceManager.GetObject("Very_Basic_Filter_Filled_icon") as Image;
                    }
                    else
                    {
                        imgFilter = Properties.Resources.ResourceManager.GetObject("Very_Basic_Filter_Not_Filled") as Image;
                    }
                    int offsetFilter = width - imgFilter.Width;
                    width = offsetFilter;
                    ptFilter.X += offsetFilter;
                    ptFilter.Y += 2;
                    e.Graphics.DrawImage(imgFilter, new Rectangle(ptFilter, new Size(15, 15)));
                }
                if (e.ColumnIndex == sortedCollarNumField)
                {
                    Image imgSort;
                    Point ptSort = e.CellBounds.Location;
                    if (SortedCollarCriterion == LinqExtensionSorterCriterion.TypeCriterion.Ascending)
                    {
                        imgSort = Properties.Resources.ResourceManager.GetObject("Very_Basic_ArrowUp_icon") as Image;
                    }
                    else
                    {
                        imgSort = Properties.Resources.ResourceManager.GetObject("Very_Basic_ArrowDown_icon") as Image;
                    }
                    int offsetSort = width - imgSort.Width;
                    ptSort.X += offsetSort;
                    ptSort.Y += 2;
                    e.Graphics.DrawImage(imgSort, new Rectangle(ptSort, new Size(15, 15)));
                }
                e.Handled = true;
                
            }
        }

        private void dataGVCollar2_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            LinqExtensionSorterCriterion.TypeCriterion temp;
            if (sortedCollarNumField == e.ColumnIndex)
            {
                if (SortedCollarCriterion == LinqExtensionSorterCriterion.TypeCriterion.Ascending)
                {
                    temp = LinqExtensionSorterCriterion.TypeCriterion.Descending;
                }
                else
                {
                    temp = LinqExtensionSorterCriterion.TypeCriterion.Ascending;
                }
            }
            else
            {
                temp = LinqExtensionSorterCriterion.TypeCriterion.Ascending;
            }
            clickCollarHeader(this, new NumSortedFieldEventArgs(e.ColumnIndex, temp));
        }
        #endregion Assays // Assays interrface
    }
}
