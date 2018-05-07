using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAF.Objects
{
    //** READ ME - This object is never used in the current version of the framework, however it is reserved for future development**//
    public class ClassificationRules
    {
        #region properties
        private static string column;
        private static int colValue;
        #endregion

        #region constructor
        //Main Constructor 
        public ClassificationRules(string inColumn, int inValue)
        {
            Column = inColumn;
            ColValue = inValue;
        }
        //Empty Constructor 
        public ClassificationRules()
        {
          //do nothing
        }
        #endregion;

        //you need visual studio 2017 for these
        #region properties
        public static string Column { get => column; set => column = value; }
        public static int ColValue { get => colValue; set => colValue = value; }
        #endregion

    }
}
