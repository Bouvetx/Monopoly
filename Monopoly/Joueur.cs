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
        private static string[] pionList = { "Le Chapeau Haut-de-Forme", "La Voiture", "Le Bateau", "Le Dé à coudre", "La Chaussure", "La Brouette", "Pion chapeau du MonopolyLe Chien", "Le Fer à repasser", "Le Cavalier et son Cheval", "Le Chat", "Pion chat du Monopoly", "Le Sac de Billets", "Le Canon", "La Lanterne", "Le Cheval à Bascule", "Le Sac à Mains" };


        public Joueur(string pion)
        {
            position = 0;
            fond = 20000;
            pion = this.pion;
        }
        public Joueur()
        {
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
        public bool rollTheDice()
        {
            var rand = new Random(DateTime.Now.Millisecond + DateTime.Now.Second * 1000 + DateTime.Now.Minute * 1000 * 60);
            int d1 = rand.Next(1,7);
            int d2 = rand.Next(1,7);
            Console.WriteLine(d1 + "\t" + d2);
            position +=d1 + d2;
            if (position >= 40)
            {
                fond += 200;
                position -= 40;
            }
            return d1 == d2;
        }
        public void goToPrison()
        {
            position = 10;
        }
    }
}
