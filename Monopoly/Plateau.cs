using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Plateau
    {
        private CaseFactory[] board;
        private Joueur[] listJoueur;
        private static int numCurrentJoueur=0;
        private bool game;
        private static Plateau instance = null;
        private static readonly object padlock = new object();

        Plateau()
        {
            int num;
            Console.WriteLine("Veuillez entrer le nombre de joueur (<16)");
            Int32.TryParse(Console.ReadLine(), out num);
            while (num > 16 || num < 2)
            {
                Console.WriteLine("Veuillez entrer le nombre de joueur (<16)");
                Int32.TryParse(Console.ReadLine(), out num);
            }
            listJoueur = new Joueur[num];
            for (int i = 0; i < num; i++)
            {
                listJoueur[i] = new Joueur();
            }

            game = true;
            board = new CaseFactory[40];

            board[0] = new ActionFactory("Départ");
            board[1] = new ProprieteFactory("Boulevard de Belleville", 25, 60); //MARRON
            board[2] = new ActionFactory("Caisse de Communauté");//
            board[3] = new ProprieteFactory("Rue Lecourbe", 25, 60);//MARRON
            board[4] = new ActionFactory("Impot sur le revenu");//
            board[5] = new ProprieteFactory("Gare Montparnasse", 25, 200); //GARE
            board[6] = new ProprieteFactory("Rue de Vaugirard", 25, 100); //BLANC
            board[7] = new ActionFactory("Chance");//
            board[8] = new ProprieteFactory("Rue de Courcelles", 25, 100); //BLANC
            board[9] = new ProprieteFactory("Avenue de la république", 25, 120); //BLANC
            board[10] = new ActionFactory("VisitJail");//
            board[11] = new ProprieteFactory("Boulevard de la Villette", 25, 140); //ROSE
            board[12] = new ProprieteFactory("Compagnie de distribution d'electricité", 25, 150); //COMPAGNIE
            board[13] = new ProprieteFactory("Avenue de Neuilly", 25, 140); //ROSE
            board[14] = new ProprieteFactory("Rue de Paradis", 25, 160); //ROSE
            board[15] = new ProprieteFactory("Gare de Lyon", 25, 200); //GARE
            board[16] = new ProprieteFactory("Avenue Mozart", 25, 180); //ORANGE
            board[17] = new ActionFactory("Caisse de Communauté");//
            board[18] = new ProprieteFactory("Boulevart Saint-Michel", 25, 180);//ORANGE
            board[19] = new ProprieteFactory("Place Pigalle", 25, 200); //ORANGE
            board[20] = new ActionFactory("FreePark");//
            board[21] = new ProprieteFactory("Avenue Matignon", 25, 220); //ROUGE
            board[22] = new ActionFactory("Chance");//
            board[23] = new ProprieteFactory("Boulevard Malesherbes", 25, 220); //ROUGE
            board[24] = new ProprieteFactory("Avenue Henri Martin", 25, 240); //ROUGE
            board[25] = new ProprieteFactory("Gare du Nord", 25, 200); //GARE
            board[26] = new ProprieteFactory("Faubourg Saint Honore", 25, 260); //JAUNE
            board[27] = new ProprieteFactory("Place de la Bourse", 25, 260); //JAUNE
            board[28] = new ProprieteFactory("Compagnie de distribution des eaux", 25, 150); //COMPAGNIE
            board[29] = new ProprieteFactory("Rue Lafayette", 25, 280); //JAUNE
            board[30] = new ActionFactory("GoToJail");//
            board[31] = new ProprieteFactory("Avenue de Breteuil", 25, 300); //VERT
            board[32] = new ProprieteFactory("Avenue Foch", 25, 300); //VERT
            board[33] = new ActionFactory("Caisse de Communauté");
            board[34] = new ProprieteFactory("Boulevard des Capucines", 25, 320); //VERT
            board[35] = new ProprieteFactory("Gare St Lazare", 25, 200); //GARE
            board[36] = new ActionFactory("Chance");//
            board[37] = new ProprieteFactory("Boulevard des Champs-Elysées", 25, 350); //BLEU
            board[38] = new ActionFactory("Taxe de Luxe");//
            board[39] = new ProprieteFactory("Rue de la Paix", 25, 400); //BLEU

            /*
            board[1] = new ActionFactory("Départ");
            board[2] = new ProprieteFactory("rue des andes", 25, 120);

            Case action = case1.GetCase();
            Console.WriteLine("Action name: {0}", action.ActionName);
            OU
            Console.WriteLine("street: {0}\nrent: {1}\nprice: {2}", board[2].GetCase().StreetName, board[2].GetCase().Rent, board[2].GetCase().Price);
            */
        }

        public bool Game
        {
            get
            {
                return game;
            }
        }
        public void Afficher(Joueur player)
        {
            Console.WriteLine("╔═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╗");
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if(i==0 && j == 0)
                    {
                        Console.Write("║-->");
                    }
                    else if(i==0 || i == 11)
                    {
                        if (i == 0 && j + i == player.Position)
                        {
                            Console.Write("║ █ ");
                        }
                        else if (i == 0 && 40 - j - i == player.Position)
                        {
                            Console.Write("║ █ ");
                        }
                        else
                        {
                            Console.Write("║   ");
                        }
                    }
                    else
                    {
                        if (j == 11 && j + i == player.Position)
                        {
                            Console.Write("║ █ ║");
                        }
                        else if (j == 0 && 40 - i == player.Position)
                        {
                            Console.Write("║ █ ║");
                        }
                        else if (j == 0 || j == 11)
                        {
                            Console.Write("║   ║");
                        }
                        else if(j==2)
                        {
                            Console.Write("                                   ");
                        }
                    }
                }
                if(i == 0 || i == 11)
                {

                }
                if (i == 0)
                {
                    Console.WriteLine("\n"+"╠═══╬═══╧═══╧═══╧═══╧═══╧═══╧═══╧═══╧═══╬═══╣");
                }
                else if (i == 10)
                {
                    Console.WriteLine("\n" + "╠═══╬═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╬═══╣");
                }
                else if (i != 11)
                {
                    Console.WriteLine("\n" + "╠═══╣                                   ╠═══╣");
                }

            }
            Console.WriteLine("\n" + "╚═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╝");
        }
        public CaseFactory[] Board
        {
            get
            {
                return board;
            }
        }

        public static Plateau Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new Plateau();
                        }
                    }
                }
                return instance;
            }
        }
        public Joueur CurrentJoueur()
        {
            return listJoueur[numCurrentJoueur];
        }
        public void NextJoueur()
        {
            numCurrentJoueur=(numCurrentJoueur + 1)%listJoueur.Length;
            Console.WriteLine("C'est au tour de : " + listJoueur[numCurrentJoueur].Pion);
        }
    }
}