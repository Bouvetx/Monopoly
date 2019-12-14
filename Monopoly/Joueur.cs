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
        private string[] pionList = { "Le Chapeau Haut-de-Forme", "La Voiture", "Le Bateau", "Le Dé à coudre", "La Chaussure", "La Brouette", "Pion chapeau du MonopolyLe Chien", "Le Fer à repasser", "Le Cavalier et son Cheval", "Le Chat", "Pion chat du Monopoly", "Le Sac de Billets", "Le Canon", "La Lanterne", "Le Cheval à Bascule", "Le Sac à Mains" };


        public Joueur(string pion)
        {
            fond = 20000;
            pion = this.pion;
        }
        public Joueur()
        {
            fond = 20000;
            var rand = new Random(DateTime.Now);
            pion = pionList[rand.Next(pionList.Length)];
        }
    }
}
