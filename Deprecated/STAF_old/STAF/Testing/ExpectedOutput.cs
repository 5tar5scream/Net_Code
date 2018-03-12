using System;
using System.Collections.Generic;
using System.Text;
using STAF.ENUMS;
using STAF.Objects;

namespace STAF.Testing
{
    public static class ExpectedOutput
    {
     

        public static bool CompareString(string inString, string inExpectedOutPut)
        {
            return inExpectedOutPut.Equals(inString);
        }

        public static bool CompareStringLength(int inStringLength, int inExpectedOutPutLength, clsEnums.Operand inExpectedOperand)
        {

            bool outCome = false;
            switch (inExpectedOperand)
            {
                case clsEnums.Operand.GREATER: if (inStringLength > inExpectedOutPutLength) { outCome = true; };
                    break;
                case clsEnums.Operand.LESS: if (inStringLength < inExpectedOutPutLength) { outCome = true; };
                    break;
                case clsEnums.Operand.EQUAL: if (inStringLength == inExpectedOutPutLength) { outCome = true; };
                    break;
                default: outCome = false;
                    break;
            }
            return outCome;
        }

        public static bool CompareStrings(string inString, string[] inStrings)
        {
            int arrayLength = inString.Length;
            
            for (int i = 0; i < arrayLength; i++)
            {
                if (inString.Equals(inStrings[i]))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
