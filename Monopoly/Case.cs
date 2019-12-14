using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public abstract class Case
    {
        public abstract string CaseType { get; }
        public abstract string StreetName { get; set; }
        public abstract int Rent { get; set; }
        public abstract int Price { get; set; }

        public abstract string ActionName { get; set; }

    }
}
