using System;
using System.Collections.Generic;
using System.Text;

namespace HA2_Liste
{
    class Logik
    {       
        public Excel excel;
        public String[] teams;
        public Logik()
        {
            //Grafik
            //Teams Einlesen
            excel = new Excel();
            teams = excel.Einlesen_Teams();
            excel.Schreibe_Spielplan();
            //Grafik
            //Saison durchlaufen (alles)
            //Spielplan erstellen (einlesen, spielplan erstellen, spielplan zurückgeben)
            //Einen Spieltag (Spielplan erstellen, 1 Spiel ausführen, im nächsten Schritt den nächsten Tag bis Ende)
            //Tabelle beschreiben
            //Spieltag anschauen


        }
    }
}
