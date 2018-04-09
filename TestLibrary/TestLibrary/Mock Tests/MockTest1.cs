using System;
using System.Collections.Generic;
using System.Text;
using STAF.CustomAttributes;
using STAF.Testing;
using STAF.Objects;
using STAF.ENUMS;
using STAF.ML;

namespace TestLibrary.Mock_Tests
{

    [TestClass("MockClass1",false)]
    public class MockTest1
    {
        [TestCase("Should print hello world but has an typo",false)]
        public void SayHelloWorld()
        {
            string input = "hello wrld";
            const string ExpectedOutput = "hello world";


            clsCondition condition1 = new clsCondition(clsEnums.Condition.STRINGS_MATCH, input, ExpectedOutput, ActualOutput.CompareString(input, ExpectedOutput));
            clsCondition condition2 = new clsCondition(clsEnums.Condition.STRING_LENGTH_EQUAL, input.Length, ExpectedOutput.Length, ActualOutput.CompareStringLength(input.Length, ExpectedOutput.Length,clsEnums.Operand.EQUAL));

            TestOracle.AppendConditions(condition1);
            TestOracle.AppendConditions(condition2);

            TestOracle.ValidateTestConditions("Should print hello world but has an typo");
            TestOracle.PrintResults();

        }

        [TestCase("Should print hello world", false)]
        public void SayHelloWorld2()
        {

            string input = "hello world";
            const string ExpectedOutput = "hello world";
            int maxInputs = 5;
            string[] Inputs = InputHelper.RetrieveInputs(input, maxInputs);



            for (int i = 0; i < Inputs.Length; i++)
            {
                clsCondition condition1 = new clsCondition(clsEnums.Condition.STRINGS_MATCH, Inputs[i], ExpectedOutput, ActualOutput.CompareString(Inputs[i], ExpectedOutput));
                clsCondition condition2 = new clsCondition(clsEnums.Condition.STRING_LENGTH_EQUAL, Inputs[i].Length, ExpectedOutput.Length, ActualOutput.CompareStringLength(Inputs[i].Length, ExpectedOutput.Length, clsEnums.Operand.EQUAL));

                TestOracle.AppendConditions(condition1);
                TestOracle.AppendConditions(condition2);

                TestOracle.ValidateTestConditions("Should print hello world"); 
            }
            TestOracle.PrintResults();
        }


        [TestCase("Should be a number",false)]
        public void InsertNumber()
        {
            string input = "6000";
            const bool ExpectedOutput = true;
            int maxInputs = 5;

            string[] Inputs = InputHelper.RetrieveInputs(input,maxInputs);

            for (int i = 0; i < Inputs.Length; i++)
            {
                clsCondition condition1 = new clsCondition(clsEnums.Condition.IS_NUMERIC, Inputs[i], ExpectedOutput.ToString(), ActualOutput.AnalyzeNumber(Inputs[i], clsEnums.Condition.IS_NUMERIC));
                TestOracle.AppendConditions(condition1);
                TestOracle.ValidateTestConditions("Should be a number");
            }
            TestOracle.PrintResults();
        }

    }
}
