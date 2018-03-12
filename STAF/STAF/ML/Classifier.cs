using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace STAF.ML
{
    public static class Classifier
    {
        public static string ClassifyInput(string input)
        {
            string Classification = "";
            List<string> outList = new List<string>();
            string[] ConvertedList;

            outList.Add(isNumberic(input));
            outList.Add(isAlphabetical(input));
            outList.Add(isAlphaNumeric(input));
            outList.Add(ContainsFullStop(input));
            outList.Add(ContainsAtSymbol(input));
            outList.Add(ContainsDotCom(input));
            outList.Add(ContainsWWW(input));
            outList.Add(LengthGreaterThan2(input));
            outList.Add(LengthGreaterThan5(input));
            outList.Add(LengthGreaterThan8(input));
            outList.Add(LengthGreaterThan11(input));
            outList.Add(LengthGreaterThan14(input));
            outList.Add(LengthGreaterThan17(input));
            outList.Add(LengthGreaterThan20(input));
            outList.Add(LengthLessThan2(input));
            outList.Add(LengthLessThan5(input));
            outList.Add(LengthLessThan8(input));
            outList.Add(LengthLessThan11(input));
            outList.Add(LengthLessThan14(input));
            outList.Add(LengthLessThan17(input));
            outList.Add(LengthLessThan20(input));
            outList.Add(ContainsWhiteSpace(input));
            outList.Add(ContainsComma(input));
            outList.Add(ContainsCurrencySymbol(input));
            outList.Add(ContainsDash(input));
            outList.Add(ContainsSlash(input));
            outList.Add(StartsWithPlus(input));

            ConvertedList = outList.ToArray();


            return Classification;
        }

        #region Validation Functions
        private static string isNumberic(string input)
        {
            int outNumber;
            bool flag = int.TryParse(input, out outNumber);
            if (flag)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        private static string isAlphabetical(string input)
        {
            if(Regex.IsMatch(input, @"^[a-zA-Z]+$"))
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        private static string isAlphaNumeric(string input)
        {
            if (Regex.IsMatch(input, @"^[a-zA-Z0-9]*$"))
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        private static string ContainsFullStop(string input)
        {
            if (input.Contains("."))
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        private static string ContainsAtSymbol(string input)
        {
            if (input.Contains("@"))
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        private static string ContainsDotCom(string input)
        {
            if ( input.ToLower().Contains(".com"))
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        private static string ContainsWWW(string input)
        {
            if (input.ToLower().Contains("www."))
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        private static string LengthGreaterThan2(string input)
        {
            if (input.Length > 2)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        private static string LengthGreaterThan5(string input)
        {
            if (input.Length > 5)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        private static string LengthGreaterThan8(string input)
        {
            if (input.Length > 8)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        private static string LengthGreaterThan11(string input)
        {
            if (input.Length > 11)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        private static string LengthGreaterThan14(string input)
        {
            if (input.Length > 14)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        private static string LengthGreaterThan17(string input)
        {
            if (input.Length > 17)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        private static string LengthGreaterThan20(string input)
        {
            if (input.Length > 20)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        private static string LengthLessThan2(string input)
        {
            if (input.Length < 2)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        private static string LengthLessThan5(string input)
        {
            if (input.Length < 5)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        private static string LengthLessThan8(string input)
        {
            if (input.Length < 8)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        private static string LengthLessThan11(string input)
        {
            if (input.Length < 11)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        private static string LengthLessThan14(string input)
        {
            if (input.Length < 14)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        private static string LengthLessThan17(string input)
        {
            if (input.Length < 17)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        private static string LengthLessThan20(string input)
        {
            if (input.Length < 20)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        private static string ContainsWhiteSpace(string input)
        {
            if (input.Contains(" "))
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        private static string ContainsComma(string input)
        {
            if (input.Contains(","))
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        private static string ContainsCurrencySymbol(string input)
        {
            if (input.Contains("$") || input.Contains("£") || input.Contains("€"))
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        private static string ContainsDash(string input)
        {
            if (input.Contains("-"))
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        private static string ContainsSlash(string input)
        {
            if (input.Contains("/"))
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        private static string StartsWithPlus(string input)
        {
            char[] letters = input.ToCharArray();
            if (input.Contains(letters[0].ToString()))
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        #endregion


    }
}
