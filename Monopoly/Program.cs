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
            CaseFactory case1 = new ActionFactory("Départ");
            CaseFactory case2 = new ProprieteFactory("rue des andes", 25, 120);
            Case action = case1.GetCase();
            Console.WriteLine("Action name: {0}",action.ActionName);
            Case prop = case2.GetCase();
            Console.WriteLine("street: {0}\nrent: {1}\nprice: {2}", prop.StreetName, prop.Rent, prop.Price);
            /*
            Console.WriteLine();
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
            }*/
            Console.ReadKey();
        }
    }
}