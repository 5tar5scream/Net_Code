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
    public class MockTest2
    {
        //Attribute 
        [TestCase("Input Must Be Hello World", false)]
        public void SayHelloWorld2()
        {
            //initial input
            string input = "Not Hello World";
            //expected output
            const string ExpectedOutput = "Hello world";
            //setting max inputs
            int maxInputs = 5;
            //classifying initial input and retrieving auxiliary inputs
            string[] Inputs = InputHelper.RetrieveInputs(input, maxInputs);

            for (int i = 0; i < Inputs.Length; i++)
            {
                //getting actual outputs
                bool ActualOutputFirstCondition = ActualOutput.CompareString(Inputs[i], ExpectedOutput);
                bool ActualOutputSecondCondition = ActualOutput.CompareStringLength(Inputs[i].Length, ExpectedOutput.Length, clsEnums.Operand.EQUAL);
                //setting condition the input must match the expected output
                clsCondition condition1 = new clsCondition
                (
                  clsEnums.Condition.STRINGS_MATCH, //input and expected output must match
                  Inputs[i], //next input
                  ExpectedOutput, //the expected output
                  ActualOutputFirstCondition //the actual output
                );
                //setting up the condition that the input and expected output must have the same length
                clsCondition condition2 = new clsCondition
                (
                   clsEnums.Condition.STRING_LENGTH_EQUAL, //input and expected output length must be equal
                   Inputs[i].Length, //next input
                   ExpectedOutput.Length, //the expected output
                   ActualOutputSecondCondition //the actual output
                );
                //appending conditions
                TestOracle.AppendConditions(condition1);
                TestOracle.AppendConditions(condition2);
                //validating conditions
                TestOracle.ValidateTestConditions("Input Must Be Hello World");
            }
            //printing tests
            TestOracle.PrintResults();
        }
    }
}
