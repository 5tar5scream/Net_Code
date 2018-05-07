using System;
using System.Collections.Generic;
using System.Text;

namespace STAF.CustomAttributes
{
    public class TestCase : Attribute
    {

        #region fields
        private string testDescription;
        private bool testIgnore = false;
        #endregion


        #region constructors
        public TestCase(string inDescription, bool inTestIgnore)
        {
            testDescription = inDescription;
            testIgnore = inTestIgnore;
        }
        public TestCase()
        {
            //empty constructor
        }
        #endregion

        #region properties
        public virtual string Description
        {
            get { return testDescription; }
        }
        public virtual bool Ignore
        {
            get { return testIgnore; }
        }
        #endregion
    }
}
