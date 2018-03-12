using System;
using System.Collections.Generic;
using System.Text;
using STAF.Automation;
using STAF.Automation.Utility;

namespace STAF.Automation
{
    public static class Automation
    {


        public static void StartAutomation()
        {
            Invoker.InvokeMethods();
        }

        public static void AddLibrary(Object inLibrary)
        {
            Invoker.AddLibrary(inLibrary);
        }

    }
}
