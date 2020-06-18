using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Presentation;
using OfficeOpenXml;

namespace HA2_Liste
{
    class Excel
    {
        //private Ergebnisse ergebnisse;
        //public Spiel Mannschaft;
        // holt Excel-Tabelle
        public Excel()
        {
            Directory.SetCurrentDirectory(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName);
            Directory.SetCurrentDirectory(@"..\");
            Directory.SetCurrentDirectory(@"Excel_Tabellen");
            //ergebnisse = new Ergebnisse();
        }

        // Teamdaten aus Excel-Tabelle lesen
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

            }
            return teams;
        }

        //Excel beschreiben
        public void Schreibe_Spiel(String[] teams, int[,,] spiele, AblaufSpiel ablauf)
        {
            //Zeilenr. Start: zeile 2
            int z = 2;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo("Teams.xlsx")))
            {
                //Tabellenblatt Spielplan
                var sheet = package.Workbook.Worksheets["Spielplan"];
                for (int i = 1; i < 35; i++)
                {
                    for (int k = 0; k < 9; k++)
                    {
                        //Schreibe Spielplan und Tore in Tabellenblatt
                        sheet.Cells[z, 1].Value = i;
                        sheet.Cells[z, 2].Value = k + 1;
                        sheet.Cells[z, 3].Value = teams[spiele[i, k, 0] - 1];
                        sheet.Cells[z, 4].Value = ablauf.GetSpieltore(i,k,0);
                        sheet.Cells[z, 5].Value = teams[spiele[i, k, 1] - 1];
                        sheet.Cells[z, 6].Value = ablauf.GetSpieltore(i,k,1);


                        z++;
                    }

                    z++;
                }

                //Tabellenblatt Tabelle
                var sheet2 = package.Workbook.Worksheets["Tabelle"];

                int z2 = 2;

                for (int i = 0; i < 18; i++)
                {
                    //Schreibe Tabelle und Ergebnisse in Tabellenblatt
                    sheet2.Cells[z2, 1].Value = teams[i];
                    i++;
                    sheet2.Cells[z2, 2].Value = ablauf.GetAnzSpiele(i);
                    sheet2.Cells[z2, 3].Value = ablauf.GetEndepunkte(i);
                    sheet2.Cells[z2, 4].Value = ablauf.GetSiege(i);
                    sheet2.Cells[z2, 5].Value = ablauf.GetUnentschieden(i);
                    sheet2.Cells[z2, 6].Value = ablauf.GetNiederlagen(i);
                    sheet2.Cells[z2, 7].Value = ablauf.GetTore(i);
                    sheet2.Cells[z2, 8].Value = ablauf.GetGegentore(i);
                    i--;
                    z2++;
                }               

                package.SaveAs(new FileInfo("Teams.xlsx"));                         

            }
        }
    }
}
