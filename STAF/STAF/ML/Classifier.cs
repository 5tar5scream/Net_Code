using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using STAF.Objects;
using STAF.Automation.Utility;

namespace STAF.ML
{
    public static class Classifier
    {
        private static string[] ConvertedList;
        private static List<clsClassifiedInput> DataSet;
        private static List<clsClassifiedInput> MatchingRows = new List<clsClassifiedInput>();
        private static string Classification = "";
        private static double dsLength = 0;
        private static int matchCounter = 0;

        public static string ClassifyInput(string input, int accuracy)
        {
            
            List<string> outList = new List<string>();
            
            outList.Add(isNumberic(input));
            outList.Add(isAlphabetical(input));
            outList.Add(isAlphaNumeric(input));
            outList.Add(ContainsLetters(input));
            outList.Add(ContainsNumbers(input));
            outList.Add(ContainsSpecialCharacters(input));
            outList.Add(PercentageLettersGreaterThan25(input));
            outList.Add(PercentageLettersLessThan25(input));
            outList.Add(PercentageNumberGreaterThan25(input));
            outList.Add(PercentageNumberLessThan25(input));
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
            StringToConsole.PrintToConsole("input:" + input);
            StringToConsole.Print(ConvertedList);
            RetrieveDataSet();
            FilterMatchingRows(accuracy);
            foreach (clsClassifiedInput item in MatchingRows)
            {
                StringToConsole.PrintToConsole("input:" + item.Input);
                StringToConsole.Print(item.Attributes);
            }
            SelectMostProbableClass();
            StringToConsole.PrintToConsole(Classification);
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
        private static string ContainsLetters(string input)
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
        private static string ContainsNumbers(string input)
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
        private static string ContainsSpecialCharacters(string input)
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
        private static string PercentageLettersGreaterThan25(string input)
        {
            int length = input.Length;
            int counter = 0;
            char[] chars = input.ToCharArray();
            bool hasLetters;
            int outNumber;

            for (int i = 0; i < chars.Length; i++)
            {
                hasLetters = int.TryParse(chars[i].ToString(), out outNumber);
                if(!hasLetters)
                {
                    counter++;
                }
            }

            if(CalculatePercentage(counter, length) > 25)
            {
                return "1";
            }
            else
            {
                return "0";
            }

        }
        private static string PercentageLettersLessThan25(string input)
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

            if (CalculatePercentage(counter, length) < 25)
            {
                return "1";
            }
            else
            {
                return "0";
            }

        }
        private static string PercentageNumberGreaterThan25(string input)
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

            if (CalculatePercentage(counter, length) > 25)
            {
                return "1";
            }
            else
            {
                return "0";
            }

        }
        private static string PercentageNumberLessThan25(string input)
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

            if (CalculatePercentage(counter, length) < 25)
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

        #region ML functions
        private static void RetrieveDataSet()
        {
            DataSet = CSVHelper.ReadDataSet();
        }
        private static double CalculatePercentage(int digit)
        {
            return Math.Round(((digit / dsLength) * 100), 0);
        }
        private static double CalculatePercentage(int digit, int max)
        {
            return Math.Round((double)((digit / max) * 100), 0);
        }
        private static void FilterMatchingRows(int accuracy)
        {
            foreach (clsClassifiedInput row in DataSet)
            {

                matchCounter = 0;
                dsLength = row.Attributes.Length;
                for (int i = 0; i < row.Attributes.Length; i++)
                {
                    if (row.Attributes[i] == ConvertedList[i])
                    {
                        matchCounter++;
                    }
                }
                if (CalculatePercentage(matchCounter) >= accuracy)
                {
                    MatchingRows.Add(row);
                }

            }
        }
        private static void SelectMostProbableClass()
        {
            int mostOccurrences = 0;
            int counter = 0;
            string className = "";
            string chosenClass = "";

            try
            {
                foreach (clsClassifiedInput item in MatchingRows)
                {
                    if (className != item.Type || className == "")
                    {
                        className = item.Type;
                        counter = 0;
                        counter++;
                    }
                    else
                    {
                        counter++;
                        if (mostOccurrences < counter)
                        {
                            mostOccurrences = counter;
                            chosenClass = className;
                        }
                    }
                }

                Classification = chosenClass;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public static List<clsClassifiedInput> ReturnInputsByClass()
        {
            List<clsClassifiedInput> outList = new List<clsClassifiedInput>();
            foreach (clsClassifiedInput item in DataSet)
            {
                if (item.Type == Classification)
                {
                    outList.Add(item);
                }
            }
            return outList;
        }
        #endregion
    }
}
