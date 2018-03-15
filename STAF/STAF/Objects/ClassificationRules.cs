using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAF.Objects
{
    public class ClassificationRules
    {
        #region properties
        private static string column;
        private static int colValue;
        #endregion

        #region constructor
        public ClassificationRules(string inColumn, int inValue)
        {
            Column = inColumn;
            ColValue = inValue;
        }
        #endregion;

        //you need visual studio 2017 for these
        #region properties
        public static string Column { get => column; set => column = value; }
        public static int ColValue { get => colValue; set => colValue = value; }
        #endregion

    }
}
