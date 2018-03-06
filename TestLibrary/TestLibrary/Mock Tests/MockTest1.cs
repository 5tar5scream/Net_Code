using System;
using System.Collections.Generic;
using System.Text;
using STAF.CustomAttributes;

namespace TestLibrary.Mock_Tests
{

    [TestClass("MockClass1",false)]
    public class MockTest1
    {
        [TestCase("Should print hello world",false)]
        public void SayHelloWorld()
        {
            Console.WriteLine("hello world");
        }
    }
}
