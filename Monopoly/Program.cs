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
            // CaseFactory case1 = new ActionFactory("Départ");
            CaseFactory case2 = new PropFactory("rue des andes", 25, 120);
            //Case case1bis = case1.GetCreditCard();
            //Console.WriteLine("Action name: {0}",case1bis.ActionName);
            Case case3 = case2.GetCase();
            Console.WriteLine("street: {0}\n rent: {1}\n price: {2}", case3.StreetName, case3.Rent, case3.Price);/*

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