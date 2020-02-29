using System;
using System.Collections.Generic;

using System.Runtime.Serialization.Formatters.Binary;

namespace Version_1_C
{
    [Serializable()] 
    public class clsArtistList : SortedList<string, clsArtist>
    {
        private const string _FileName = "gallery.xml";

        public void EditArtist(string prKey)
        {
            clsArtist lcArtist;
            lcArtist = (clsArtist)this[prKey];
            if (lcArtist != null)
                lcArtist.EditDetails();
            else
                throw new Exception("Sorry no artist by this name");
        }
       
        public void NewArtist()
        {
            clsArtist lcArtist = new clsArtist(this);
            try
            {
                if (lcArtist.Name != "")
                {
                    Add(lcArtist.Name, lcArtist);           
                }
            }
            catch (Exception)
            {
                throw new Exception("Duplicate Key!");
            }
        }
        
        public decimal GetTotalValue()
        {
            decimal lcTotal = 0;
            foreach (clsArtist lcArtist in Values)
            {
                lcTotal += lcArtist.TotalValue;
            }
            return lcTotal;
        }

        public void Save()
        {
       
                System.IO.FileStream lcFileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Create);
                BinaryFormatter lcFormatter =
                    new BinaryFormatter();

                lcFormatter.Serialize(lcFileStream, this);
                lcFileStream.Close();
       
        }

        public static clsArtistList Retrieve()
        {
            clsArtistList lcArtistList;
            try
            {
                System.IO.FileStream lcFileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Open);
                BinaryFormatter lcFormatter =
                    new BinaryFormatter();

                lcArtistList = (clsArtistList)lcFormatter.Deserialize(lcFileStream);

                lcFileStream.Close();
            }

            catch (Exception e)
            {
                lcArtistList = new clsArtistList();     
            }
            return lcArtistList;
        }
    }
}
