using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Action : Case
    {
        private static string[] carteChance = { "Advance to |Gare de Lyon| , if you pass Départ Collect 200 Euros", "Advance to |Rue de la Paix|", "Collect |50| Euros of dividend from the Bank", "Advance to |départ|", "Go to jail , move directly to jail do not pass départ , do not collect 200 Euros", "Advace to |Avenue Henri Martin| , if you pass Départ collect 200 Euros", "Drunk in charge pay |20| Euros", "Speeding fine , pay |15| Euros", "Advence to |Boulevard de la Villette| , if you pass Départ collect 200 Euros", "Pay school fees of |150| Euros", "Your builduilding loan matures , collect |150| Euros", "You have won a crossword competition , collect |100| Euros" };
        private static string[] carteCommunauté = { "Pay your insurance premium |50| Euros", "Doctor's fee pay |50| Euros", "Go to jail , move directly to jail do not pass Go , do not collect 200 Euros", "Bank error in our favour , collect |200| Euros", "You have won second prize in a beaut contest , collect |10| Euros", "You inherit , collect |100| Euros", "Pay hospital |100| Euros", "Collect interest on 7% preference shares , collect |25| Euros", "Annuity matures collect |100| Euros", "Go back to |Boulevard de Belleville|", "From sale of stock you collect |50| Euros", "Income tax refund , collect |20| Euros", "Advance to |départ|" };
        private readonly string caseType;
        private string actionName;
        private string streetName = null;
        private int rent = 0;
        private int price = 0;

        public Action(string actionName)
        {
            this.caseType = "Action";
            this.actionName = actionName;
        }
        public override string CaseType
        {
            get { return this.caseType; }
        }
        public override string ActionName
        {
            get { return this.actionName; }
            set { this.actionName = value; }
        }
        public override Joueur Owner
        {
            get { return null; }
        }

        public override string StreetName
        {
            get { return this.streetName; }
            set { this.streetName = value; }
        }
        public override int Rent
        {
            get { return this.rent; }
            set { this.rent = value; }
        }
        public override int Price
        {
            get { return this.price; }
            set { this.price = value; }
        }
        public override string ToString()
        {
            return actionName;
        }
        public override bool GetBuy(Joueur acheteur)
        {
            return false;
        }
        public static string drawcard(char c)
        {
            var rand = new Random(DateTime.Now.Millisecond + DateTime.Now.Second * 1000 + DateTime.Now.Minute * 1000 * 60);
            if (c == 'o')
            {
                return carteCommunauté[rand.Next(1, carteCommunauté.Length)];
            }
            if (c == 'a')
            {
                return carteChance[rand.Next(1, carteChance.Length)];
            }
            else return "";
        }
        public static void ReadCard(string card)
        {
            Console.WriteLine(card);
            int pay = ComptageDeRepetition(card.ToLower(), "pay");
            int collect = ComptageDeRepetition(card.ToLower(), "collect");
            int advance = ComptageDeRepetition(card.ToLower(), "advance");
            int go = ComptageDeRepetition(card.ToLower(), "go");
            int jail = ComptageDeRepetition(card.ToLower(), "jail");
            if (jail > 0)
            {
                Plateau.Instance.CurrentJoueur().goToPrison();
            }
            else if (advance > 0)
            {
                if (CasePosition(readpart(card.ToLower())) < Plateau.Instance.CurrentJoueur().Position)
                {
                    Plateau.Instance.CurrentJoueur().Paye(-200);
                }
                Plateau.Instance.Afficher(Plateau.Instance.CurrentJoueur());
                Console.WriteLine("Vous éte sur la case : " + Plateau.Instance.CurrentJoueur().CurrentCase().GetCase().ToString());
                if (Plateau.Instance.CurrentJoueur().CurrentCase().GetCase().CaseType == "Propriete")
                {
                    if ((Plateau.Instance.CurrentJoueur().CurrentCase().GetCase().Owner == null))
                    {
                        Console.WriteLine("Voullez vous acheter ?(yes or no)");
                        string rep = Console.ReadLine();
                        while (rep != "yes" && rep != "no" && rep != "y" && rep != "n")
                        {
                            Console.WriteLine("Voullez vous acheter ?(yes or no)");
                            rep = Console.ReadLine();
                        }
                        if (rep == "yes" || rep == "y")
                        {
                            Plateau.Instance.CurrentJoueur().CurrentCase().GetCase().GetBuy(Plateau.Instance.CurrentJoueur());
                        }
                    }
                    else
                    {
                        Plateau.Instance.CurrentJoueur().Paye(Plateau.Instance.CurrentJoueur().CurrentCase().GetCase().Rent);
                    }
                    Console.WriteLine("Vous avez : " + Plateau.Instance.CurrentJoueur().Fond + " Euros");
                }
                else
                {
                    if (Plateau.Instance.CurrentJoueur().CurrentCase().GetCase().ActionName == "Taxe de Luxe")
                    {
                        Console.WriteLine("Taxe de Luxe , paye 100");
                        Plateau.Instance.CurrentJoueur().Paye(100);
                    }
                    if (Plateau.Instance.CurrentJoueur().CurrentCase().GetCase().ActionName == "Impot sur le revenu")
                    {
                        Console.WriteLine("Impot sur le revenu , paye 200");
                        Plateau.Instance.CurrentJoueur().Paye(200);
                    }
                    if (Plateau.Instance.CurrentJoueur().CurrentCase().GetCase().ActionName == "FreeParc")
                    {
                        Console.WriteLine("FreeParc , collect 200");
                        Plateau.Instance.CurrentJoueur().Paye(-200);
                    }
                    if (Plateau.Instance.CurrentJoueur().CurrentCase().GetCase().ActionName == "Caisse de Communauté")
                    {
                        Console.WriteLine("Draw a Caisse de Communauté card");
                        Action.ReadCard(Action.drawcard('o'));
                    }
                    if (Plateau.Instance.CurrentJoueur().CurrentCase().GetCase().ActionName == "Chance")
                    {
                        Console.WriteLine("Draw a Chance card");
                        Action.ReadCard(Action.drawcard('a'));
                    }
                    Console.WriteLine("Vous avez : " + Plateau.Instance.CurrentJoueur().Fond + " Euros");
                }
                Plateau.Instance.CurrentJoueur().Position= CasePosition(readpart(card.ToLower()));
            }
            else if (pay > 0)
            {
                Plateau.Instance.CurrentJoueur().Paye(Int32.Parse(readpart(card.ToLower())));
            }
            else if (collect > 0 && advance==0)
            {
                Plateau.Instance.CurrentJoueur().Paye(-Int32.Parse(readpart(card.ToLower())));
            }
        }
        public static int CasePosition(string phrase)
        {
            for (int i = 0; i < 40; i++)
            {
                if (Plateau.Instance.Board[i].GetCase().StreetName == phrase)
                {
                    return i;
                }
            }
            return -1;
        }
        public static string readpart(string frase)
        {
            string[] valeurs = frase.Split('|');
            return valeurs[1];
        }
        public static int ComptageDeRepetition(string frase, string motus)
        {
            bool valable = false;
            int compteur = 0;
            for (int i = 0; i <= frase.Length - motus.Length; i++)
            {

                for (int j = 0; j < motus.Length; j++)
                {
                    valable = true;
                    if (frase[i + j] != motus[j])//verifie la corespondance entre le mot et la phrase
                    {
                        valable = false;
                        break;
                    }
                }
                if (valable == true)//verifie que le mot n'est pas juste une parti d'un autre mot
                {
                    if (i > 0)
                    {
                        if (frase[i - 1] != ' ')
                        {
                            valable = false;
                        }
                    }
                    if (i < frase.Length - motus.Length)
                    {
                        if (frase[i + motus.Length] != ' ')
                        {
                            valable = false;
                        }
                    }
                }
                if (valable == true)//Si le mot et bien reconnu le compte
                {
                    compteur++;
                    valable = false;
                }

            }
            return compteur;
        }
    }
}
