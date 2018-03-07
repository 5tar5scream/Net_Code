using System;
using System.Collections.Generic;
using System.Text;

namespace STAF.Automation.Utility
{
    public static class StringToConsole
    {

        private static List<string> lstToPrint = new List<string>();

        public static void PrintToConsole(string inString)
        {
            Console.WriteLine(inString);
        }

        public static void PrintToConsole(string[] inString)
        {
            int arrayLength = inString.Length;
            for (int i = 0; i < arrayLength; i++)
            {
                Console.WriteLine(inString[i]);
            }
        }

        public static void AddToListToPrint(string inString)
        {
            lstToPrint.Add(inString);
        }

        public static void PrintList()
        {
            foreach (string item in lstToPrint)
            {
                Console.WriteLine(item);
            }
            lstToPrint.Clear();
        }



    }
}
