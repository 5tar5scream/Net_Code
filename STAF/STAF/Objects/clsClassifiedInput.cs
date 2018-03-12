using System;
using System.Collections.Generic;
using System.Text;

namespace STAF.Objects
{
    public class clsClassifiedInput
    {

        #region fields
        private string input;
        private string[] attributes;
        private string type;
        #endregion

        #region constructors
        public clsClassifiedInput(string inInput, string[] inAttributes, string inType)
        {
            input = inInput;
            attributes = inAttributes;
            type = inType;
        }

        public clsClassifiedInput()
        {
            //empty constructor
        }
        #endregion


        //you need visual studio 2017 for these
        #region properties
        public string Input { get => input; set => input = value; }
        public string[] Attributes { get => attributes; set => attributes = value; }
        public string Type { get => type; set => type = value; }
        #endregion
    }
}
