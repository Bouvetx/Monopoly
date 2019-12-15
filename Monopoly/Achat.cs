using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Achat : Observer
    {
        public Achat(Joueur own): base(own) { }
    }
}
