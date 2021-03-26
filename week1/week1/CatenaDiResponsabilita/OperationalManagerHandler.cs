using System;
using System.Collections.Generic;
using System.Text;

namespace week1.CatenaDiResponsabilita
{
    class OperationalManagerHandler : AbstractHandler
    {
        public override string Handle(double spese)
        {
            if (spese > 400 && spese <= 1000)
            {

                return "OperatorManeger";
            }
            else
            {
                return base.Handle(spese);
            }

        }
    }
}
