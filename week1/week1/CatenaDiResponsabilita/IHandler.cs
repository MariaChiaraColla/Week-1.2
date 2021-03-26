using System;
using System.Collections.Generic;
using System.Text;

namespace week1.CatenaDiResponsabilita
{
    public interface IHandler
    {
        //passa la domanda al prossimo anello
        IHandler SetNext(IHandler handler);

        //rispondi alla domanda
        string Handle(double spese);
    }
}
