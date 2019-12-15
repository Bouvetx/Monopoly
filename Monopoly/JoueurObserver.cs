using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class JoueurObserver : IJoueur
    {
        private string pion;
        private Observer observ;

        public JoueurObserver(string pion)
        {
            this.pion = pion;
        }

        public void Update(Observer observ)
        {
            Console.WriteLine("Notified "+pion+" of "+ observ.GetType().Name+" "+observ.Ownership);
        }
    }
}
