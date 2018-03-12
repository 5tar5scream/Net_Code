using System;
using System.Collections.Generic;
using System.Text;

namespace STAF.Objects
{
    public class clsTestCase
    {
        #region fields
        private string attributeName;
        private string testDescription;
        private bool testIgnore;
        #endregion

        #region constructor
        public clsTestCase(string inAttributeName, string inTestDescription, bool inTestIgnore)
        {
            TestDescription = inTestDescription;
            TestIgnore = inTestIgnore;
            AttributeName = inAttributeName;
        }

        public clsTestCase() { }
        #endregion

        #region properties
        //you need visual studio 2017 for the following properties
        public string TestDescription { get => testDescription; set => testDescription = value; }
        public bool TestIgnore { get => testIgnore; set => testIgnore = value; }
        public string AttributeName { get => attributeName; set => attributeName = value; }
        #endregion
    }
}
