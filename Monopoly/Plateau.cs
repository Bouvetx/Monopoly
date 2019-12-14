﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Plateau
    {
        private Case[] board;
        public Joueur[] listJoueur;
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
    }
}
public sealed class TheBell
{
    private static TheBell bellConnection;
    private static object syncRoot = new Object();


    /// <summary>
    /// We implement this method to ensure thread safety for our singleton.
    /// </summary>
    public static TheBell Instance
    {
        get
        {
            lock (syncRoot)
            {
                if (bellConnection == null)
                {
                    bellConnection = new TheBell();
                }
            }

            return bellConnection;
        }
    }

    public void Ring()
    {
        Console.WriteLine("Ding! Order up!");
    }
}