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
    public partial class ViewAssays2Crud : Form,IViewAssays2Crud
    {

        public ViewAssays2Crud()
        {
            InitializeComponent();
        }

        public IView mdiParent
        {
            set
            {
                this.MdiParent = value as Form;
            }
        }
        public IView OwnerForm
        {
            private get;
            set;
        }

        private bool _readOnly;
        private bool readOnly 
        {
            set
            {
                var container = this.groupBox1.Controls;
                foreach (var c in container)
                {
                    Type cType= c.GetType();

                    if (cType == typeof(ComboBox))
                    {
                        (c as ComboBox).Enabled = !value;
                    }
                    if (cType == typeof(TextBox))
                    {
                        (c as TextBox).Enabled = !value;
                    }
                    if (cType == typeof(DateTimePicker))
                    {
                        (c as DateTimePicker).Enabled = !value;
                    }
                }
                _readOnly = value;
            }
            get { return _readOnly; }
        }

        public string Tittle 
        { 
            set
            {
                this.Text=value;
            }
        }
        public int bhid { get; set; }

        public string sample
        {
            get
            {
                return tbSample.Text.Trim();
            }
            set
            {
                tbSample.Text = value.Trim();
            }
        }

        public double? from_
        {
            get
            {
                return Convert.ToDouble(tbFrom.Text);
            }
            set
            {
                tbFrom.Text = value.ToString();
            }
        }

        public double? to
        {
            get
            {
                return Convert.ToDouble(tbTo.Text);
            }
            set
            {
                tbTo.Text = value.ToString();
            }
        }

        public double? length
        {
            get
            {
                return Convert.ToDouble(tbLength.Text);
            }
            set
            {
                tbLength.Text = value.ToString();
            }
        }

        public Dictionary<int, string> zblokList
        {
            set
            {

                cbZblok.DataSource = value.ToList();
                cbZblok.ValueMember = "Key";
                cbZblok.DisplayMember = "Value";
            }
        }
        public int? zblock
        {
            get
            {
                return (int?) cbZblok.SelectedValue;
            }
            set
            {
                cbZblok.SelectedValue = value ?? -1;
            }
        }

        public Dictionary<int, string> litoList
        {
            set
            {

                cbLito.DataSource = value.ToList();
                cbLito.ValueMember = "Key";
                cbLito.DisplayMember = "Value";
            }
        }
        public int? lito
        {
            get
            {
                return (int?)cbLito.SelectedValue;
            }
            set
            {
                cbLito.SelectedValue = value ?? -1;
            }
        }
        

        public Dictionary<int, string> rangList
        {
            set
            {
                cbRang.DataSource = value.ToList();
                cbRang.ValueMember = "Key";
                cbRang.DisplayMember = "Value";
            }

        }
        public int? rang
        {
            get
            {
                return (int?)cbRang.SelectedValue;
            }
            set
            {
                cbRang.SelectedValue = value ?? -1;
            }
        }

        public Dictionary<int, string> blankList
        {
            set
            {
                cbBlank.DataSource = value.ToList();
                cbBlank.ValueMember = "Key";
                cbBlank.DisplayMember = "Value";
            }
        }
        public int? blank
        {
            get
            {
                return (int?)cbBlank.SelectedValue;
            }
            set
            {
                cbBlank.SelectedValue = value ?? -1;
            }
        }

        public Dictionary<int, string> journalList
        {
            set
            {
                cbJournal.DataSource = value.ToList();
                cbJournal.ValueMember = "Key";
                cbJournal.DisplayMember = "Value";
            }
        }
        public int? journal
        {
            get
            {
                return (int?)cbJournal.SelectedValue;
            }
            set
            {
                cbJournal.SelectedValue = value ?? -1;
            }
        }

        public Dictionary<int, string> geologistList
        {
            set
            {
                cbGeologist.DataSource = value.ToList();
                cbGeologist.ValueMember = "Key";
                cbGeologist.DisplayMember = "Value";
            }
        }
        public int? geologist
        {
            get
            {
                return (int?)cbGeologist.SelectedValue;
            }
            set
            {
                cbGeologist.SelectedValue = value ?? -1;
            }
        }

        public Dictionary<string, string> pitList
        {
            set
            {
                cbPit .DataSource = value.ToList();
                cbPit.ValueMember = "Key";
                cbPit.DisplayMember = "Value";
            }
        }
        public string pit
        {
            get
            {
                return (string)cbPit.SelectedValue;
            }
            set
            {
                cbPit.SelectedValue = value;
            }
        }

        public DateTime end_date
        {
            get
            {
                return dtpEndDate.Value;
            }
            set
            {
                dtpEndDate.Value = value;
            }
        }


        public event EventHandler<EventArgs> clickOk;
        public event EventHandler<EventArgs> clickCloseForm;

        public  void Show(bool ReadOnly)
        {
            Form ownerForm = OwnerForm as Form;
            if (ownerForm == null) return;
            readOnly = ReadOnly;
            ownerForm.Enabled = false;
            this.Location = new System.Drawing.Point(ownerForm.Location.X + ownerForm.Width / 3, ownerForm.Location.Y + ownerForm.Height / 3);
            this.Show();
        }
        

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();  // further ViewCollar2Crud_FormClosing will trigered
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            this.ValidateChildren();
            bool canClicked = true;
            Control.ControlCollection container = (sender as Control).Parent.Controls;
            foreach (var c in container)
            { 
                
                String textError = errorProviderWarn.GetError((Control)c);
                if (!String.IsNullOrEmpty(textError))
                {
                    canClicked = false;
                }
            }
            var ev = clickOk;
            if (ev != null && canClicked)
            {
                ev(this, EventArgs.Empty);
            }
        }

        private void CheckIntValue(Control control)
        {
            if (readOnly)
                return;
            int result;
            string chekValue = control.Text;

            if (chekValue == string.Empty || chekValue.Trim().Length == 0)
            {
                errorProviderWarn.SetError(control, "Пожалуйста введите значение поля");
            }
            else if (!Int32.TryParse(chekValue, out result))
            {
                errorProviderWarn.SetError(control, "Введите целое число");
            }
            else
            {
                errorProviderWarn.SetError(control, "");
            }
        }
        private void tbHole_Validating(object sender, CancelEventArgs e)
        {
            Control checkControl = sender as Control;
            CheckIntValue(checkControl);
        }

        private void CheckDoubleValue(Control control)
        {
            if (readOnly)
                return;
            Double result;
            string chekValue = control.Text;

            if (chekValue == string.Empty || chekValue.Trim().Length == 0)
            {
                errorProviderWarn.SetError(control, "Пожалуйста введите значение поля");
            }
            else if (!Double.TryParse(chekValue, out result))
            {
                errorProviderWarn.SetError(control, "Введите число");
            }
            else
            {
                errorProviderWarn.SetError(control, "");
            }
        }
        private void tbX_Validating(object sender, CancelEventArgs e)
        {
            Control checkControl = sender as Control;
            CheckDoubleValue(checkControl);
        }

        private void CheckComboBoxValue(Control control)
        {
            if (readOnly)
                return;
            Int32 result;
            object obj = (control as ComboBox).SelectedValue ?? "null";
            string chekValue = obj.ToString();

            if (!Int32.TryParse(chekValue, out result))
            {
                errorProviderWarn.SetError(control, "Пожалуйста сделайте выбор");
            }
            else
            {
                errorProviderWarn.SetError(control, "");
            }
        }

        private void cbGorizont_Validating(object sender, CancelEventArgs e)
        {
            Control checkControl = sender as Control;
            CheckComboBoxValue(checkControl);
        }

        private void ViewAssays2Crud_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            var ev = clickCloseForm;
            if (ev != null)
            {
                ev(this, EventArgs.Empty);
            }
            Form ownerForm = OwnerForm as Form;
            if (ownerForm == null) return;
            ownerForm.Enabled = true;
            
        }
        
    }
}
