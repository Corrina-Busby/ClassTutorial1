using System;
/// <summary>
///             "Move Field" _SortOrder to clsWorkslist - frmArtist Set and Get details ammended for the build
///             Bad code smell of long parameter lists - "Replace Parameter with Method"
///             Deleting the set methods for ArtistList, WorksList and TotalValue someohow makes them Readonly ...??? taking "set" away?
/// </summary>
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

        public string Name { get => _Name; set => _Name = value; }
        public string Speciality { get => _Speciality; set => _Speciality = value; }
        public string Phone { get => _Phone; set => _Phone = value; }
        public decimal TotalValue { get => _TotalValue; /*set => _TotalValue = value;*/ }  // delete or comment out makes readonly
        public clsWorksList WorksList { get => _WorksList; /* set => _WorksList = value;*/ }
        public clsArtistList ArtistList { get => _ArtistList; /* set => _ArtistList = value; */ }

        public clsArtist(clsArtistList prArtistList)
        {
            _WorksList = new clsWorksList();
            _ArtistList = prArtistList;
            EditDetails();
        }
        
        // edit details was simplified greatly since all the work of getting an setting the artist deets is now done by the form
        public void EditDetails()
        {
            _ArtistDialog.SetDetails(this);
            _TotalValue = _WorksList.GetTotalValue();            
        }

        //public string GetKey()
        //{
        //    return Name;
        //}

        //public decimal GetWorksValue()
        //{
        //    return TotalValue;
        //}
    }
}
