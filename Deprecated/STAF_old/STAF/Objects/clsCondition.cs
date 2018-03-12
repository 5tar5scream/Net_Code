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
        private bool actualOutCome;
        #endregion


        #region constructor
        public clsCondition(clsEnums.Condition inCondition, string inInput, string inExpectedOutput, bool inActualOutcome)
        {
            condition = inCondition;
            Input = inInput;
            ExpectedOutput = inExpectedOutput;
            ActualOutCome = inActualOutcome;
        }

        public clsCondition(clsEnums.Condition inCondition, int inInput, int inExpectedOutput, bool inActualOutcome)
        {
            condition = inCondition;
            input = inInput.ToString();
            expectedOutput = inExpectedOutput.ToString();
            ActualOutCome = inActualOutcome;
        }

        public clsCondition()
        {
            // empty constructor
        }
        #endregion


        #region properties
        public clsEnums.Condition Condition { get => condition; set => condition = value; }
        public string Input { get => input; set => input = value; }
        public string ExpectedOutput { get => expectedOutput; set => expectedOutput = value; }
        public bool ActualOutCome { get => actualOutCome; set => actualOutCome = value; }
        #endregion
    }
}
