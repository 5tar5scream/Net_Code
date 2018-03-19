using System;
using System.Collections.Generic;
using System.Text;
using STAF.ENUMS;

namespace STAF.Objects
{
    public class clsCondition
    {

        #region fields
        private clsEnums.Condition condition;
        private string input;
        private string expectedOutput;
        private bool result;
        #endregion


        #region constructor
        public clsCondition(clsEnums.Condition inCondition, string inInput, string inExpectedOutput, bool inActualOutcome)
        {
            condition = inCondition;
            Input = inInput;
            ExpectedOutput = inExpectedOutput;
            Result = inActualOutcome;
        }

        public clsCondition(clsEnums.Condition inCondition, int inInput, int inExpectedOutput, bool inActualOutcome)
        {
            condition = inCondition;
            input = inInput.ToString();
            expectedOutput = inExpectedOutput.ToString();
            Result = inActualOutcome;
        }

        public clsCondition()
        {
            // empty constructor
        }
        #endregion


        //you need visual studio 2017
        #region properties
        public clsEnums.Condition Condition { get => condition; set => condition = value; }
        public string Input { get => input; set => input = value; }
        public string ExpectedOutput { get => expectedOutput; set => expectedOutput = value; }
        public bool Result { get => result; set => result = value; }
        #endregion
    }
}
