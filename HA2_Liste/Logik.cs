using System;
using System.Collections.Generic;
using System.Text;

namespace HA2_Liste
{
    class Logik
    {       
        public Excel excel;
        public String[] teams;
        public int[,,] spiel;      
        public Spielplan spielplan;
        public AblaufSpiel ablauf;        
        

        public Logik()
        {
            
            excel = new Excel();
            spielplan = new Spielplan(18);                       

            teams = excel.Einlesen_Teams();
            spiel = spielplan.Plan_aufstellen();

            ablauf = new AblaufSpiel(teams, spiel);
            ablauf.Ablauf();

            excel.Schreibe_Spiel(teams, spiel, ablauf);
            //excel.Schreibe_Tabelle(teams, spiel);
            
        }
    }
}

