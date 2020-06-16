using DocumentFormat.OpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.Text;

namespace HA2_Liste
{
    class Ergebnisse
    {
        public int Ergebnis(int min, int max)
        {
            Random zufall = new Random();
            var max_temp = zufall.Next(min+1, max);
            int Tore = zufall.Next(min, max_temp);
            Console.WriteLine(Tore);
            return Tore;
        }
    }
}
