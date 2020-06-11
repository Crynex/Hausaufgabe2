using DocumentFormat.OpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.Text;

namespace HA2_Liste
{
    class Punkte
    {
        public char Points( int tore_a, int tore_b)
        {
            char endstand = 'n';

            if (tore_a == tore_b)
            {
                endstand = 'u';
                return endstand;
            } 
            else if (tore_a > tore_b)
            {
                endstand = 's';
                return endstand;
            }
            else
            {
                return endstand;
            }
             
           
        }
    }
}
