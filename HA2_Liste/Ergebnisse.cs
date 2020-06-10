using DocumentFormat.OpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.Text;

namespace HA2_Liste
{
    class Ergebnisse
    {
        public int Ergebnis()
        {
            Random zufall = new Random();
            int Tore = zufall.Next(0, 6);
            Console.WriteLine(Tore);
            return Tore;
        }
    }
}
