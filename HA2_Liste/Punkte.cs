using DocumentFormat.OpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.Text;

namespace HA2_Liste
{
    class Punkte
    {
        public int Punkt(int tore_a, int tore_b)
        {
            int points = 0;
            if (tore_a == tore_b)
            {
                points = 1;
                return points;
            }
            else if(tore_a > tore_b)
            {
                points = 3;
                return points;
            }
            else
            {
                return points;
            }           
        }
    }
}
