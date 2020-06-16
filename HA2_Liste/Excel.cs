using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Presentation;
using OfficeOpenXml;

namespace HA2_Liste
{
    class Excel
    {
        private Ergebnisse ergebnisse;
        public Spiel Mannschaft;
        public Excel()
        {
            Directory.SetCurrentDirectory(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName);
            Directory.SetCurrentDirectory(@"..\");
            Directory.SetCurrentDirectory(@"Excel_Tabellen");
            ergebnisse = new Ergebnisse();
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
        public void Schreibe_Spielplan(String[] teams, int[,,] spiele)
        {
            //Zeilenr.
            int z = 2;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo("Teams.xlsx")))
            {
                var sheet = package.Workbook.Worksheets["Spielplan"]; // Tabelle
                for (int i = 1; i < 35; i++)
                {
                    for (int k = 0; k < 9; k++)
                    {
                        sheet.Cells[z, 1].Value = i;
                        sheet.Cells[z, 2].Value = k + 1;
                        sheet.Cells[z, 3].Value = teams[spiele[i, k, 0] - 1];
                        sheet.Cells[z, 4].Value = this.Mannschaft.Tore;
                        sheet.Cells[z, 5].Value = teams[spiele[i, k, 1] - 1];
                        sheet.Cells[z, 6].Value = 

                        z++;
                    }

                    z++;
                }

                //sheet.Cells[1, 1].Value = "Hellosfdsdfdsf World!"; // Schreiben
                //Console.WriteLine("|" + teams[17] + "|"); // Auslesen


                package.SaveAs(new FileInfo("Teams.xlsx"));

                // Save to file
                //package.Save();            

            }
        }

        public void Schreibe_Tabelle()
        {
            //Zeilenr.
            int z = 1;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo("Teams.xlsx")))
            {
                var sheet = package.Workbook.Worksheets["Mannschaften"]; // Tabelle
                for (int i = 1; i < 19; i++)
                {
                    for (int k = 0; k < 9; k++)
                    {
                        
                        z++;
                    }

                    z++;
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
