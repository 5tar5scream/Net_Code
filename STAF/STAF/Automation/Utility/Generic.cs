using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAF.Automation.Utility
{
    public static class Generic
    {
        #region functions
        public static double CalculatePercentage(int digit, int max)
        {

            double ans = Math.Round((double)((digit / max) * 100), 0);
            return ans;
        }
        public static double CalculatePercentage(double digit, double max)
        {
            double ans = (digit / max) * 100;
            return ans;
        }
        public static bool StringToBool(string inString)
        {
            if (inString.Equals("1"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<string> ArrayToList(string[] inArray)
        {
            List<string> outList = new List<string>();
            for (int i = 0; i < inArray.Length; i++)
            {
                outList.Add(inArray[i]);
            }
            return outList;
        }

        public static string[] AppendToArray(string inFirstValue, string inLastValue, string[]inMiddleValues)
        {
            string[] outArray = new string[inMiddleValues.Length + 2];
            outArray[0] = inFirstValue;
            outArray[outArray.Length - 1] = inLastValue;
            for (int i = 0; i < inMiddleValues.Length; i++)
            {
                outArray[i + 1] = inMiddleValues[i];
            }
            return outArray;
        }
        #endregion
    }
}
