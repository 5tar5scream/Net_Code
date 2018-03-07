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
        [TestCase("Should print hello world but has an typo",false)]
        public void SayHelloWorld()
        {
            string input = "hello wrld";
            const string expectedOutPut = "hello world";


            clsCondition condition1 = new clsCondition(clsEnums.Condition.STRINGS_MATCH, input, expectedOutPut, ExpectedOutput.CompareString(input, expectedOutPut));
            TestOracle.AppendConditions(condition1);
            clsCondition condition2 = new clsCondition(clsEnums.Condition.STRING_LENGTH_EQUAL, input.Length, expectedOutPut.Length, ExpectedOutput.CompareStringLength(input.Length, expectedOutPut.Length,clsEnums.Operand.EQUAL));
            TestOracle.AppendConditions(condition2);
            TestOracle.ValidateTestConditions();


        }

        [TestCase("Should print hello world", false)]
        public void SayHelloWorld2()
        {
            string input = "hello world";
            const string expectedOutPut = "hello world";


            clsCondition condition1 = new clsCondition(clsEnums.Condition.STRINGS_MATCH, input, expectedOutPut, ExpectedOutput.CompareString(input, expectedOutPut));
            TestOracle.AppendConditions(condition1);
            clsCondition condition2 = new clsCondition(clsEnums.Condition.STRING_LENGTH_EQUAL, input.Length, expectedOutPut.Length, ExpectedOutput.CompareStringLength(input.Length, expectedOutPut.Length, clsEnums.Operand.EQUAL));
            TestOracle.AppendConditions(condition2);
            TestOracle.ValidateTestConditions();


        }
    }
}
