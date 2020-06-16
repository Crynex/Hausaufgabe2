using System;
using System.Collections.Generic;
using System.Text;

namespace HA2_Liste
{
    class AblaufSpiel
    {
        
        public struct Mannschaft
        {
            int Endpunkte;
            int Tore;
            int Gegentore;
            int Siege;
            int Unentschieden;
            int Niederlage;
        }

        private string[] teams;
        private int[,,] spiel;
        public Ergebnisse ergebnis;        

        public AblaufSpiel(string[] teams, int[,,] spiel)
        {
            this.teams = teams;
            this.spiel = spiel;
        }    
               
        class Spielablauf
        {
             
            public int Ablauf()               

            {
                for(int i = 1; i < 35, i++)
                {
                    for(int k = 0; k < 9; k++)
                    {
                        Mannschaft heim;
                        heim.Tore = ergebnis.Ergebnis(0, 8);
                        gast.Tore = ergebnis.Ergebnis(0, 8);
                        heim.Gegentore = gast.Tore;
                        gast.Gegentore = heim.Tore;

                        if(heim.Tore == gast.Tore)
                        {
                            heim.Endpunkte += 1:
                            gast.Endpunkte += 1;
                            heim.Unentschieden += 1;
                            gast.Unentschieden += 1;
                        } else if (heim.Tore > gast.Tore)
                        {
                            heim.Endpunkte += 3:
                            gast.Endpunkte += 0;
                            heim.Siege += 1;
                            gast.Niederlagen += 1;
                        }
                        else
                        {
                            heim.Endpunkte += 0:
                            gast.Endpunkte += 3;
                            heim.Niederlagen += 1;
                            gast.Siege += 1;
                        }
                       
                    }
                }
            }

        }
    }
}
