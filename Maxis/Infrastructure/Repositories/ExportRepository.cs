﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Maxis.Infrastructure.Repositories.Abstract;
using Excel = Microsoft.Office.Interop.Excel;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Data;
using Maxis.ViewModels;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Diagnostics;

namespace Maxis.Infrastructure.Repositories
{
    public class ExportRepository : IExportRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userViewModel"></param>
        /// <returns></returns>
        public bool ExportToExcel(List<UserViewModel> userViewModel)
        {
            try
            {
                string json = new JavaScriptSerializer().Serialize(userViewModel);
                DataTable dt = (DataTable)JsonConvert.DeserializeObject<DataTable>(json);
                EntityToExcelSheet("D:\\UserDetails.xls", "Users", dt);
                return true;
            }
            catch(Exception )
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userViewModel"></param>
        /// <returns></returns>
        public bool ExportToPdf(List<UserViewModel> userViewModel)
        {
            try
            {
                string json = new JavaScriptSerializer().Serialize(userViewModel);
                DataTable dt = (DataTable)JsonConvert.DeserializeObject<DataTable>(json);
                EntityToPdfDocument(dt);
                return true;
            }   
            catch (Exception )
            {
                return false;
    }
}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="excelFilePath"></param>
        /// <param name="sheetName"></param>
        /// <param name="dt"></param>
        private static void EntityToExcelSheet(string excelFilePath, string sheetName, DataTable dt)
        {
            Excel.Application oXL;
            Excel.Workbook oWB;
            Excel.Worksheet oSheet;
            Excel.Range oRange;
            try
            {
                // Start Excel and get Application object.
                oXL = new Excel.Application();

                // Set some properties
                oXL.Visible = true;
                oXL.DisplayAlerts = false;

                // Get a new workbook. 
                oWB = oXL.Workbooks.Add(Missing.Value);

                // Get the active sheet 
                oSheet = (Excel.Worksheet)oWB.ActiveSheet;
                oSheet.Name = sheetName;

                int rowCount = 1;
                foreach (DataRow dr in dt.Rows)
                {
                    rowCount += 1;
                    for (int i = 1; i < dt.Columns.Count + 1; i++)
                    {
                        // Add the header the first time through 
                        if (rowCount == 2)
                            oSheet.Cells[1, i] = dt.Columns[i - 1].ColumnName;
                        oSheet.Cells[rowCount, i] = dr[i - 1].ToString();
                    }
                }

                // Resize the columns 
                oRange = oSheet.Range[oSheet.Cells[1, 1], oSheet.Cells[rowCount, dt.Columns.Count]];
                oRange.Columns.AutoFit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        private static void EntityToPdfDocument(DataTable dt)
        {
            try
            {
                int i = 0; int yPoint = 0;
                
                string Username = null;
                string Email = null;
                string Mobile = null;
                string Department = null;
                string Title = null;
                string Role = null;
                string Status = null;

                PdfDocument pdf = new PdfDocument();
                pdf.Info.Title = "User Details";
                PdfPage pdfPage = pdf.AddPage();
                XGraphics graph = XGraphics.FromPdfPage(pdfPage);
                XFont font = new XFont("Verdana", 16, XFontStyle.Regular);

                yPoint = yPoint + 100;

                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    Username = dt.Rows[i].ItemArray[0].ToString();
                    Email = dt.Rows[i].ItemArray[1].ToString();
                    Mobile = dt.Rows[i].ItemArray[2].ToString();
                    Role = dt.Rows[i].ItemArray[3].ToString();
                    Department = dt.Rows[i].ItemArray[4].ToString();
                    Title = dt.Rows[i].ItemArray[5].ToString();                    
                    Status = dt.Rows[i].ItemArray[6].ToString();

                    graph.DrawString(Username, font, XBrushes.Black, new XRect(40, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(Email, font, XBrushes.Black, new XRect(90, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(Mobile, font, XBrushes.Black, new XRect(250, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(Role, font, XBrushes.Black, new XRect(350, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(Department, font, XBrushes.Black, new XRect(450, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(Title, font, XBrushes.Black, new XRect(550, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(Status, font, XBrushes.Black, new XRect(650, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    yPoint = yPoint + 40;
                }
                pdf.Save("D:\\pdfFilename");
                Process.Start("D:\\pdfFilename");

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
    }
}