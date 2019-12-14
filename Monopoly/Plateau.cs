using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Plateau
    {
        Case[] board;
        private static Plateau instance = null;
        private static readonly object padlock = new object();

        Plateau()
        {
            board = new Case[40];
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