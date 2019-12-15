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
        private Joueur owner;

        public Propriete(string streetName, int rent, int price)
        {
            this.caseType = "Propriete";
            this.streetName = streetName;
            this.rent = rent;
            this.price = price;
            owner = null;
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
        public override Joueur Owner
        {
            get { return owner; }
        }
        public override string ToString()
        {
            if (owner == null)
            {
                return this.streetName + "\tcout : " + this.price;
            }
            else
            {
                return this.streetName + "\tTu doit payer : " + this.rent +"\ta : "+this.owner;
            }
        }
        public override bool GetBuy(Joueur acheteur)
        {
            acheteur.Paye(this.price);
            this.owner = acheteur;
            return true;
        }
    }
}