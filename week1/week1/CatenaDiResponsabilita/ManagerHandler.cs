using System;
using System.Collections.Generic;
using System.Text;

namespace week1.CatenaDiResponsabilita
{
    class ManagerHandler : AbstractHandler
    {
        public override string Handle(double spese)
        {
            if(spese > 0 && spese <= 400)
            {

                return "Maneger";
            }
            else
            {
                return base.Handle(spese);
            }
            
        }
    }
}
