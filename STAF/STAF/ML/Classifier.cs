﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using STAF.Objects;
using STAF.Automation.Utility;
using System.Diagnostics;
using System.Configuration;

namespace STAF.ML
{
    public static class Classifier
    {

        #region fields
        private static string[] ConvertedList;
        private static List<clsClassifiedInput> DataSet;
        private static List<clsClassifiedInput> MatchingRows = new List<clsClassifiedInput>();
        private static string Classification = "";
        private static double dsLength = 0;
        private static int matchCounter = 0;

        private static string[][] CompleteDS;
        private static string[][] TrainingSet;
        private static string[][] TestingSet;
        private static string[][] ShuffeledDS;

        private static double dataSplit = 0.80;

        private static int MaxConditions;
        private static int MaxRules;
        private static int AccuracyThreshold;
        private static int TrialTreshold;
        private static int CurrentTrial;

        private static List<int[]> GeneratedRules = new List<int[]>();
        private static Dictionary<string, int>[] lookupDictionary;


        #endregion

        //this method classifies the input using entire dataset instead of generating rules. It works fine but not very efficient on large datasets
        public static string ClassifyInput(string input, int accuracy)
        {
            ConvertedList = InputToArray(input);
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

        public static void StartClassification()
        {
            Setup();
            TrainData();
            PopulateLookupDictionary();
            GenerateRules();
            Debugger.Break();
        }

        #region Validation Functions
        private static string isNumberic(string input)
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
        public static string[] InputToArray(string input)
        {
            List<string> outList = new List<string>();

            outList.Add(isNumberic(input));
            outList.Add(isAlphaNumeric(input));
            outList.Add(isAlphabetical(input));
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

            string[] converted = outList.ToArray();
            return converted;
        }
        public static List<string> InputToList(string input)
        {
            List<string> outList = new List<string>();

            outList.Add(isNumberic(input));
            outList.Add(isAlphaNumeric(input));
            outList.Add(isAlphabetical(input));
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
            return outList;
        }
        #endregion

        #region misc functions
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
                //throw
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
        private static string[][] ShuffleArray(string[][] inOriginal)
        {
            Random rand = new Random(0);
            string[][] outArray = inOriginal; //check on this
            int arrayLength = outArray.Length;

            for (int i = 0; i < arrayLength; i++)
            {
                int nextNo = rand.Next(i, arrayLength);
                string[] Row = outArray[nextNo];
                outArray[nextNo] = outArray[i];
                outArray[i] = Row;
            }

            return outArray;
        }
        private static void CopyArrayData(string[][] inSecondaryArray, string[][] inPrimaryArray, int inStartIndex, int inLength)
        {
            for (int i = 0; i < inLength; i++)
            {
                inSecondaryArray[i] = inPrimaryArray[i+inStartIndex];
            }
        }
        #endregion

        #region Machine Learning
        private static void Setup()
        {
            try
            {
                MaxConditions = int.Parse(ConfigurationManager.AppSettings["MaxConditions"].ToString());
                AccuracyThreshold = int.Parse(ConfigurationManager.AppSettings["AccuracyThreshold"].ToString());
                MaxRules = int.Parse(ConfigurationManager.AppSettings["MaxRules"].ToString());
            }
            catch (Exception)
            {
                //use default;
                MaxConditions = 10;
                AccuracyThreshold = 90;
                MaxRules = 500;
            }
            finally
            {
                TrialTreshold = MaxRules * 10000;
            }
          
        }
        private static void TrainData()
        { 
            CompleteDS = CSVHelper.ReturnDataSetArray();

            int dsLength = CompleteDS.Length;
            int tsLength = (int)(dsLength * dataSplit);
            int tstLength = dsLength - tsLength;

            TrainingSet = new string[tsLength][];
            TestingSet = new string[tstLength][];

            //shuffle original ds
            ShuffeledDS = ShuffleArray(CompleteDS);

            //fill training and test sets
            CopyArrayData(TrainingSet, ShuffeledDS, 0, tsLength);
            CopyArrayData(TestingSet, ShuffeledDS, tsLength, tstLength);

            StringToConsole.PrintToConsole("TrainingSet");
            StringToConsole.Print(TrainingSet);
            StringToConsole.PrintToConsole("");
            StringToConsole.PrintToConsole("TestingSet");
            StringToConsole.Print(TestingSet);

            //Debugger.Break();

        }
        private static void GenerateRules()
        {
            int rowCount = TrainingSet.Length;
            int columnCount = TrainingSet[0].Length;
            Random random = new Random(0);
            CurrentTrial = 0;

            while (ValidateTrainingProgress())
            {
                CurrentTrial++;
                int[] tempRule = new int[MaxConditions * 2 + 1];
                int row = random.Next(0, rowCount);
                int[] selectedAttributes = SelectRandomAttributes(MaxConditions,columnCount-1);

                for (int i = 0; i < MaxConditions; i++)
                {
                    //get the next attribute column
                    int attributeCol = selectedAttributes[i];
                    string str = TrainingSet[row][attributeCol];
                    int digit = lookupDictionary[attributeCol][str];
                    tempRule[i * 2] = attributeCol;
                    tempRule[i * 2 + 1] = digit;
                }

                string xClass = TrainingSet[row][columnCount - 1];
                int xDigit = lookupDictionary[columnCount - 1][xClass];
                tempRule[MaxConditions * 2] = xDigit;

                //check for dupes
                if (GeneratedRules.Contains(tempRule))
                {
                    continue;
                }
                //check if they meet the threshold
                if (!ValidateAccuracy(tempRule))
                {
                    continue;
                }

                //rule good so save it
                int[] rule = tempRule;
                GeneratedRules.Add(rule);
            }

        }
        private static bool ValidateAccuracy(int[]inPotentialRule)
        {
            int rowCount = TrainingSet.Length;
            int columnCount = TrainingSet[0].Length;

            int pass = 0;
            int fail = 0;

            for (int i = 0; i < rowCount; i++)
            {

                if (!ValidateRule(inPotentialRule,TrainingSet[i]))
                {
                    continue;
                }

                int classCol = inPotentialRule[inPotentialRule.Length - 1];//get last value
                string classValue = TrainingSet[i][columnCount - 1];
                int x = lookupDictionary[columnCount - 1][classValue];
                if (classCol == x)
                {
                    pass++;
                }
                else
                {
                    fail++;
                }
            }
            if (CalculatePercentage(pass, (pass + fail)) < AccuracyThreshold)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private static bool ValidateRule (int[] inRule, string[] inAttributes)
        {
            //check if rule applies to the current row
            for (int i = 0; i < inRule.Length / 2; i++)//cut the length in half because of the rule format
            {
                int attributeValue = inRule[i * 2]; 
                int ruleValue = inRule[i * 2 + 1]; // rule value of the feature
                string dsValue = inAttributes[attributeValue]; 
                int dValue = lookupDictionary[attributeValue][dsValue];
                if (ruleValue != dValue)
                {
                    //not applicable rule
                    return false;
                }
            }
            return true;
        }
        private static void PopulateLookupDictionary()
        {
            int rowCount = TrainingSet.Length;
            int columnCount = TrainingSet[0].Length;
            lookupDictionary = new Dictionary<string, int>[columnCount];

            for (int i = 1; i < columnCount; i++)
            {
                lookupDictionary[i] = new Dictionary<string, int>();
                int index = 0;
                for (int j = 0; j < rowCount; j++)
                {
                    string value = TrainingSet[j][i];
                    if (lookupDictionary[i].ContainsKey(value) == false)
                    {
                        lookupDictionary[i].Add(value, index++);
                    }
                }
            }
        }
        private static bool ValidateTrainingProgress()
        {
            if (GeneratedRules.Count < MaxRules)
            {
                if (CurrentTrial < TrialTreshold)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private static int[] SelectRandomAttributes(int maxResults, int inColumnRange)
        {
            int[] outResult = new int[maxResults];
            int counter = 0;

            Random random = new Random(0);
            while (counter < (inColumnRange * 2))
            {
                List<int> SelectedAttributes = new List<int>();
                for (int i = 0; i < outResult.Length; i++)
                {
                    int col = random.Next(1, inColumnRange);
                    //dont accept duplicates
                    if (!SelectedAttributes.Contains(col))
                    {
                        outResult[i] = col;
                    }
                    else
                    {
                        break;
                    }
                }
                counter++;
            }

            Array.Sort(outResult);
            return outResult;
        }
        #endregion

    }
}
