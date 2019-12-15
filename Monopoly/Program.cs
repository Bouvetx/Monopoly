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
                    P.Afficher(P.CurrentJoueur());
                    Console.WriteLine("Vous éte sur la case : " + P.CurrentJoueur().CurrentCase().GetCase().ToString());
                    if (P.CurrentJoueur().CurrentCase().GetCase().CaseType == "Propriete")
                    {
                        if ((P.CurrentJoueur().CurrentCase().GetCase().Owner == null))
                        {
                            Console.WriteLine("Vous avez : " + P.CurrentJoueur().Fond + " Euros");
                            Console.WriteLine("Voullez vous acheter ?(yes or no)");
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
                    }
                    else
                    {
                        if (P.CurrentJoueur().CurrentCase().GetCase().ActionName == "Taxe de Luxe")
                        {
                            Console.WriteLine("Taxe de Luxe , paye 100");
                            P.CurrentJoueur().Paye(100);
                        }
                        if (P.CurrentJoueur().CurrentCase().GetCase().ActionName == "Impot sur le revenu")
                        {
                            Console.WriteLine("Impot sur le revenu , paye 200");
                            P.CurrentJoueur().Paye(200);
                        }
                        if (P.CurrentJoueur().CurrentCase().GetCase().ActionName == "FreeParc")
                        {
                            Console.WriteLine("FreeParc , collect 200");
                            P.CurrentJoueur().Paye(-200);
                        }
                        if (P.CurrentJoueur().CurrentCase().GetCase().ActionName == "Caisse de Communauté")
                        {
                            Console.WriteLine("Draw a Caisse de Communauté card");
                            Action.ReadCard(Action.drawcard('o'));
                        }
                        if (P.CurrentJoueur().CurrentCase().GetCase().ActionName == "Chance")
                        {
                            Console.WriteLine("Draw a Chance card");
                            Action.ReadCard(Action.drawcard('a'));
                        }
                    }
                    i++;
                    if (i == 3)
                    {
                        P.CurrentJoueur().goToPrison();
                        break;
                    }
                }
                P.Afficher(P.CurrentJoueur());
                Console.WriteLine("Vous éte sur la case : " + P.CurrentJoueur().CurrentCase().GetCase().ToString());
                if (P.CurrentJoueur().CurrentCase().GetCase().CaseType == "Propriete")
                {
                    if ((P.CurrentJoueur().CurrentCase().GetCase().Owner == null)){
                        Console.WriteLine("Vous avez : " + P.CurrentJoueur().Fond + " Euros");
                        Console.WriteLine("Voullez vous acheter ?(yes or no)");
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
                }
                else
                {
                    if (P.CurrentJoueur().CurrentCase().GetCase().ActionName == "Taxe de Luxe")
                    {
                        Console.WriteLine("Taxe de Luxe , paye 100");
                        P.CurrentJoueur().Paye(100);
                    }
                    if (P.CurrentJoueur().CurrentCase().GetCase().ActionName == "Impot sur le revenu")
                    {
                        Console.WriteLine("Impot sur le revenu , paye 200");
                        P.CurrentJoueur().Paye(200);
                    }
                    if (P.CurrentJoueur().CurrentCase().GetCase().ActionName == "FreeParc")
                    {
                        Console.WriteLine("FreeParc , collect 200");
                        P.CurrentJoueur().Paye(-200);
                    }
                    if (P.CurrentJoueur().CurrentCase().GetCase().ActionName == "Caisse de Communauté")
                    {
                        Console.WriteLine("Draw a Caisse de Communauté card");
                        Action.ReadCard(Action.drawcard('o'));
                    }
                    if (P.CurrentJoueur().CurrentCase().GetCase().ActionName == "Chance")
                    {
                        Console.WriteLine("Draw a Chance card");
                        Action.ReadCard(Action.drawcard('a'));
                    }
                }
                Console.WriteLine("\n");
                P.NextJoueur();
            }
        }
    }
}