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
            int i = 0;
            while (P.Game == true)//
            {
                i = 0;
                Console.WriteLine("Appuyer sur une touche pour lancer les dés");
                Console.ReadKey();
                while (P.CurrentJoueur().rollTheDice())//Tour du joueur
                {
                    Console.WriteLine("Vous éte sur la case : " + P.CurrentJoueur().CurrentCase().GetCase().ToString());
                    if (P.CurrentJoueur().CurrentCase().GetCase().CaseType == "Propriete")
                    {
                        if ((P.CurrentJoueur().CurrentCase().GetCase().Owner == null))
                        {
                            Console.WriteLine("Voullez vous acheter ?");
                            string rep = Console.ReadLine();
                            while (rep != "yes" && rep != "no" && rep != "y" && rep != "n")
                            {
                                Console.WriteLine("Voullez vous acheter ?(yes or no)");
                                rep = Console.ReadLine();
                            }
                            if (rep == "yes" || rep == "y")
                            {
                                P.CurrentJoueur().CurrentCase().GetCase().GetBuy(P.CurrentJoueur());
                            }
                        }
                        else
                        {
                            P.CurrentJoueur().Paye(P.CurrentJoueur().CurrentCase().GetCase().Rent);
                        }
                        Console.WriteLine("Vous avez : " + P.CurrentJoueur().Fond + " Euros");
                    }
                    else
                    {

                    }
                    i++;
                    if (i == 3)
                    {
                        P.CurrentJoueur().goToPrison();
                        break;
                    }
                }
                Console.WriteLine("Vous éte sur la case : " + P.CurrentJoueur().CurrentCase().GetCase().ToString());
                if (P.CurrentJoueur().CurrentCase().GetCase().CaseType == "Propriete")
                {
                    if ((P.CurrentJoueur().CurrentCase().GetCase().Owner == null)){
                        Console.WriteLine("Voullez vous acheter ?");
                        string rep = Console.ReadLine();
                        while (rep != "yes" && rep != "no" && rep!="y" && rep != "n")
                        {
                            Console.WriteLine("Voullez vous acheter ?(yes or no)");
                            rep = Console.ReadLine();
                        }
                        if (rep == "yes" || rep=="y")
                        {
                            P.CurrentJoueur().CurrentCase().GetCase().GetBuy(P.CurrentJoueur());
                        }
                    }
                    else
                    {
                        P.CurrentJoueur().Paye(P.CurrentJoueur().CurrentCase().GetCase().Rent);
                    }
                    Console.WriteLine("Vous avez : " + P.CurrentJoueur().Fond + " Euros");
                }
                else
                {
                    
                }
                Console.WriteLine("\n");
                P.NextJoueur();
            }
        }
    }
}