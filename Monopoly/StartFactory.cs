using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class StartFactory : CaseFactory
    {
        private int departValue;

        public StartFactory(int departValue)
        {
            this.departValue = departValue;

        }

        public override Case GetCase()
        {
            return new StartFactory( this.departValue);
        }
    }
}