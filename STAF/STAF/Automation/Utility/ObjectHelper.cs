using System;
using System.Collections.Generic;
using System.Text;
using STAF.Objects;
using System.Reflection;
using STAF.CustomAttributes;

namespace STAF.Automation.Utility
{
    public static class ObjectHelper
    {
        public static clsTestCase ConvertAttributeToObject(Object inObject)
        {
            try
            {
                clsTestCase clsTest = new clsTestCase();
                MethodInfo t = (MethodInfo)inObject;
                object[] attributes = t.GetCustomAttributes(true);
                foreach (object item in attributes)
                {
                    TestCase tc = item as TestCase;
                    clsTest = new clsTestCase();
                    if (tc != null)
                    {
                        clsTest.TestDescription = tc.Description;
                        clsTest.TestIgnore = tc.Ignore;
                    }
                }
                return clsTest;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
