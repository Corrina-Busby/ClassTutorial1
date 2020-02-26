using System;

namespace Version_1_C
{
    [Serializable()] 
    public class clsArtist
    {
        private string _Name;
        private string _Speciality;
        private string _Phone;
        
        private decimal _TotalValue;

        private clsWorksList _WorksList;
        private clsArtistList _ArtistList;
        
        private static frmArtist _ArtistDialog = new frmArtist();
        private byte _SortOrder;

        public clsArtist(clsArtistList prArtistList)
        {
            _WorksList = new clsWorksList();
            _ArtistList = prArtistList;
            EditDetails();
        }
        
        // open up the edit dialog if all OK returns details
        public void EditDetails() //(this)
        {
            _ArtistDialog.SetDetails(_Name, _Speciality, _Phone, _SortOrder, _WorksList, _ArtistList);
            if (_ArtistDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _ArtistDialog.GetDetails(ref _Name, ref _Speciality, ref _Phone, ref _SortOrder);
                _TotalValue = _WorksList.GetTotalValue();
            }
        }

        // get the artist name 
        // <returns> artist name
        public string GetKey()
        {
            return _Name;
        }

        // get the value of artworks
        // <returns> the total value of the artworks
        public decimal GetWorksValue()
        {
            return _TotalValue;
        }
    }
}
