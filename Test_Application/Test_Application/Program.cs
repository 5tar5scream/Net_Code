﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using STAF.Automation;


namespace Test_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            //DummyTester t = new DummyTester();
            //t.ExecuteTests();
            TestLibrary.Mock_Tests.MockTest1 a = new TestLibrary.Mock_Tests.MockTest1();
            Automation.AddLibrary(a);
            Automation.StartAutomation();

        }

    }

}
