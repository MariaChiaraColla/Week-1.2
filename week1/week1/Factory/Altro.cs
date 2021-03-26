using System;
using System.Collections.Generic;
using System.Text;

namespace week1.Factory
{
    class Altro : ICategoria
    {
        public double Rimborso(double spese)
        {
            double soldi = (spese * 10) / 100;
            return spese - soldi;
        }

    }
}
