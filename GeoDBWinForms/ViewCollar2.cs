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
        public ViewCollar2()
        {
            InitializeComponent();
        }

        // Collar interface
        #region Collar

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
        public event EventHandler<FilterParamsEventArgs> settedCollarFilter;
        public event EventHandler<NumRowEventArgs> showAnyCollarScreen;
        public event EventHandler<NumRowEventArgs> setCurrentRow;

    

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var ev = clickCollarData;
            if (ev != null)
            {
                ev(this, EventArgs.Empty);
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
            if (e.Button == MouseButtons.Left)
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
            else if (e.Button == MouseButtons.Right)
            {
                DataGridView s = sender as DataGridView;
                Rectangle rectangleHeader = s.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                Point contextMenuLocation = rectangleHeader.Location;
                contextMenuLocation.Offset(e.X, e.Y);
                ContextMenuStrip contextMenu = GetFilterContextMenu(e.ColumnIndex, settedCollarFilter);
                contextMenu.Show(s, contextMenuLocation);

            }

        }

        # endregion Collar



        // Assays interface
        #region Assays 

        public Dictionary<int, Assays2VmFull> AssaysList
        { private get; set; }
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
        public int sortedAssaysNumField { set; private get; }
        public LinqExtensionSorterCriterion.TypeCriterion
            SortedAssaysCriterion { set; private get; }
        public bool[] filteredAssaysNumField { set; private get; }

        public event EventHandler<EventArgs> clickAssaysData;
        public event EventHandler<NumSortedFieldEventArgs> clickAssaysHeader;
        public event EventHandler<NumRowEventArgs> showAnyAssaysScreen;
        public event EventHandler<FilterParamsEventArgs> settedAssaysFilter;


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
                int CollarID = (int)(dataGVCollar2[dataGVCollar2.Columns["ID"].Index, e.RowIndex].Value);
               setCurrentRow(this, new NumRowEventArgs(CollarID));
            }
        }
        private void dataGVAssays2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

                    if (filteredAssaysNumField[e.ColumnIndex])
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
                if (e.ColumnIndex == sortedAssaysNumField)
                {
                    Image imgSort;
                    Point ptSort = e.CellBounds.Location;
                    if (SortedAssaysCriterion == LinqExtensionSorterCriterion.TypeCriterion.Ascending)
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
        private void dataGVAssays2_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                LinqExtensionSorterCriterion.TypeCriterion temp;
                if (sortedAssaysNumField == e.ColumnIndex)
                {
                    if (SortedAssaysCriterion == LinqExtensionSorterCriterion.TypeCriterion.Ascending)
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
                var ev = clickAssaysHeader;
                if (ev != null)
                {
                    clickAssaysHeader(this, new NumSortedFieldEventArgs(e.ColumnIndex, temp));
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                DataGridView s = sender as DataGridView;
                Rectangle rectangleHeader = s.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                Point contextMenuLocation = rectangleHeader.Location;
                contextMenuLocation.Offset(e.X, e.Y);
                ContextMenuStrip contextMenu = GetFilterContextMenu(e.ColumnIndex, settedAssaysFilter);
                contextMenu.Show(s, contextMenuLocation);

            }

        }




        #endregion Assays // Assays interrface

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
        private ContextMenuStrip GetFilterContextMenu(int NumColumn, EventHandler<FilterParamsEventArgs> DelegateEvent)
        {
            ContextMenuStrip cm = new ContextMenuStrip();

            ToolStripMenuItem item1 = new ToolStripMenuItem("Фильтр - Интервал");
            ToolStripLabel item11 = new ToolStripLabel("От:");
            ToolStripTextBox item12 = new ToolStripTextBox();
            item12.BorderStyle = BorderStyle.FixedSingle;
            ToolStripLabel item13 = new ToolStripLabel("До:");
            ToolStripTextBox item14 = new ToolStripTextBox();
            item14.BorderStyle = BorderStyle.FixedSingle;
            ToolStripMenuItem item1_ok = new ToolStripMenuItem("Ок");
            item1_ok.Click += (i, a) =>
            {
                FilterParamsEventArgs param = new FilterParamsEventArgs(NumColumn, new LinqExtensionFilterCriterion(item12.Text, item14.Text));
                var ev = DelegateEvent;
                if (ev != null)
                {
                    DelegateEvent(this, param);
                }
            };

            item1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            item1.DropDownItems.Add(item11);
            item1.DropDownItems.Add(item12);
            item1.DropDownItems.Add(item13);
            item1.DropDownItems.Add(item14);
            item1.DropDownItems.Add(item1_ok);
            cm.Items.Add(item1);

            ToolStripMenuItem item2 = new ToolStripMenuItem("Фильтр - Значение");
            ToolStripLabel item21 = new ToolStripLabel("Равно:");
            ToolStripTextBox item22 = new ToolStripTextBox();
            item22.BorderStyle = BorderStyle.FixedSingle;

            ToolStripMenuItem item2_ok = new ToolStripMenuItem("Ок");
            item2_ok.Click += (i, a) =>
            {
                FilterParamsEventArgs param = new FilterParamsEventArgs(NumColumn, new LinqExtensionFilterCriterion(item22.Text));
                var ev = DelegateEvent;
                if (ev != null)
                {
                    ev(this, param);
                }
            };


            item2.DisplayStyle = ToolStripItemDisplayStyle.Text;
            item2.DropDownItems.Add(item21);
            item2.DropDownItems.Add(item22);
            item2.DropDownItems.Add(item2_ok);
            cm.Items.Add(item2);

            ToolStripMenuItem item3_cancel = new ToolStripMenuItem("Сброс");
            item3_cancel.Click += (i, a) =>
            {
                FilterParamsEventArgs param = new FilterParamsEventArgs(NumColumn, new LinqExtensionFilterCriterion());
                var ev = DelegateEvent;
                if (ev != null)
                {
                    ev(this, param);
                }
            };

            cm.Items.Add(item3_cancel);

            return cm;
        }
        private void btCloseForm_Click(object sender, EventArgs e)
        {
            if (clickCloseForm != null)
            {
                clickCloseForm(this, EventArgs.Empty);
            }
        }
        private void btShowData_Click(object sender, FilterParamsEventArgs e)
        {
            // settedCollarFilter(this, e);
        }

    }
}
