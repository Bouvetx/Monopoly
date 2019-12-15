using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class JoueurObserver : IJoueur
    {
        private Joueur joueur;
        private Observer observ;

        public JoueurObserver(Joueur joueur)
        {
            this.joueur = joueur;
        }

        public void Update(Observer observ)
        {
            Console.WriteLine("Notified "+joueur.Pion+" from the purchase of "+Plateau.Instance.CurrentJoueur().CurrentCase().GetCase().StreetName+" by player "+Plateau.Instance.CurrentJoueur().Pion);
        }
    }
}
