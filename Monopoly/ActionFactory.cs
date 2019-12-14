using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class ActionFactory : CaseFactory
    {
        private readonly string caseType;
        private string actionName;

        public ActionFactory(string actionName)
        {
            this.caseType = "Action";
            this.actionName = actionName;
        }
        public override Case GetCase()
        {
            return new Action(this.actionName);
        }
    }
}