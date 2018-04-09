using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAF.Objects
{

    public class clsTestResults
    {
        private string description;
        private string input;
        private string expectedOutput;
        private string actualOutput;
        private string result;
        private List<clsCondition> lstCondition = new List<clsCondition>();

        public clsTestResults()
        {

        }

        public clsTestResults(string inDescription, string inInput, string inExptecOutput, string inActualOutput, string inResult, List<clsCondition> inConditons)
        {
            Description = inDescription;
            Input = inInput;
            ExpectedOutput = inExptecOutput;
            ActualOutput = inActualOutput;
            Result = inResult;
            LstCondition = inConditons;
        }

        //you need vs2017 for these
        public string Description { get => description; set => description = value; }
        public string Input { get => input; set => input = value; }
        public string ExpectedOutput { get => expectedOutput; set => expectedOutput = value; }
        public string ActualOutput { get => actualOutput; set => actualOutput = value; }
        public string Result { get => result; set => result = value; }
        public List<clsCondition> LstCondition { get => lstCondition; set => lstCondition = value; }
    }
}
