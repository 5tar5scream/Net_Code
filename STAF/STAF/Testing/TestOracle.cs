using System;
using System.Collections.Generic;
using System.Text;
using STAF.Automation.Utility;
using STAF.Objects;

namespace STAF.Testing
{
    public static class TestOracle
    {


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

        public static void ValidateTestConditions()
        {
            bool currentTest = true;
            int counter = 1;

            foreach (clsCondition item in conditionList)
            {
                StringToConsole.AddToListToPrint("Condition: " + counter + ". " + item.Condition + " : Expected - " + item.ExpectedOutput + " and got - " + item.Input + ". Condition met = " + item.ActualOutCome.ToString());
                if (!item.ActualOutCome)
                {
                    currentTest = false;
                }
                counter++;
            }
            if (currentTest)
            {
                StringToConsole.AddToListToPrint("Test Passed");
            }
            else
            {
                StringToConsole.AddToListToPrint("Test Failed");
            }
            StringToConsole.PrintList();
            conditionList.Clear();
        }

    }
}
