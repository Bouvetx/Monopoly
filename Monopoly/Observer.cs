using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    abstract class Observer
    {
        private Joueur owner;
        private List<IJoueur> listJoueurs = new List<IJoueur>();

        public Observer(Joueur ownership)
        {
            this.owner = ownership;
        }
        public void Attach(IJoueur joueur)
        {
            listJoueurs.Add(joueur);
        }
        public void Detach(IJoueur joueur)
        {
            listJoueurs.Remove(joueur);
        }
        public void Notify()
        {
            foreach(IJoueur joueur in listJoueurs)
            {
                joueur.Update(this);
            }
            Console.WriteLine("");
        }
        public Joueur Ownership
        {
            get { return owner; }
            set
            {
                if(owner !=value)
                {
                    owner = value;
                    Notify();
                }
            }
        }
    }
}
