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
            int numJ=0;
            int i = 0;
            while (P.Game == true)//
            {
                i = 0;
                while (P.CurrentJoueur().rollTheDice())//Tour du joueur
                {
                    //Action du joueur
                    i++;
                    if (i == 3)
                    {
                        P.CurrentJoueur().goToPrison();
                        break;
                    }
                }
                
                P.NextJoueur();
                Console.ReadLine();
            }
            Console.ReadKey();
        }
    }
}
