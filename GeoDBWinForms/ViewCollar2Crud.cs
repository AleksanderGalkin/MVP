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
    public partial class ViewCollar2Crud : Form,IViewCollar2Crud
    {

        public ViewCollar2Crud()
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
        private bool _readOnly 
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
                }
            }

        }

        public string Tittle 
        { 
            set
            {
                this.Text=value;
            }
        }
        public int id { get; set; }
        
        public Dictionary<int, string> gorizontList
        {
            set
            {

                cbGorizont.DataSource = value.ToList();
                cbGorizont.ValueMember = "Key";
                cbGorizont.DisplayMember = "Value";
            }
        }
        public int? gorizontID {
            get
            {
                return (int?) cbGorizont.SelectedValue;
            }
            set
            {
                cbGorizont.SelectedValue = value ?? -1;
            }
        }
        
        

        public Dictionary<int, string> blastList
        {
            set
            {
                cbBlast.DataSource = value.ToList();
                cbBlast.ValueMember = "Key";
                cbBlast.DisplayMember = "Value";
            }

        }
        public int? blast
        {
            get
            {
                return (int?)cbBlast.SelectedValue;
            }
            set
            {
                cbBlast.SelectedValue = value ?? -1;
            }
        }


        public int? hole 
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
        public double? xcollar 
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
        public double? ycollar
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
        public double? zcollar
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
        public double? enddepth
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
                cbDrillType.DataSource = value.ToList();
                cbDrillType.ValueMember = "Key";
                cbDrillType.DisplayMember = "Value";
            }
        }
        public int? drillType
        {
            get
            {
                return (int?)cbDrillType.SelectedValue;
            }
            set
            {
                cbDrillType.SelectedValue = value ?? -1;
            }
        }

        public Dictionary<int, string> domenList
        {
            set
            {
                cbDomen.DataSource = value.ToList();
                cbDomen.ValueMember = "Key";
                cbDomen.DisplayMember = "Value";
            }
        }
        public int? domenId
        {
            get
            {
                return (int?)cbDomen.SelectedValue;
            }
            set
            {
                cbDomen.SelectedValue = value ?? -1;
            }
        }
        public event EventHandler<EventArgs> clickOk;
        public event EventHandler<EventArgs> clickCloseForm;

        public  void Show(bool ReadOnly)
        {
            Form ownerForm = OwnerForm as Form;
            if (ownerForm == null) return;
            _readOnly = ReadOnly;
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

        private void ViewCollar2Crud_FormClosing(object sender, FormClosingEventArgs e)
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
