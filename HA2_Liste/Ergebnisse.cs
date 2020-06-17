using DocumentFormat.OpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.Text;

namespace HA2_Liste_Ergebn
{
    public class Ergebnisse
    {
        int scoremin;
        int scoremax;

        public Ergebnisse(int min, int max)
        {
            scoremin = min;
            scoremax = max;
        }

        public int Ergebnis(int min, int max)
        {
            Random zufall = new Random();
            var max_temp = zufall.Next(min+1, max);
            int Tore = zufall.Next(min, max_temp);           
            return Tore;
        }
    }
}
