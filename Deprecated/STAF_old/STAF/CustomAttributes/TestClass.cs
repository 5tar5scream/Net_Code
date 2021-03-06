﻿using System;
using System.Collections.Generic;
using System.Text;

namespace STAF.CustomAttributes
{
    public class TestClass : Attribute
    {
        #region fields
        private string className;
        private bool classIgnore;
        #endregion

        #region constructors
        public TestClass(string inclassName, bool inclassIgnore)
        {
            className = inclassName;
            classIgnore = inclassIgnore;
        }
        public TestClass()
        {
            //empty constructor
        }
        #endregion

        #region properties
        public virtual string Name
        {
            get { return className; }
        }
        public virtual bool Ignore
        {
            get { return classIgnore; }
        }
        #endregion
    }
}
