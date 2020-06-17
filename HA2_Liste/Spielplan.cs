using System;
using System.Collections.Generic;
using System.Text;

namespace HA2_Liste
{
    class Spielplan
    {
        private int referenz;
        private int draußen;

        public Spielplan(int anzTeam)
        {
            referenz = anzTeam;
            draußen = anzTeam / 2;
        }

        public int[,,] Plan_aufstellen()
        {
            int[] Heimspiel = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            int[] Auswärtsspiel = new int[] { 17, 16, 15, 14, 13, 12, 11, 10 };
            int[,,] spiele = new int[(referenz - 1) * 2+1, referenz / 2, 2];

            //Erstelle Saisonplan
            for (int i = 1; i <= (referenz - 1) * 2; i++) //i ist Spieltag
            {

                //Console.WriteLine("Spieltag: " + i);

                if (i % 2 == 1)
                {
                    //Console.WriteLine(string.Join(string.Empty, Heimspiel));
                    //Console.WriteLine("Draußen ist: " + draußen);
                    Heimspiel = Obere_Liste_eins_weiter(Heimspiel, draußen);
                }

                else
                {
                    //Console.WriteLine(string.Join(string.Empty, Auswärtsspiel));
                    //Console.WriteLine("Draußen ist: " + draußen);
                    Auswärtsspiel = Untere_Liste_ein_weiter(Auswärtsspiel, draußen);
                }

                //Console.WriteLine(draußen + " vs " + referenz);
                spiele[i, 8, 0] = draußen;
                spiele[i, 8, 1] = referenz;
                for (int k = 0; k < (referenz / 2) - 1; k++) //K Spiel am Spieltag
                {
                    //Console.WriteLine(Heimspiel[k] + " vs " + Auswärtsspiel[k]);
                    spiele[i, k, 0] = Heimspiel[k];
                    //Console.WriteLine("Länge Array: " + Auswärtsspiel.Length);

                    spiele[i, k, 1] = Auswärtsspiel[k];
                }

                
            }


            int[] Obere_Liste_eins_weiter(int[] int_array, int draußen)
            {
                var länge = int_array.Length;
                int[] temp_list = new int[länge];
                for (int i = 0; i < länge - 1; i++)
                {
                    temp_list[i] = int_array[i + 1];
                }
                temp_list[länge - 1] = draußen;

                this.draußen = int_array[0];

                return temp_list;
            }


            int[] Untere_Liste_ein_weiter(int[] int_array, int draußen)
            {

                var länge = int_array.Length;
                int[] temp_list = new int[länge];
                for (int i = 0; i < länge - 1; i++)
                {
                    temp_list[i + 1] = int_array[i];
                }

                temp_list[0] = draußen;

                this.draußen = int_array[länge - 1];

                return temp_list;
            }

            return spiele;
        }
    }
}
