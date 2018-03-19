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
        #endregion
    }
}
