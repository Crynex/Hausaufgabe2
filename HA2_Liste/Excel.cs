using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DocumentFormat.OpenXml.Presentation;
using OfficeOpenXml;

namespace HA2_Liste
{
    class Excel
    {
        public Excel()
        {
            Directory.SetCurrentDirectory(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName);
            Directory.SetCurrentDirectory(@"..\");
            Directory.SetCurrentDirectory(@"Excel_Tabellen");
        }
        public String[] Einlesen_Teams()
        {
            String[] teams = new String[18];
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo("Teams.xlsx")))
            {
                var sheet = package.Workbook.Worksheets[0]; // Tabelle
                for (int i = 0; i < 18; i++)
                {
                    teams[i] = sheet.Cells[i + 2, 1].Value.ToString();
                }

                //sheet.Cells[1, 1].Value = "Hellosfdsdfdsf World!"; // Schreiben


                //package.SaveAs(new FileInfo("Test.xlsx"));

                // Save to file
                //package.Save();            

            }
            return teams;
        }
        public void Schreibe_Spielplan(/*ArrayMitSpielpan*/)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo("Teams.xlsx")))
            {
                var sheet = package.Workbook.Worksheets["Spielplan"]; // Tabelle
                for (int i = 2; i < 20; i++)
                {
                    sheet.Cells[i, 2].Value = "FC Bayern";
                }

                //sheet.Cells[1, 1].Value = "Hellosfdsdfdsf World!"; // Schreiben
                //Console.WriteLine("|" + teams[17] + "|"); // Auslesen


                package.SaveAs(new FileInfo("Teams.xlsx"));

                // Save to file
                //package.Save();            

            }
        }
    }
}
