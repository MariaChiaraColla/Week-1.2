using System;
using System.Collections.Generic;
using System.Text;

namespace week1.CatenaDiResponsabilita
{
    class CEOHandler : AbstractHandler
    {
        public override string Handle(double spese)
        {
            if (spese > 1000 && spese <= 2500)
            {

                return "CEO";
            }
            else
            {
                return base.Handle(spese);
            }

        }
    }
}
