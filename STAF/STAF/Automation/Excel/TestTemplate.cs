using System;
using System.Collections.Generic;
using STAF.Objects;
using STAF.Automation.Excel;
using System.Configuration;

namespace STAF.Automation.Excel
{
    public class TestTemplate
    {
        private List<clsTestResults> lstResults;
        private string filePath;
        private int rowCounter = 1;
        private int testCounter = 1;
        private string conditions = "";
        private int conditionCounter = 1;

        public TestTemplate(List<clsTestResults> inList, string inFilePath)
        {
            filePath = inFilePath;
            lstResults = inList;
            GenerateExcel();
        }

        public TestTemplate(List<clsTestResults> inList)
        {
            lstResults = inList;
            GenerateExcel2();
        }

        private void GenerateExcel()
        {
            ExcelMaker newExcel = new ExcelMaker();
            newExcel.createDoc();
            foreach (clsTestResults item in lstResults)
            {
                newExcel.createHeaders(rowCounter, 1, "Test Number", "A" + rowCounter, "A" + rowCounter, 0, "LIGHTGRAY", true, 14, "Black", 14);
                newExcel.addData(rowCounter, 2, testCounter.ToString(), "B" + rowCounter, "B" + rowCounter, "", false,11);
                rowCounter++;
                newExcel.createHeaders(rowCounter, 1, "Test Descripion", "A" + rowCounter, "A" + rowCounter, 0, "LIGHTGRAY", true, 14, "Black", 14);
                newExcel.addData(rowCounter, 2, item.Description, "B" + rowCounter, "B" + rowCounter, "", false,11);
                rowCounter++;
                newExcel.createHeaders(rowCounter, 1, "Test Input", "A" + rowCounter, "A" + rowCounter, 0, "LIGHTGRAY", true, 14, "Black", 14);
                newExcel.addData(rowCounter, 2, item.Input, "B" + rowCounter, "B" + rowCounter, "", false,11);
                rowCounter++;
                newExcel.createHeaders(rowCounter, 1, "Expected Output", "A" + rowCounter, "A" + rowCounter, 0, "LIGHTGRAY", true, 14, "Black", 14);
                newExcel.addData(rowCounter, 2, item.ExpectedOutput, "B" + rowCounter, "B" + rowCounter, "", false,11);
                rowCounter++;
                newExcel.createHeaders(rowCounter, 1, "Actual Output", "A" + rowCounter, "A" + rowCounter, 0, "LIGHTGRAY", true, 14, "Black", 14);
                newExcel.addData(rowCounter, 2, item.ActualOutput, "B" + rowCounter, "B" + rowCounter, "", false,11);
                rowCounter++;
                newExcel.createHeaders(rowCounter, 1, "Result", "A" + rowCounter, "A" + rowCounter, 0, "LIGHTGRAY", true, 14, "Black", 14);
                newExcel.addData(rowCounter, 2, item.Result, "B" + rowCounter, "B" + rowCounter, "", false,11);
                rowCounter++;
                testCounter++;
            }
            System.Threading.Thread.Sleep(5000);
            if (newExcel.SaveWorkBook("AutomationResults", filePath))
            {
                Console.WriteLine("Saved Excel");
            }
            else
            {
                Console.WriteLine("Failed to save excel");
            }

        }
        private void GenerateExcel2()
        {
            ExcelMaker newExcel = new ExcelMaker();
            newExcel.createDoc();
            foreach (clsTestResults item in lstResults)
            {
                newExcel.createHeaders(rowCounter, 1, "Test Number", "A" + rowCounter, "A" + rowCounter, 0, "LIGHTGRAY", true, 14, "Black",11);
                newExcel.addData(rowCounter, 2, testCounter.ToString(), "B" + rowCounter, "B" + rowCounter, "", false,11);
                rowCounter++;
                newExcel.createHeaders(rowCounter, 1, "Test Descripion", "A" + rowCounter, "A" + rowCounter, 0, "LIGHTGRAY", true, 14, "Black", 11);
                newExcel.addData(rowCounter, 2, item.Description, "B" + rowCounter, "B" + rowCounter, "", false,11);
                rowCounter++;
                newExcel.createHeaders(rowCounter, 1, "Test Input", "A" + rowCounter, "A" + rowCounter, 0, "LIGHTGRAY", true, 14, "Black", 11);
                newExcel.addData(rowCounter, 2, item.Input, "B" + rowCounter, "B" + rowCounter, "", false,11);
                rowCounter++;
                newExcel.createHeaders(rowCounter, 1, "Expected Output", "A" + rowCounter, "A" + rowCounter, 0, "LIGHTGRAY", true, 14, "Black", 11);
                foreach (clsCondition c in item.LstCondition)
                {
                    conditions += "Condition: " + conditionCounter + ". " + c.Condition + " Expected output is: " + c.ExpectedOutput;
                    if (item.LstCondition.Count > 1)
                    {
                        conditions += Environment.NewLine;
                    }
                    conditionCounter++;
                }
                //reset counter
                conditionCounter = 1;
                newExcel.addData(rowCounter, 2, conditions, "B" + rowCounter, "B" + rowCounter, "", false,11);
                rowCounter++;
                newExcel.createHeaders(rowCounter, 1, "Actual Output", "A" + rowCounter, "A" + rowCounter, 0, "LIGHTGRAY", true, 14, "Black", 11);
                conditions = "";
                foreach (clsCondition c in item.LstCondition)
                {
                    conditions += "Condition: " + conditionCounter + ". " + c.Condition + " Actual outcome is: " + c.Result;
                    if (item.LstCondition.Count > 1)
                    {
                        conditions += Environment.NewLine;
                    }
                    conditionCounter++;
                }
                //reset counter
                conditionCounter = 1;
                newExcel.addData(rowCounter, 2, conditions, "B" + rowCounter, "B" + rowCounter, "", false,11);
                rowCounter++;
                newExcel.createHeaders(rowCounter, 1, "Result", "A" + rowCounter, "A" + rowCounter, 0, "LIGHTGRAY", true, 14, "Black", 11);
                newExcel.addData(rowCounter, 2, item.Result, "B" + rowCounter, "B" + rowCounter, "", false,11);
                rowCounter+=2;
                testCounter++;
                conditions = "";
            }
            if (newExcel.SaveWorkBook("AutomationResults", ConfigurationManager.AppSettings["FilePath"].ToString()))
            {
                Console.WriteLine("Saved Excel");
            }
            else
            {
                Console.WriteLine("Failed to save excel");
            }

        }

    }
}
