using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Action : Case
    {
        private readonly string caseType;
        private string actionName;
        private string streetName = null;
        private int rent = 0;
        private int price = 0;

        public Action(string actionName)
        {
            this.caseType = "Action";
            this.actionName = actionName;
        }
        public override string CaseType
        {
            get { return this.caseType; }
        }
        public override string ActionName
        {
            get { return this.actionName; }
            set { this.actionName = value; }
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
        public override string ToString()
        {
            return "sur la case "+streetName+" qui coute";
        }
    }
}
