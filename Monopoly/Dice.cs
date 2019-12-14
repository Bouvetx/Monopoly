using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Dice
    {
        public int dice1;
        public int dice2;
        Random aleatoire = new Random();

        public int RollingDices()
        {
            
            dice1 = aleatoire.Next(1, 7);
            dice2 = aleatoire.Next(1, 7);

            this.dice1 = dice1;
            this.dice2 = dice2;

        }

        public bool Double(int dice1, int dice2)
        {
            if(dice1 == dice2) { return true; } // TRUE if the dices are identitic 
            else { return false; } // FALSE if the dices are different
        }

    }
}

