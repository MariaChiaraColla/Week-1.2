using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace week1.GestioneEvento
{
    public static class Watcher
    {
        public static void Guardia()
        {
            Console.WriteLine("Inizio il monitoraggio della cartella: \"Spese\" ");

            //creo il watche: ovvero la guardia che controlla i file nel file system
            FileSystemWatcher guardia = new FileSystemWatcher();

            //posizione della guardia nella cartella
            guardia.Path = @"C:\Users\maria.chiara.colla\Documents\EsamiAccademy\week1\Spese";

            //deve guardare solo i file .txt
            guardia.Filter = "*.txt";

            //del file controlla: il nome(nel caso in cui lo trascino dentro)
            guardia.NotifyFilter = NotifyFilters.FileName;

            //registra tutti gli eventi e le notifiche
            guardia.EnableRaisingEvents = true;

            //multicast delegate: alla creazione di un file, gestisci con Gestore Eventi
            guardia.Created += GestioneEvento.Gestore;

            Console.WriteLine("Press q to exit");
            while (Console.Read() != 'q') ;
        }
    }
}
