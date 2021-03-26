using System;
using System.Collections.Generic;
using System.Text;

namespace week1.Factory
{
    class Viaggio : ICategoria
    {
        public double Rimborso(double spese)
        {
            return spese + 50;
        }
    }
}
