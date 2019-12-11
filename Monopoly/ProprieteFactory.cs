using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class ProprieteFactory : CaseFactory
    {
        private string streetName;
        private int startingValue;

        public ProprieteFactory(string streetName, string startintValue)
        {
            this.streetName = streetName;
            this.startingValue = startingValue;
        }

        public override Case getCase()
        {
            return new ProprieteFactory(this.streetName, this.startingValue);
        }
    }
}
