using System;
using System.Collections.Generic;
using System.Text;

namespace HA2_Liste
{
    class Logik
    {       
        public Excel excel;
        public String[] teams;
        public Ergebnisse tore;
        public Spielplan spiel;
        public Punkte punkt; 

        public Logik()
        {
            //Grafik
            //Teams Einlesen
            excel = new Excel();
            teams = excel.Einlesen_Teams();

            excel.Schreibe_Spielplan(teams, spiel);
            tore = new Ergebnisse();
            punkt = new Punkte();
        }
    }
}

//Einlesen
//Plan erstellen
//Spieltag 1(i): 
    //Spiel 1(k)
        //Tore Team 1A ermitteln
        //Tore Team 1B ermitteln
        //Tore Team 1A und 1B an Punkte -> Punkte für A
        //Tore Team 1B und 1A an Punkte -> Punkte für B
    //Spiel 2

//Ablauf Logik:
    //Plan
    //Spielplan
    //Spielplan durchgehen
    //Spieltag i(1) Spiel k(1)
    //Tore für Team 0
    //Tore für Team 1
    //Punkte für Team 0
    //Punkte für Team 1
    //In Excel schreiben
    //Spieltag i(1) Spiel k(1)
    // .....
    //Spieltag i(34)Spiel k(9)
    //In Excel schreiben


    //Sortieren etc alles in Excel