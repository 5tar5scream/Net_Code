using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using STAF.Automation;
using STAF.Automation.Utility;
using STAF.ML;


namespace Test_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            TestLibrary.Mock_Tests.MockTest1 a = new TestLibrary.Mock_Tests.MockTest1();
            Automation.AddLibrary(a);
            Automation.StartAutomation();

           // Classifier.StartClassification();

        }

    }

}
