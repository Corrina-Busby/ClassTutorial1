using System;
//using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
/// <summary>
/// sort by date needs looked at
/// </summary>
namespace Version_1_C
{
    public partial class frmArtist : Form
    {        
        public frmArtist()
        {
            InitializeComponent();
        }

        private clsWorksList _WorksList;
        private byte _SortOrder; // 0 = Name, 1 = Date

        private clsArtist _Artist;

        private void updateForm()
        {
            txtName.Text = _Artist.Name;
            txtSpeciality.Text = _Artist.Speciality;
            txtPhone.Text = _Artist.Phone;
            lblTotal.Text = _Artist.TotalValue.ToString();
            _WorksList = _Artist.WorksList;
     
            //_WorksList = _WorksList;
           // _SortOrder = _WorksList.SortOrder;
            updateDisplay();
        }

        private void pushData()
        {
            _Artist.Name = txtName.Text;
            _Artist.Speciality = txtSpeciality.Text;
            _Artist.Phone = txtPhone.Text;
            _WorksList.SortOrder = _WorksList.SortOrder;
        }

        private void updateDisplay()
        {
            txtName.Enabled = txtName.Text == "";
            txtName.Enabled = string.IsNullOrEmpty(_Artist.Name);
            if (_WorksList.SortOrder == 0)
            {
                _WorksList.SortByName();
                rbByName.Checked = true;
            }
            else
            {
                _WorksList.SortByDate();
                rbByDate.Checked = true;
            }

            lstWorks.DataSource = null;
            lstWorks.DataSource = _WorksList;
            lblTotal.Text = Convert.ToString(_WorksList.GetTotalValue());
        }

        public void SetDetails(clsArtist prArtist)
        {
            _Artist = prArtist;
            updateForm();
            updateDisplay();
            ShowDialog();
        }

        //public void GetDetails(ref string prName, ref string prSpeciality, ref string prPhone)
        //{
        //    prName = txtName.Text;
        //    prSpeciality = txtSpeciality.Text;
        //    prPhone = txtPhone.Text;
        //    _SortOrder = _WorksList.SortOrder;
        //}

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _WorksList.DeleteWork(lstWorks.SelectedIndex);
            updateDisplay();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _WorksList.AddWork();
            updateDisplay();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                pushData();
                DialogResult = DialogResult.OK;
            }
        }

        public virtual Boolean IsValid()
        {
            if (txtName.Enabled && txtName.Text != "")
                if (_Artist.IsDuplicate(txtName.Text))
                {
                    MessageBox.Show("Artist with that name already exists!");
                    return false;
                }
                else
                    return true;
            else
                return true;
        }

        private void lstWorks_DoubleClick(object sender, EventArgs e)
        {
            int lcIndex = lstWorks.SelectedIndex;
            if (lcIndex >= 0)
            {
                _WorksList.EditWork(lcIndex);
                updateDisplay();
            }
        }

        private void rbByDate_CheckedChanged(object sender, EventArgs e)
        {
            _WorksList.SortOrder = Convert.ToByte(rbByDate.Checked);
            updateDisplay();
        }

    }
}