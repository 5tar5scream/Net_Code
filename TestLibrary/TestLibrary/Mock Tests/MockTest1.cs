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
        //Attribute
        [TestCase("Should print hello world but has an typo",false)]
        public void SayHelloWorld()
        {
            //initial input
            string input = "hello wrld";
            //expected output
            const string ExpectedOutput = "hello world";

            //Getting the actual outputs...
            bool ActualOutputFirstCondition = ActualOutput.CompareString(input, ExpectedOutput);
            bool ActualOutputSecondCondition = ActualOutput.CompareStringLength(input.Length, ExpectedOutput.Length, clsEnums.Operand.EQUAL);

            //conditon 1 input and expected output should match
            clsCondition condition1 = new clsCondition(clsEnums.Condition.STRINGS_MATCH, input, ExpectedOutput, ActualOutputFirstCondition);
            //conditon 2 input and expected put must have the same length
            clsCondition condition2 = new clsCondition(clsEnums.Condition.STRING_LENGTH_EQUAL, input.Length, ExpectedOutput.Length, ActualOutputSecondCondition);

            //appending conditions
            TestOracle.AppendConditions(condition1);
            TestOracle.AppendConditions(condition2);

            //validating the results
            TestOracle.ValidateTestConditions("Should print hello world but has an typo");
            //printing results
            TestOracle.PrintResults();
        }

        //Attribute 
        [TestCase("Should print hello world", false)]
        public void SayHelloWorld2()
        {
            //initial input
            string input = "hello world";
            //expected output
            const string ExpectedOutput = "hello world";
            //setting max inputs
            int maxInputs = 5;
            //classifying initial input and retrieving auxiliary inputs
            string[] Inputs = InputHelper.RetrieveInputs(input, maxInputs);

            for (int i = 0; i < Inputs.Length; i++)
            {
                //getting actual outputs
                bool ActualOutputFirstCondition = ActualOutput.CompareString(Inputs[i], ExpectedOutput);
                bool ActualOutputSecondCondition = ActualOutput.CompareStringLength(Inputs[i].Length, ExpectedOutput.Length, clsEnums.Operand.EQUAL);
                //setting conditions
                clsCondition condition1 = new clsCondition(clsEnums.Condition.STRINGS_MATCH, Inputs[i], ExpectedOutput, ActualOutputFirstCondition);
                clsCondition condition2 = new clsCondition(clsEnums.Condition.STRING_LENGTH_EQUAL, Inputs[i].Length, ExpectedOutput.Length, ActualOutputSecondCondition);
                //appending conditions
                TestOracle.AppendConditions(condition1);
                TestOracle.AppendConditions(condition2);
                //validating conditions
                TestOracle.ValidateTestConditions("Should print hello world"); 
            }
            //printing tests
            TestOracle.PrintResults();
        }

        //attribute
        [TestCase("Should be a number",false)]
        public void InsertNumber()
        {
            //initial input
            string input = "6000";
            //expected output
            const bool ExpectedOutput = true;
            //max retrieved inputs
            int maxInputs = 5;

            //classifying and retrieving all the inputs
            string[] Inputs = InputHelper.RetrieveInputs(input,maxInputs);

            //for every input generate an additional testcase
            for (int i = 0; i < Inputs.Length; i++)
            {

                //creating the condition for the testcase
                clsCondition condition1 = new clsCondition(clsEnums.Condition.IS_NUMERIC, Inputs[i], ExpectedOutput.ToString(), ActualOutput.AnalyzeNumber(Inputs[i], clsEnums.Condition.IS_NUMERIC));
                TestOracle.AppendConditions(condition1);
                //validating the condition
                TestOracle.ValidateTestConditions("Should be a number");
            }
            //printing the results
            TestOracle.PrintResults();
        }

        //attribute
        [TestCase("Should be a number but is a string", false)]
        public void InsertNumber2()
        {
            ////initial input
            string input = "HelloWorld";
            //expected output
            const bool ExpectedOutput = true;
            //max retrieved inputs
            int maxInputs = 2;

            //classifying and retrieving all the inputs
            string[] Inputs = InputHelper.RetrieveInputs(input, maxInputs);

            //for every input generate an additional testcase
            for (int i = 0; i < Inputs.Length; i++)
            {
                //getting actual output
                bool ActualOutputFirstCondition = ActualOutput.AnalyzeNumber(Inputs[i], clsEnums.Condition.IS_NUMERIC);
                //creating the condition for the testcase
                clsCondition condition1 = new clsCondition(clsEnums.Condition.IS_NUMERIC, Inputs[i], ExpectedOutput.ToString(), ActualOutputFirstCondition);
                TestOracle.AppendConditions(condition1);
                //validating the condition
                TestOracle.ValidateTestConditions("Should be a number but is a string");
            }
            TestOracle.PrintResults();
        }


    }
}
