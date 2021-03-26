using System;
using System.Collections.Generic;
using System.Text;

namespace week1.CatenaDiResponsabilita
{
    public abstract class AbstractHandler : IHandler
    {
        //handler, elemento privato, successore
        private IHandler NextHandler;

        //Metodi
        public virtual string Handle(double spese)
        {
            //se ho un next handler
            if (this.NextHandler != null)
            {
                //ritorna il metodo dell'handler giusto
                return this.NextHandler.Handle(spese);
            }
            else
            {
                //altrimenti niente
                return null;
            }
        }

        public IHandler SetNext(IHandler handler)
        {
            NextHandler = handler;
            return handler;
        }
    }
}
