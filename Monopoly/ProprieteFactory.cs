using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class ProprieteFactory : CaseFactory
    {
        private readonly string caseType;
        private string streetName;
        private int rent;
        private int price;

        public ProprieteFactory(string streetName, int rent, int price)
        {
            this.caseType = "Proprieté";
            this.streetName = streetName;
            this.rent = rent;
            this.price = price;
        }

        public override Case GetCase()
        {
            return new Propriete(this.streetName, this.rent, this.price);
        }
    }
}
