using System;
using System.Collections.Generic;
using System.Text;
using STAF.CustomAttributes;
using STAF.Testing;
using STAF.Objects;
using STAF.ENUMS;

namespace TestLibrary.Mock_Tests
{

    [TestClass("MockClass1",false)]
    public class MockTest1
    {
        [TestCase("Should print hello world but has an typo",true)]
        public void SayHelloWorld()
        {
            string input = "hello wrld";
            const string ExpectedOutput = "hello world";


            clsCondition condition1 = new clsCondition(clsEnums.Condition.STRINGS_MATCH, input, ExpectedOutput, ActualOutput.CompareString(input, ExpectedOutput));
            clsCondition condition2 = new clsCondition(clsEnums.Condition.STRING_LENGTH_EQUAL, input.Length, ExpectedOutput.Length, ActualOutput.CompareStringLength(input.Length, ExpectedOutput.Length,clsEnums.Operand.EQUAL));

            TestOracle.AppendConditions(condition1);
            TestOracle.AppendConditions(condition2);

            TestOracle.ValidateTestConditions();

        }

        [TestCase("Should print hello world", true)]
        public void SayHelloWorld2()
        {

            string input = "hello world";
            const string ExpectedOutput = "hello world";


            clsCondition condition1 = new clsCondition(clsEnums.Condition.STRINGS_MATCH, input, ExpectedOutput, ActualOutput.CompareString(input, ExpectedOutput));
            clsCondition condition2 = new clsCondition(clsEnums.Condition.STRING_LENGTH_EQUAL, input.Length, ExpectedOutput.Length, ActualOutput.CompareStringLength(input.Length, ExpectedOutput.Length, clsEnums.Operand.EQUAL));

            TestOracle.AppendConditions(condition1);
            TestOracle.AppendConditions(condition2);

            TestOracle.ValidateTestConditions();
        }


        [TestCase("Should be a number",false)]
        public void InsertNumber()
        {
            string input = "6000";
            const bool ExpectedOutput = true;

            clsCondition condition1 = new clsCondition(clsEnums.Condition.IS_NUMERIC, input, ExpectedOutput.ToString(), ActualOutput.AnalyzeNumber(input, clsEnums.Condition.IS_NUMERIC));

            TestOracle.AppendConditions(condition1);
            TestOracle.ValidateTestConditions();
        }

    }
}
