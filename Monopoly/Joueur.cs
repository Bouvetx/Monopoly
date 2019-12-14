using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Joueur
    {
        private int fond;
        private string pion;
        private int position;
        private int prison;
        private static string[] pionList = { "Le Chapeau Haut-de-Forme", "La Voiture", "Le Bateau", "Le Dé à coudre", "La Chaussure", "La Brouette", "Pion chapeau du MonopolyLe Chien", "Le Fer à repasser", "Le Cavalier et son Cheval", "Le Chat", "Pion chat du Monopoly", "Le Sac de Billets", "Le Canon", "La Lanterne", "Le Cheval à Bascule", "Le Sac à Mains" };


        public Joueur(string pion)
        {
            prison = 0;
            position = 0;
            fond = 20000;
            pion = this.pion;
        }

        public Joueur()
        {
            prison = 0;
            position = 0;
            fond = 1500;
            var rand = new Random(DateTime.Now.Millisecond + DateTime.Now.Second * 1000 + DateTime.Now.Minute * 1000 * 60);
            int x = rand.Next(pionList.Length);
            pion = pionList[x];
            pionList[x]="";
            while (pion == "")
            {
                x = rand.Next(pionList.Length);
                pion = pionList[x];
                pionList[x] = "";
            }
            Console.WriteLine("Tu es le joueur : " + pion);
        }

        public string Pion
        {
            get
            {
                return pion;
            }
        }

        public bool rollTheDice()
        {
            var rand = new Random(DateTime.Now.Millisecond + DateTime.Now.Second * 1000 + DateTime.Now.Minute * 1000 * 60);
            int d1 = rand.Next(1,7);
            int d2 = rand.Next(1,7);
            Console.WriteLine(d1 + "\t" + d2 +"\t total= "+(d1+d2));
            bool sortie = d1==d2;
            if (prison==0 || d1 == d2)
            {
                Console.Write(position+"\t->\t");
                position += d1 + d2;
                if (position >= 40)
                {
                    fond += 200;
                    position -= 40;
                }
                Console.WriteLine(position);
                if (prison > 0)
                {
                    sortie = false;
                }
                prison = 0;
            }

            if (prison > 0)
            {
                Console.WriteLine("Encore " + prison + " tour en prison");
                prison--;
            }
            return sortie;
        }
        public void goToPrison()
        {
            position = 10;
            prison = 2;
            Console.WriteLine("Straight to jail");
        }
    }
}
