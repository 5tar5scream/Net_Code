using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace STAF.Automation.Excel
{
    public class ExcelMaker
    {
        private Microsoft.Office.Interop.Excel.Application ExcelApp = null;
        private Microsoft.Office.Interop.Excel.Workbook workBook1 = null;
        private Microsoft.Office.Interop.Excel.Worksheet workSheet1 = null;
        private Microsoft.Office.Interop.Excel.Range workSheetRange = null;
        private List<Microsoft.Office.Interop.Excel.Worksheet> lstWorksheets = null;
        private bool excelVisible;

        public ExcelMaker()
        {
            //createDoc();
        }

        public void createDoc()
        {
            try
            {
                ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                workBook1 = ExcelApp.Workbooks.Add(1);
                workSheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workBook1.Sheets[1];
                workSheet1.Name = "Sheet1";
                lstWorksheets = new List<Microsoft.Office.Interop.Excel.Worksheet>();
                lstWorksheets.Add(workSheet1);
                try
                {
                    excelVisible = Boolean.Parse(ConfigurationManager.AppSettings["ShowExcel"].ToString());
                    if (excelVisible)
                    {
                        ExcelApp.Visible = true;
                    }
                }
                catch (NullReferenceException)
                {
                    //do nothing
                }

                ExcelApp.DisplayAlerts = false;
            }
            catch (Exception)
            {
                Console.WriteLine("CreateDoc Error");
            }
        }

        public void createHeaders(int inRow, int inColumn, string inHeaderText, string inCell1, string inCell2, int inMergeColumns, string inBackGroundColor, bool inBold, int inSize, string inFontColor, int inFontSize)
        {
            workSheet1.Cells[inRow, inColumn] = inHeaderText;
            workSheetRange = workSheet1.Range[inCell1, inCell2];
            workSheetRange.Merge(inMergeColumns);


            switch (inBackGroundColor)
            {
                case "BEIGE":
                    workSheetRange.Interior.Color = System.Drawing.Color.Beige.ToArgb();
                    break;
                case "GRAY":
                    workSheetRange.Interior.Color = Color.FromArgb(221, 221, 221);
                    break;
                case "LIGHTGRAY":
                    workSheetRange.Interior.Color = Color.FromArgb(238, 238, 238);
                    break;
                case "BLACK":
                    workSheetRange.Interior.Color = Color.FromArgb(0, 0, 0);
                    break;
                default:
                    break;
            }

            workSheetRange.Font.Bold = inBold;
            workSheetRange.EntireColumn.AutoFit();
            workSheetRange.Font.Size = inFontSize;
            workSheetRange.Borders.Color = System.Drawing.Color.Black.ToArgb();
            workSheetRange.Font.Name = "Arial";
            if (inFontColor.Equals(""))
            {
                workSheetRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            }
            else
            {
                workSheetRange.Font.Color = System.Drawing.Color.Black.ToArgb();
            }
            workSheetRange.EntireColumn.AutoFit();
        }

        public void createHeadersMergeCenterBorder(int inRow, int inColumn, string inHeaderText, string inCell1, string inCell2, int inMergeColumns, string inBackGroundColor, bool inBold, int inSize, string inFontColor, int inFontSize)
        {
            workSheet1.Cells[inRow, inColumn] = inHeaderText;
            workSheetRange = workSheet1.Range[inCell1, inCell2];
            workSheetRange.Merge(inMergeColumns);
            workSheetRange.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;


            switch (inBackGroundColor)
            {
                case "BEIGE":
                    workSheetRange.Interior.Color = System.Drawing.Color.Beige.ToArgb();
                    break;
                case "GRAY":
                    workSheetRange.Interior.Color = Color.FromArgb(221, 221, 221);
                    break;
                case "LIGHTGRAY":
                    workSheetRange.Interior.Color = Color.FromArgb(238, 238, 238);
                    break;
                default:
                    break;
            }

            workSheetRange.Borders.Color = System.Drawing.Color.Black.ToArgb();
            workSheetRange.Font.Bold = inBold;
            workSheetRange.EntireColumn.AutoFit();
            workSheetRange.Font.Size = inFontSize;
            workSheetRange.Font.Name = "Arial";
            if (inFontColor.Equals(""))
            {
                workSheetRange.Font.Color = System.Drawing.Color.White.ToArgb();
            }
            else
            {
                workSheetRange.Font.Color = System.Drawing.Color.Black.ToArgb();
            }
            workSheetRange.EntireColumn.AutoFit();

        }

        public void addData(int inRow, int inCol, string inData, string inCell1, string inCell2, string inFormat, bool inBold, bool isDate, int inFontSize)
        {
            if (isDate)
            {
                workSheetRange = workSheet1.get_Range(inCell1, inCell2);
                workSheetRange.NumberFormat = "@";
                workSheet1.Cells[inRow, inCol] = inData;
                workSheetRange.Font.Bold = inBold;
                workSheetRange.Font.Size = inFontSize;
                workSheetRange.Borders.Color = System.Drawing.Color.Black.ToArgb();
                workSheetRange.Font.Name = "Arial";
                workSheetRange.EntireColumn.AutoFit();
            }
        }

        public void addData(int inRow, int inCol, string inData, string inCell1, string inCell2, string inFormat, bool inBold, int inFontSize)
        {
            workSheetRange = workSheet1.get_Range(inCell1, inCell2);
            workSheetRange.NumberFormat = inFormat;
            workSheet1.Cells[inRow, inCol] = inData;
            workSheetRange.Font.Bold = inBold;
            workSheetRange.Font.Size = inFontSize;
            workSheetRange.Font.Name = "Arial";
            workSheetRange.Borders.Color = System.Drawing.Color.Black.ToArgb();
            workSheetRange.ColumnWidth = 100;
        }

        public void addData(int inRow, int inCol, string inData, string inCell1, string inCell2, string inFormat, bool inBold, string inFontName, int inFontSize)
        {
            workSheetRange = workSheet1.get_Range(inCell1, inCell2);
            workSheetRange.NumberFormat = inFormat;
            workSheetRange.Font.Bold = inBold;
            workSheetRange.Font.Size = inFontSize;
            workSheet1.Cells[inRow, inCol] = inData;
            switch (inFontName)
            {
                case "Arial":
                    workSheetRange.Font.Name = "Arial";
                    break;
                case "Calibri":
                    workSheetRange.Font.Name = "Calibri";
                    break;
                default:
                    workSheetRange.Font.Name = "Times New Roman";
                    break;
            }
            workSheetRange.Borders.Color = System.Drawing.Color.Black.ToArgb();
            workSheetRange.EntireColumn.AutoFit();
        }

        public bool SaveWorkBook(string infriendlyName, string inFilePath)
        {
            try
            {
                string currentDate = DateTime.Now.ToString("MMddyyyyHHmmss");
                string filePath = inFilePath + infriendlyName + "_" + currentDate;

                workBook1.SaveAs(filePath, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, Type.Missing, Type.Missing,
                false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                workBook1.Close();
                Marshal.ReleaseComObject(workBook1);
                ExcelApp.Quit();
                if (ExcelApp != null) { Marshal.ReleaseComObject(ExcelApp); }

            }
        }

        public string GetSubstring(string inString, char inIndexOF)
        {
            int space = inString.IndexOf(inIndexOF);
            string result = inString.Substring(0, space);
            return result;
        }

        public void CloseWorkBook()
        {
            System.Threading.Thread.Sleep(5000);
            workBook1.Close();
            Marshal.ReleaseComObject(workBook1);
            ExcelApp.Quit();
            if (ExcelApp != null) { Marshal.ReleaseComObject(ExcelApp); }
        }

        public void ChangeWorkBookFont(string fontName)
        {
            ExcelApp.StandardFont = fontName;
        }

        public void AddWorkSheet(string inName)
        {
            int sheetCount = workBook1.Sheets.Count;
            int sheetIndex = sheetCount += 1;
            Microsoft.Office.Interop.Excel.Worksheet newWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook1.Worksheets.Add(After: workBook1.Sheets[workBook1.Sheets.Count]);
            newWorkSheet.Name = inName;
            lstWorksheets.Add(newWorkSheet);
        }

        public void CreateHeaderInWorkSheet(int inRow, int inColumn, string inHeaderText, string inCell1, string inCell2, int inMergeColumns, string inBackGroundColor, bool inBold, int inSize, string inFontColor, int inFontSize, int inWorkSheetIndex)
        {

            lstWorksheets[inWorkSheetIndex].Cells[inRow, inColumn] = inHeaderText;
            workSheetRange = lstWorksheets[inWorkSheetIndex].Range[inCell1, inCell2];
            workSheetRange.Merge(inMergeColumns);


            switch (inBackGroundColor)
            {
                case "BEIGE":
                    workSheetRange.Interior.Color = System.Drawing.Color.Beige.ToArgb();
                    break;
                case "GRAY":
                    workSheetRange.Interior.Color = Color.FromArgb(221, 221, 221);
                    break;
                case "LIGHTGRAY":
                    workSheetRange.Interior.Color = Color.FromArgb(238, 238, 238);
                    break;
                case "BLACK":
                    workSheetRange.Interior.Color = Color.FromArgb(0, 0, 0);
                    break;
                default:
                    break;
            }

            workSheetRange.Font.Bold = inBold;
            workSheetRange.EntireColumn.AutoFit();
            workSheetRange.Font.Size = inFontSize;
            workSheetRange.Font.Name = "Arial";
            if (inFontColor.Equals(""))
            {
                workSheetRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            }
            else
            {
                workSheetRange.Font.Color = System.Drawing.Color.Black.ToArgb();
            }
        }

        public void addDataInWorkSheet(int inRow, int inCol, string inData, string inCell1, string inCell2, string inFormat, bool inBold, string inFontName, int inFontSize, int inWorkSheetIndex)
        {
            workSheetRange = lstWorksheets[inWorkSheetIndex].get_Range(inCell1, inCell2);
            workSheetRange.NumberFormat = inFormat;
            workSheetRange.Font.Bold = inBold;
            workSheetRange.Font.Size = inFontSize;
            lstWorksheets[inWorkSheetIndex].Cells[inRow, inCol] = inData;
            switch (inFontName)
            {
                case "Arial":
                    workSheetRange.Font.Name = "Arial";
                    break;
                case "Calibri":
                    workSheetRange.Font.Name = "Calibri";
                    break;
                default:
                    workSheetRange.Font.Name = "Times New Roman";
                    break;
            }
            workSheetRange.EntireColumn.AutoFit();
        }

        public void ChangeDefaultSheetName(string inName)
        {
            workSheet1.Name = inName;
        }



    }
}
