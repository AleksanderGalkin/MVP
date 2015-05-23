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
    public partial class ViewDrillHoles : Form,IViewDrillHoles2
    {
        public ViewDrillHoles()
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
        

        public event EventHandler<NumSortedFieldEventArgs> clickCollarHeader;
        public event EventHandler<FilterParamsEventArgs> settedCollarFilter;
        public event EventHandler<NumRowEventArgs> showAnyCollarScreen;
        public event EventHandler<NumRowEventArgs> setCurrentRow;
        public event EventHandler<EventArgs> clickCollarCreateData;
        public event EventHandler<NumRowEventArgs> clickCollarEditData;
        public event EventHandler<NumRowEventArgs> clickCollarDeleteData;

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
        private void dataGVCollar2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
            }
            else if (e.Button == MouseButtons.Right && e.RowIndex != -1)
            {
                DataGridView s = sender as DataGridView;
                s.Rows[e.RowIndex].Selected = true;
                Rectangle rectangleHeader = s.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                Point contextMenuLocation = rectangleHeader.Location;
                contextMenuLocation.Offset(e.X, e.Y);
                ContextMenuStrip contextMenu = GetCollarDataContextMenu(e.RowIndex);
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
                    DataGridViewTextBoxColumn h = new DataGridViewTextBoxColumn();
                    h.Name = i.fieldName;
                    h.HeaderText = i.fieldHeader;
                    h.MinimumWidth = 40;
                    h.Width = i.fieldHeader.ToString().Length * 10;
                    dataGVAssays2.Columns.Add(h);
                }
            }

        }
        public int sortedAssaysNumField { set; private get; }
        public LinqExtensionSorterCriterion.TypeCriterion
            SortedAssaysCriterion { set; private get; }
        public bool[] filteredAssaysNumField { set; private get; }

        public event EventHandler<NumSortedFieldEventArgs> clickAssaysHeader;
        public event EventHandler<NumRowEventArgs> showAnyAssaysScreen;
        public event EventHandler<FilterParamsEventArgs> settedAssaysFilter;
        public event EventHandler<EventArgs> clickAssaysCreateData;
        public event EventHandler<NumRowEventArgs> clickAssaysEditData;
        public event EventHandler<NumRowEventArgs> clickAssaysDeleteData;

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

        private void dataGVAssays2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
            }
            else if (e.Button == MouseButtons.Right && e.RowIndex != -1)
            {
                DataGridView s = sender as DataGridView;
                s.Rows[e.RowIndex].Selected = true;
                Rectangle rectangleHeader = s.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                Point contextMenuLocation = rectangleHeader.Location;
                contextMenuLocation.Offset(e.X, e.Y);
                ContextMenuStrip contextMenu = GetAssaysDataContextMenu(e.RowIndex);
                contextMenu.Show(s, contextMenuLocation);

            }
        }


        #endregion Assays // Assays interrface

        public event EventHandler<EventArgs> clickCloseForm;

        public Form mdiParent 
        {
            set { this.MdiParent = value; }
        }
        public new  bool Enabled 
        {
            set { base.Enabled = value; }
        }
        public new void Show()
        {
          //  this.MdiParent = f;
             base.Show();
            //Application.Run(this);
            

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
        private ContextMenuStrip GetCollarDataContextMenu(int NumRow)
        {
            ContextMenuStrip cm = new ContextMenuStrip();
            ToolStripMenuItem item1 = new ToolStripMenuItem("Создать");
            
            item1.Click += (i, a) =>
            {
                
                var ev =clickCollarCreateData ;
                if (ev != null)
                {
                    ev(this, new NumRowEventArgs(0));
                }
            };
            item1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ToolStripMenuItem item2 = new ToolStripMenuItem("Редактировать");

            item2.Click += (i, a) =>
            {

                var ev = clickCollarEditData;
                if (ev != null)
                {
                    int CollarID = (int) (dataGVCollar2 [dataGVCollar2.Columns ["ID"] . Index, NumRow] . Value);
                    ev (this, new NumRowEventArgs (CollarID) );
                }
            };

            item2.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ToolStripMenuItem item3 = new ToolStripMenuItem("Удалить");

            item3.Click += (i, a) =>
            {

                var ev = clickCollarDeleteData;
                if (ev != null)
                {
                    int CollarID = (int)(dataGVCollar2[dataGVCollar2.Columns["ID"].Index, NumRow].Value);
                    ev(this, new NumRowEventArgs(CollarID));
                }
            };

            item3.DisplayStyle = ToolStripItemDisplayStyle.Text;

            cm.Items.Add(item1);
            cm.Items.Add(item2);
            cm.Items.Add(item3);
            return cm;
        }
        private ContextMenuStrip GetAssaysDataContextMenu(int NumRow)
        {
            ContextMenuStrip cm = new ContextMenuStrip();
            ToolStripMenuItem item1 = new ToolStripMenuItem("Создать");

            item1.Click += (i, a) =>
            {

                var ev = clickAssaysCreateData;
                if (ev != null)
                {
                    ev(this, EventArgs.Empty);
                }
            };
            item1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ToolStripMenuItem item2 = new ToolStripMenuItem("Редактировать");

            item2.Click += (i, a) =>
            {

                var ev = clickAssaysEditData;
                if (ev != null)
                {
                    int AssaysID = (int)(dataGVAssays2[dataGVAssays2.Columns["ID"].Index, NumRow].Value);
                    ev(this, new NumRowEventArgs(AssaysID));
                }
            };

            item2.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ToolStripMenuItem item3 = new ToolStripMenuItem("Удалить");

            item3.Click += (i, a) =>
            {

                var ev = clickAssaysDeleteData;
                if (ev != null)
                {
                    int AssaysID = (int)(dataGVAssays2[dataGVAssays2.Columns["ID"].Index, NumRow].Value);
                    ev(this, new NumRowEventArgs(AssaysID));
                }
            };

            item3.DisplayStyle = ToolStripItemDisplayStyle.Text;

            cm.Items.Add(item1);
            cm.Items.Add(item2);
            cm.Items.Add(item3);
            return cm;
        }
        private void btCloseForm_Click(object sender, EventArgs e)
        {
            if (clickCloseForm != null)
            {
                clickCloseForm(this, EventArgs.Empty);
            }
        }

        private void ViewDrillHoles_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            var ev = clickCloseForm;
            if (ev != null)
            {
                ev(this, EventArgs.Empty);
            }
        }


        private bool _maximazed = false;
        private bool _clickedMaxNorm = false;
        private Size _normalSize;
        private Point _normalLocation;
        private void ViewDrillHoles_Resize(object sender, EventArgs e)
        {
            if (_clickedMaxNorm)
            {
                if (_maximazed)
                {

                    WindowState = FormWindowState.Normal;
                    this.Dock = DockStyle.Fill;
                }
                else
                {

                    WindowState = FormWindowState.Normal;
                    this.Dock = DockStyle.None;
                    this.Location = _normalLocation;
                    this.SetClientSizeCore(_normalSize.Width, _normalSize.Height);
                }
                _clickedMaxNorm = false;
            }
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0112) 
            {
                if (m.WParam == new IntPtr(0xF030) && !_maximazed) // Maximize event - SC_MAXIMIZE from Winuser.h
                {
                    _maximazed = true;
                    _normalSize = this.Size;
                    _normalLocation = this.Location;
                    _clickedMaxNorm = true;

                } else if (m.WParam == new IntPtr(0xF030) && _maximazed) // Maximize event - SC_MAXIMIZE from Winuser.h
                {
                    _maximazed = false;
                    _clickedMaxNorm = true;
                }
                //if (m.WParam == new IntPtr(0xF120) || m.WParam == new IntPtr(0xF020)) // event - SC_RESTORE or SC_MINIMIZE from Winuser.h
                //{
                //   // _clickedMaxMin = true;
                //}
            }
            base.WndProc(ref m);
        }
        

    }
}
