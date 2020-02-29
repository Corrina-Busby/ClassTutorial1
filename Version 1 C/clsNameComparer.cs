using System;
using System.Collections.Generic;

namespace Version_1_C
{
    class clsNameComparer : IComparer<clsWork>
    {
        public int Compare(clsWork x, clsWork y)
        { 
            string lcNameX = x.Name;
            string lcNameY = y.Name;

            return lcNameX.CompareTo(lcNameY);
        }
    }
}


//class clsNameComparer : IComparer
//{
//    public int Compare(Object x, Object y)
//    {
//        clsWork workClassX = (clsWork)x;
//        clsWork workClassY = (clsWork)y;
//        string lcNameX = workClassX.Name;
//        string lcNameY = workClassY.Name;

//        return lcNameX.CompareTo(lcNameY);
//    }
//}
