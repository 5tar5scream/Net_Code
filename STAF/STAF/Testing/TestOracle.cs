using System;
using System.Collections.Generic;
using System.Text;
using STAF.Automation.Utility;
using STAF.Objects;
using STAF.Automation.Excel;

namespace STAF.Testing
{
    public static class TestOracle
    {
        private static List<clsTestResults> outResults = new List<clsTestResults>();

        private static List<clsCondition> conditionList = new List<clsCondition>();

        public static void AppendConditions(clsCondition inCondition)
        {
            conditionList.Add(inCondition);
        }

        public static List<clsCondition> ReturnConditionList()
        {
            return conditionList;
        }

        public static void ValidateTest(bool inActualOutcome, string inInput, string inExpectedOutput)
        {
            if (inActualOutcome)
            {
                StringToConsole.AddToListToPrint("Test Passed");
                StringToConsole.AddToListToPrint("Expected:" + inExpectedOutput);
                StringToConsole.AddToListToPrint("And got:" + inInput);
                StringToConsole.PrintList();
            }
            else
            {
                StringToConsole.AddToListToPrint("Test Failed");
                StringToConsole.AddToListToPrint("Expected:" + inExpectedOutput);
                StringToConsole.AddToListToPrint("And got:" + inInput);
                StringToConsole.PrintList();
            }
        }

        public static void ValidateTestConditions(string inDescription)
        {
            bool currentTest = true;
            int counter = 1;

            clsTestResults tR = new clsTestResults();
            tR.Description = inDescription;
            tR.Input = conditionList[0].Input;

            foreach (clsCondition item in conditionList)
            {
                StringToConsole.AddToListToPrint("Condition: " + counter + ". " + item.Condition + ". Input was- " + item.Input + " : Expected output was - " + item.ExpectedOutput + " Actual output was - " + item.Result + ". Condition met = " + item.Result.ToString());
                if (!item.Result)
                {
                    currentTest = false;
                }
                tR.LstCondition.Add(item);
                counter++;
            }
            if (currentTest)
            {
                StringToConsole.AddToListToPrint("Test Passed");
                tR.Result = "Pass";
            }
            else
            {
                StringToConsole.AddToListToPrint("Test Failed");
                tR.Result = "Fail";
            }
            outResults.Add(tR);
            StringToConsole.PrintList();
            conditionList.Clear();
        }

        public static void PrintResults()
        {
            TestTemplate template = new TestTemplate(outResults);
            outResults.Clear();
        }

    }
}
