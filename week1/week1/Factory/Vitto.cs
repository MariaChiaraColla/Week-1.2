using System;
using System.Collections.Generic;
using System.Text;

namespace week1.Factory
{
    class Vitto : ICategoria
    {
        public double Rimborso(double spese)
        {
            double soldi = (spese * 70) / 100;
            return spese - soldi;
        }
    }
}
