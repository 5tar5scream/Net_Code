using System;
using Microsoft.VisualBasic.FileIO;
using STAF.Objects;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.IO;

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
                        string[] attributes = new string[output.Length - 2];
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

        public static string[][] ReturnDataSetArray()
        {
            try
            {
                string[][] outDataSet = new string[CountRows()][];
                using (TextFieldParser csvParser = new TextFieldParser(ConfigurationManager.AppSettings["DataSet"].ToString()))
                {
                    csvParser.TextFieldType = FieldType.Delimited;
                    csvParser.SetDelimiters(",");
                    int counter = 0;
                    while (!csvParser.EndOfData)
                    {
                        string[] output = csvParser.ReadFields();
                        outDataSet[counter] = output;
                        counter++;
                    }
                }
                return outDataSet;
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
            lst.RemoveAt(lst.Count - 1);
            return output = lst.ToArray();
        }

        public static void AppendToCSV(List<string> csvRow)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(ConfigurationManager.AppSettings["DataSet"].ToString(),append : true))
                {
                    StringBuilder builder = new StringBuilder();
                    int counter = 0;
                    foreach (string item in csvRow)
                    {
                        if (counter.Equals(csvRow.Count-1))
                        {
                            builder.Append(item);
                        }
                        else
                        {
                            builder.Append(item + ",");
                        }
                        counter++;
                    }
                    writer.WriteLine(builder.ToString());
                    writer.Flush();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); 
            }
        }
        
        private static int CountRows()
        {
            int outCount = 0;
            using (var reader = File.OpenText(ConfigurationManager.AppSettings["DataSet"].ToString()))
            {
                while (reader.ReadLine() != null)
                {
                    outCount++;
                }
            }
            return outCount;
        }
    }
}

