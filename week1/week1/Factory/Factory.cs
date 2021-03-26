using System;
using System.Collections.Generic;
using System.Text;

namespace week1.Factory
{
    class Factory
    {
        //in base al cane che mi ritorna voglio farlo parlare
        public static double FatoryCategoria(string cat, double spese)
        {
            ICategoria categoria = null;

            if (cat.Equals("Viaggio"))
            {
                categoria = new Viaggio();
            }
            else if (cat.Equals("Alloggio"))
            {
                categoria = new Alloggio();
            }
            else if (cat.Equals("Vitto"))
            {
                categoria = new Vitto();
            }
            else if (cat.Equals("Altro"))
            {
                categoria = new Altro();
            }
            else
            {
                Console.WriteLine("Categoria non valida!");
                return 0;
            }

            double euro = categoria.Rimborso(spese);
            return euro;
        }
    }
}
