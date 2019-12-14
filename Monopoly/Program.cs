using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Program
    {
        static void Main(string[] args)
        {
            Plateau P = Plateau.Instance;
            Joueur j1 = new Joueur();
            int numJ=0;
            int i = 0;
            while (P.Game == true)//
            {
                while (j1.rollTheDice() && i < 3)//Tour du joueur
                {
                    //Action du joueur
                    i++;
                }
                if (i == 3)
                {
                    P.listJoueur[numJ];
                }
                Console.ReadLine();
            }
            Console.ReadKey();
        }
    }
}
