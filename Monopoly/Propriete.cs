using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Propriete : Case
    {
        private readonly string caseType;
        private string streetName;
        private int rent;
        private int price;
        private string actionName = null;

        public Propriete(string streetName, int rent, int price)
        {
            this.caseType = "Propriete";
            this.streetName = streetName;
            this.rent = rent;
            this.price = price;
        }
        public override string CaseType
        {
            get { return this.caseType; }
        }
        public override string StreetName
        {
            get { return this.streetName; }
            set { this.streetName = value; }
        }
        public override int Rent
        {
            get { return this.rent; }
            set { this.rent = value; }
        }
        public override int Price
        {
            get { return this.price; }
            set { this.price = value; }
        }
        public override string ActionName
        {
            get { return this.actionName; }
            set { this.actionName = value; }
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}