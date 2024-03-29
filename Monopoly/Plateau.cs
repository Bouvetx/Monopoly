﻿using System;
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
        public Achat[] listAchats;
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
            board[1] = new ProprieteFactory("Boulevard de Belleville", 15, 60);
            board[2] = new ActionFactory("Caisse de Communauté");
            board[3] = new ProprieteFactory("Rue Lecourbe", 15, 60);
            board[4] = new ActionFactory("Impot sur le revenu");
            board[5] = new ProprieteFactory("Gare Montparnasse", 50, 200); 
            board[6] = new ProprieteFactory("Rue de Vaugirard", 25, 100); 
            board[7] = new ActionFactory("Chance");
            board[8] = new ProprieteFactory("Rue de Courcelles", 25, 100); 
            board[9] = new ProprieteFactory("Avenue de la république", 30, 120); 
            board[10] = new ActionFactory("VisitJail");
            board[11] = new ProprieteFactory("Boulevard de la Villette", 35, 140); 
            board[12] = new ProprieteFactory("Compagnie de distribution d'electricité", 30, 150); 
            board[13] = new ProprieteFactory("Avenue de Neuilly", 35, 140);
            board[14] = new ProprieteFactory("Rue de Paradis", 40, 160); 
            board[15] = new ProprieteFactory("Gare de Lyon", 50, 200);
            board[16] = new ProprieteFactory("Avenue Mozart", 45, 180); 
            board[17] = new ActionFactory("Caisse de Communauté");
            board[18] = new ProprieteFactory("Boulevart Saint-Michel", 45, 180);
            board[19] = new ProprieteFactory("Place Pigalle", 50, 200); 
            board[20] = new ActionFactory("FreePark");
            board[21] = new ProprieteFactory("Avenue Matignon", 25, 220);
            board[22] = new ActionFactory("Chance");
            board[23] = new ProprieteFactory("Boulevard Malesherbes", 25, 220);
            board[24] = new ProprieteFactory("Avenue Henri Martin", 25, 240);
            board[25] = new ProprieteFactory("Gare du Nord", 25, 200); 
            board[26] = new ProprieteFactory("Faubourg Saint Honore", 25, 260); 
            board[27] = new ProprieteFactory("Place de la Bourse", 25, 260); 
            board[28] = new ProprieteFactory("Compagnie de distribution des eaux", 25, 150); 
            board[29] = new ProprieteFactory("Rue Lafayette", 25, 280); 
            board[30] = new ActionFactory("GoToJail");
            board[31] = new ProprieteFactory("Avenue de Breteuil", 75, 300); 
            board[32] = new ProprieteFactory("Avenue Foch", 75, 300); 
            board[33] = new ActionFactory("Caisse de Communauté");
            board[34] = new ProprieteFactory("Boulevard des Capucines", 80, 320); 
            board[35] = new ProprieteFactory("Gare St Lazare", 50, 200); 
            board[36] = new ActionFactory("Chance");
            board[37] = new ProprieteFactory("Boulevard des Champs-Elysées", 90, 350); 
            board[38] = new ActionFactory("Taxe de Luxe");
            board[39] = new ProprieteFactory("Rue de la Paix", 100, 400); 

            listAchats = new Achat[40];
            for(int i = 0; i<40;i++)
            {
                listAchats[i] = new Achat(board[i].GetCase().Owner);
            }
            for (int i = 0; i < 40; i++)
            {
                foreach (Joueur j in listJoueur)
                {
                    listAchats[i].Attach(new JoueurObserver(j));
                }
            }
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
                for (int j = 0; j < 12; j++)
                {
                    if(i==0 && j == 0)
                    {
                        Console.Write("║-->");
                    }
                    else if(i==0 || i == 10)
                    {
                        if (j == 11)
                        {
                            Console.Write("║");
                        }
                        else if ((i == 0 && j + i == player.Position) || (i == 10 && 40 - j - i  == player.Position))
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
                        if ((j == 11 && j + i -1 == player.Position)|| (j == 0 && 40 - i == player.Position))
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
                if (i == 0)
                {
                    Console.WriteLine("\n"+"╠═══╬═══╧═══╧═══╧═══╧═══╧═══╧═══╧═══╧═══╬═══╣");
                }
                else if (i == 9)
                {
                    Console.WriteLine("\n" + "╠═══╬═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╬═══╣");
                }
                else if (i != 10)
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