using System;
using System.Collections.Generic;
/// <summary>
/// DeleteWork needs reworked currently commented out for the meantime
/// </summary>

namespace Version_1_C
{
    [Serializable()] 
    public class clsWorksList : List<clsWork>
    {
        private static clsNameComparer _NameComparer = new clsNameComparer();
        private static clsDateComparer _DateComparer = new clsDateComparer();
        private byte _SortOrder;

        public byte SortOrder { get => _SortOrder; set => _SortOrder = value; }   

        public void AddWork()
        {
            clsWork lcWork = clsWork.NewWork();
            if (lcWork != null)
            {
                Add(lcWork);
            }
        }

        public void EditWork(int prIndex)
        {
            if (prIndex >= 0 && prIndex < this.Count)
            {
                clsWork lcWork = (clsWork)this[prIndex];
                lcWork.EditDetails();
            }
            else
            {
                 throw new Exception("Sorry no work selected #" + Convert.ToString(prIndex));
            }
        }

        public decimal GetTotalValue()
        {
            decimal lcTotal = 0;
            foreach (clsWork lcWork in this)
            {
                lcTotal += lcWork.Value;
            }
            return lcTotal;
        }

         public void SortByName()
         {
             Sort(_NameComparer);
            
         }
    
        public void SortByDate()
        {
            Sort(_DateComparer);
            
        }
    }
}
