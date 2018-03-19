using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace STAF.Automation.Utility
{
    public static class ValidationHelper
    {
        #region Validation Functions
        public static string isNumeric(string input)
        {
            int outNumber;
            double outNumber2;
            bool flag = int.TryParse(input, out outNumber);
            if (!flag)
            {
                flag = double.TryParse(input, out outNumber2);
            }
            if (flag)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        public static string isAlphabetical(string input)
        {
            if (Regex.IsMatch(input, @"^[a-zA-Z]+$"))
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        public static string isAlphaNumeric(string input)
        {

            bool containsLetters = false;
            bool containsDigits = false;
            int outNumber;

            char[] chars = input.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                if (Regex.IsMatch(chars[i].ToString(), @"^[a-zA-Z]+$"))
                {
                    containsLetters = true;
                }
            }
            for (int j = 0; j < chars.Length; j++)
            {
                containsDigits = int.TryParse(chars[j].ToString(), out outNumber);
                if (containsDigits)
                {
                    break;
                }
            }

            if (containsLetters && containsDigits)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        public static string ContainsLetters(string input)
        {
            bool containsLetters = false;

            char[] chars = input.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                if (Regex.IsMatch(chars[i].ToString(), @"^[a-zA-Z]+$"))
                {
                    containsLetters = true;
                    break;
                }

            }
            if (containsLetters)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        public static string ContainsNumbers(string input)
        {
            bool containsNumbers = false;
            int outNumber = 0;

            char[] chars = input.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                containsNumbers = int.TryParse(chars[i].ToString(), out outNumber);
                if (containsNumbers)
                {
                    break;
                }
            }
            if (containsNumbers)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        public static string ContainsSpecialCharacters(string input)
        {
            if (!Regex.IsMatch(input, @"^[a-zA-Z0-9 ]*$"))
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        public static string PercentageLettersGreaterThan25(string input)
        {
            int length = input.Length;
            int counter = 0;
            char[] chars = input.ToCharArray();
            bool hasLetters;
            int outNumber;

            for (int i = 0; i < chars.Length; i++)
            {
                hasLetters = int.TryParse(chars[i].ToString(), out outNumber);
                if (!hasLetters)
                {
                    counter++;
                }
            }

            if (Generic.CalculatePercentage(counter, length) > 25)
            {
                return "1";
            }
            else
            {
                return "0";
            }

        }
        public static string PercentageLettersLessThan25(string input)
        {
            int length = input.Length;
            int counter = 0;
            char[] chars = input.ToCharArray();
            bool hasLetters;
            int outNumber;

            for (int i = 0; i < chars.Length; i++)
            {
                hasLetters = int.TryParse(chars[i].ToString(), out outNumber);
                if (!hasLetters)
                {
                    counter++;
                }
            }

            if (Generic.CalculatePercentage(counter, length) < 25)
            {
                return "1";
            }
            else
            {
                return "0";
            }

        }
        public static string PercentageNumberGreaterThan25(string input)
        {
            int length = input.Length;
            int counter = 0;
            char[] chars = input.ToCharArray();
            bool hasNumbers;
            int outNumber;

            for (int i = 0; i < chars.Length; i++)
            {
                hasNumbers = int.TryParse(chars[i].ToString(), out outNumber);
                if (hasNumbers)
                {
                    counter++;
                }
            }

            if (Generic.CalculatePercentage(counter, length) > 25)
            {
                return "1";
            }
            else
            {
                return "0";
            }

        }
        public static string PercentageNumberLessThan25(string input)
        {
            int length = input.Length;
            int counter = 0;
            char[] chars = input.ToCharArray();
            bool hasNumbers;
            int outNumber;

            for (int i = 0; i < chars.Length; i++)
            {
                hasNumbers = int.TryParse(chars[i].ToString(), out outNumber);
                if (hasNumbers)
                {
                    counter++;
                }
            }

            if (Generic.CalculatePercentage(counter, length) < 25)
            {
                return "1";
            }
            else
            {
                return "0";
            }

        }
        public static string ContainsFullStop(string input)
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
        public static string ContainsAtSymbol(string input)
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
        public static string ContainsDotCom(string input)
        {
            if (input.ToLower().Contains(".com"))
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        public static string ContainsWWW(string input)
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
        public static string LengthGreaterThan2(string input)
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
        public static string LengthGreaterThan5(string input)
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
        public static string LengthGreaterThan8(string input)
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
        public static string LengthGreaterThan11(string input)
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
        public static string LengthGreaterThan14(string input)
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
        public static string LengthGreaterThan17(string input)
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
        public static string LengthGreaterThan20(string input)
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
        public static string LengthLessThan2(string input)
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
        public static string LengthLessThan5(string input)
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
        public static string LengthLessThan8(string input)
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
        public static string LengthLessThan11(string input)
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
        public static string LengthLessThan14(string input)
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
        public static string LengthLessThan17(string input)
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
        public static string LengthLessThan20(string input)
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
        public static string ContainsWhiteSpace(string input)
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
        public static string ContainsComma(string input)
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
        public static string ContainsCurrencySymbol(string input)
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
        public static string ContainsDash(string input)
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
        public static string ContainsSlash(string input)
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
        public static string StartsWithPlus(string input)
        {
            char[] letters = input.ToCharArray();
            if (letters[0] == '+')
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
