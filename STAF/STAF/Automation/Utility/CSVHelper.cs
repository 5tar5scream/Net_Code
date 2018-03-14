using System;
using Microsoft.VisualBasic.FileIO;
using STAF.Objects;
using System.Collections.Generic;
using System.Configuration;



namespace STAF.Automation.Utility
{
    public static class CSVHelper
    {

        public static List<clsClassifiedInput> ReadDataSet()
        {

            try
            {
                List<clsClassifiedInput> lstClassifiedInputs = new List<clsClassifiedInput>();
                using (TextFieldParser csvParser = new TextFieldParser(ConfigurationManager.AppSettings["DataSet"].ToString()))
                {
                    csvParser.TextFieldType = FieldType.Delimited;
                    csvParser.SetDelimiters(",");
                    while (!csvParser.EndOfData)
                    {
                        string[] output = csvParser.ReadFields();
                        string[] attributes = new string[output.Length-2];
                        clsClassifiedInput input = new clsClassifiedInput();
                        int counter = 0;
                        input.Input = output[0];
                        input.Type = output[output.Length - 1];
                        output = RemoveElements(output);
                        foreach (string row in output)
                        {
                            attributes[counter] = row;
                            counter++;
                        }
                        input.Attributes = attributes;
                        lstClassifiedInputs.Add(input);

                    }
                }
                return lstClassifiedInputs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private static string[] RemoveElements(string[] inElements)
        {
            List<string> lst = new List<string>(inElements);
            string[] output;
            lst.RemoveAt(0);
            lst.RemoveAt(lst.Count-1);
            return output = lst.ToArray();
        }
          
    }
}

