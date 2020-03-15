using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

/// <summary>
/// Matthias Otto, NMIT, 2010-2016 
///                                  "Move Method" Save n Retrieve and 'Move Field" _FileName to clsArtistList 
/// </summary>

namespace Version_1_C
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        // removed the instanciation from of clsArtistList 
        private clsArtistList _ArtistList;

        private void updateDisplay()
        {
            string[] lcDisplayList = new string[_ArtistList.Count];

            lstArtists.DataSource = null;
            _ArtistList.Keys.CopyTo(lcDisplayList, 0);
            lstArtists.DataSource = lcDisplayList;
            lblValue.Text = Convert.ToString(_ArtistList.GetTotalValue());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ArtistList.NewArtist();
            updateDisplay();
        }

        private void lstArtists_DoubleClick(object sender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstArtists.SelectedItem);
            if (lcKey != null)
            {
                _ArtistList.EditArtist(lcKey);
                updateDisplay();
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        { // member to prefix save w/ _ArtistList adjusting methods from the "Move Method"
            _ArtistList.Save();
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstArtists.SelectedItem);
            if (lcKey != null)
            {
                lstArtists.ClearSelected();
                _ArtistList.Remove(lcKey);
                updateDisplay();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            _ArtistList = clsArtistList.RetrieveArtistList();
            updateDisplay();
        }
    }
}