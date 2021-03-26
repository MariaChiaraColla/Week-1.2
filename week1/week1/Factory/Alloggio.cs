using System;
using System.Collections.Generic;
using System.Text;

namespace week1.Factory
{
    class Alloggio : ICategoria
    {
        public double Rimborso(double spese)
        {
            return spese;
        }
    }
}
