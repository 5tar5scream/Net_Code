using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAF.ML
{
    public class InputHelper
    {
        public static string[] RetrieveInputs(string inInput, int inMax)
        {
            InitClassifier();
            string className = ClassifyInput(inInput);
            return Classifier.RetrieveInputsByClass(inInput,className, inMax);
        }

        public static string[] RetrieveInputs(string inInput)
        {
            InitClassifier();
            string className = ClassifyInput(inInput);
            return Classifier.RetrieveInputsByClass(inInput,className, 1);
        }

        private static void InitClassifier()
        {
            Classifier.StartClassification();
        }

        private static string ClassifyInput(string inInput)
        {
            return Classifier.ClassifyInput(inInput);
        }

        public static bool CheckIfExists(string inInput, string[][] inDataSet)
        {
            for (int i = 0; i < inDataSet.Length; i++)
            {
                if (inDataSet[i][0] == inInput)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
