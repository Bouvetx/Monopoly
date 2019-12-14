using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Plateau
    {
        private Case[] board;
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
            board = new Case[40];
        }

        public bool Game
        {
            get
            {
                return game;
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