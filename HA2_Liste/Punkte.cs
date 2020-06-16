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
            int points = 1;
           if(tore_a > tore_b)
            {
                points[0] = 3;
                points[1] = 0;
                return points;
            }
            else if(tore_b > tore_a)
            {
                points[0] = 0;
                points[1] = 3;
                return points;
            } else
            {
                return points;
            }           
        }
    }
}
