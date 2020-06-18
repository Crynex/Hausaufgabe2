using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using DocumentFormat.OpenXml.Drawing.Charts;
using HA2_Liste_Ergebn;

namespace HA2_Liste
{
    public class AblaufSpiel
    {
        
        public struct Mannschaft
        {
            public int AnzSpiele;
            public int Endpunkte;
            public int spieltore;
            public int Tore;
            public int Gegentore;
            public int Siege;
            public int Unentschieden;
            public int Niederlage;

            public Mannschaft(int anzs, int e, int sp, int t, int gt, int si, int u, int n)
            {
                AnzSpiele = anzs;
                Endpunkte = e;
                spieltore = sp;
                Tore = t;
                Gegentore = gt;
                Siege = si;
                Unentschieden = u;
                Niederlage = n;
            }

           /*
            public override string ToString()
            {
                return String.Format("Mannschaft, Anzahl Spiele: {0}", AnzSpiele);
            }*/
        }

        public string[] teams;
        public int[,,] spiel;
        public int[,,] tore;
        Mannschaft[] mannschaft;
        Ergebnisse ergebnis;


        public AblaufSpiel(string[] teams, int[,,] spiel)
        {
            this.teams = teams;
            this.spiel = spiel;
            tore = new int[34 + 1, 9, 2];
            mannschaft = new Mannschaft[teams.Length+1];
            ergebnis = new Ergebnisse(0, 0);
            EstelleManschaften();
        }    
              
        
        public void EstelleManschaften()
        {
            for ( int i = 0; i < teams.Length ; i++)
            {
                mannschaft[i+1] = new Mannschaft(0, 0, 0, 0, 0, 0, 0, 0);
            }
        }

        public void Ablauf()
        {
            Mannschaft heim = mannschaft[0];
            Mannschaft gast = mannschaft[1];

            for (int i = 1; i < 35; i++)
            {
                for(int k = 0; k < 9; k++)
                {
                    //Spielaufruf
                    heim = mannschaft[spiel[i,k,0]];                    
                    gast = mannschaft[spiel[i,k,1]];


                    //Vergleich und Auswertung
                    /*
                    heim.spieltore = ergebnis.Ergebnis(0, 8);
                    heim.Tore = heim.Tore + heim.spieltore;
                    gast.spieltore = ergebnis.Ergebnis(0, 8);
                    gast.Tore += gast.spieltore;
                    heim.Gegentore = gast.Tore;
                    gast.Gegentore = heim.Tore;
                    */

                    //Spielablauf                               
                    tore[i, k, 0] = ergebnis.Ergebnis(0, 8);
                    heim.Tore = tore[i, k, 0];
                    mannschaft[spiel[i, k, 0]].spieltore = (int) tore[i, k, 0];
                    mannschaft[spiel[i, k, 0]].Tore = mannschaft[spiel[i, k, 0]].Tore + mannschaft[spiel[i, k, 0]].spieltore;
                    tore[i, k, 1] = ergebnis.Ergebnis(0, 8);
                    gast.Tore = tore[i, k, 1];
                    mannschaft[spiel[i, k, 1]].spieltore = tore[i, k, 1];
                    mannschaft[spiel[i, k, 1]].Tore += mannschaft[spiel[i, k, 1]].spieltore;
                    mannschaft[spiel[i, k, 0]].Gegentore = mannschaft[spiel[i, k, 1]].Tore;
                    mannschaft[spiel[i, k, 1]].Gegentore = mannschaft[spiel[i, k, 0]].Tore;

                    //Ergebnis Vergleichen
                    if (heim.Tore == gast.Tore)
                    {
                        /*
                        heim.Endpunkte += 1;
                        gast.Endpunkte += 1;
                        heim.Unentschieden += 1;
                        gast.Unentschieden += 1;
                        */
                        mannschaft[spiel[i, k, 0]].Endpunkte += 1;
                        mannschaft[spiel[i, k, 1]].Endpunkte += 1;
                        mannschaft[spiel[i, k, 0]].Unentschieden += 1;
                        mannschaft[spiel[i, k, 1]].Unentschieden += 1;
                    } 
                    else if (heim.Tore > gast.Tore)
                    {
                        /*
                        heim.Endpunkte += 3;
                        gast.Endpunkte += 0;
                        heim.Siege += 1;
                        gast.Niederlage += 1;
                        */
                        mannschaft[spiel[i, k, 0]].Endpunkte += 3;
                        mannschaft[spiel[i, k, 1]].Endpunkte += 0;
                        mannschaft[spiel[i, k, 0]].Siege += 1;
                        mannschaft[spiel[i, k, 1]].Niederlage += 1;
                    }
                    else if (heim.Tore < gast.Tore)
                    {
                        /*
                        heim.Endpunkte += 0;
                        gast.Endpunkte += 3;
                        heim.Niederlage += 1;
                        gast.Siege += 1;
                        */
                        mannschaft[spiel[i, k, 0]].Endpunkte += 0;
                        mannschaft[spiel[i, k, 1]].Endpunkte += 3;
                        mannschaft[spiel[i, k, 0]].Niederlage += 1;
                        mannschaft[spiel[i, k, 1]].Siege += 1;
                    }

                    //heim.AnzSpiele = i;
                    //gast.AnzSpiele = i;
                    
                    mannschaft[spiel[i,k,0]].AnzSpiele = i;
                    mannschaft[spiel[i, k, 1]].AnzSpiele = i;
                }
            }
        }

        //Abruf Ergebnisswerte
        public int GetSpieltore(int Spieltag, int Spielnr, int Mannschaft)
        {
            return tore[Spieltag, Spielnr, Mannschaft];
        }

        public int GetAnzSpiele(int ManschaftsNummer)
        {
            return mannschaft[ManschaftsNummer].AnzSpiele;            
        }
        public int GetEndepunkte(int ManschaftsNummer)
        {
            return mannschaft[ManschaftsNummer].Endpunkte;
        }
        public int GetTore(int ManschaftsNummer)
        {
            return mannschaft[ManschaftsNummer].Tore;
        }
        public int GetGegentore(int ManschaftsNummer)
        {
            return mannschaft[ManschaftsNummer].Gegentore;
        }
        public int GetSiege(int ManschaftsNummer)
        {
            return mannschaft[ManschaftsNummer].Siege;
        }
        public int GetUnentschieden(int ManschaftsNummer)
        {
            return mannschaft[ManschaftsNummer].Unentschieden;
        }
        public int GetNiederlagen(int ManschaftsNummer)
        {
            return mannschaft[ManschaftsNummer].Niederlage;
        }
        

    }
    
}
