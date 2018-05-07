using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;
using STAF.CustomAttributes;
using STAF.Objects;

namespace STAF.Automation.Utility
{

    public static class Invoker
    {
        private static List<Object> lstTestLibaries = new List<object>();

        public static void InvokeMethods()
        {
            try
            {
                foreach (Object library in lstTestLibaries)
                {

                    var methods = library.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance)
                   .Where(
                            item => item.GetCustomAttributes(typeof(TestCase), false).Length > 0
                         );
                    foreach (var item in methods)
                    {
                        clsTestCase t = ObjectHelper.ConvertAttributeToObject(item);
                        if (!t.TestIgnore)
                        {
                            item.Invoke(library, new Object[0]);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void AddLibrary(Object inLibrary)
        {
            try
            {
                lstTestLibaries.Add(inLibrary);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
