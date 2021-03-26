using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using week1.CatenaDiResponsabilita;

namespace week1.GestioneEvento
{
    public static class GestioneEvento
    {
        //creo un nuovo file "file"
        //creo il gestore dell'evento che mi dici chi sta mandando l'evento e qual'è
        public static void Gestore(object sender, FileSystemEventArgs file)
        {
            List<Spesa> spese = new List<Spesa>();

            if (file.Name == "spese.txt")
            {
                Console.WriteLine("Un nuovo file è stato creato: " + file.Name);
                Console.WriteLine();

                //deve aspettare di finire di leggere il file
                Thread.Sleep(1000);

                //legge l'intero file
                using (StreamReader reader = File.OpenText(file.FullPath))
                {
                    //stampa il nome del file che sta leggendo
                    Console.WriteLine("- Inizio File:");
                    Console.WriteLine();
                    string line;

                    //leggo ogni riga finchè non è null
                    while ((line = reader.ReadLine()) != "")
                    {
                        Console.WriteLine(line);
                        string[] riga = line.Split(",");
                        Spesa spesa = new Spesa
                        {
                            Data = riga[0],
                            Categoria = riga[1],
                            Descrizione = riga[2],
                            Importo = Convert.ToDouble(riga[3])
                        };
                        spese.Add(spesa);
                    }
                    Console.WriteLine();
                    Console.WriteLine("- Fine File");
                    Console.WriteLine();

                    //chiudo il reader
                    reader.Close();

                    //factory
                    List<Double> Rimborsi = new List<double>();

                    foreach (var category in spese)
                    {
                        var categoria = category.Categoria;
                        var euro = category.Importo;
                        double rimborso = Factory.Factory.FatoryCategoria(categoria, euro);

                        Rimborsi.Add(rimborso);
                    }


                    //creo le istanze della catena di responsabilità
                    List<string> LivApprovazione = new List<string>();

                    var manager = new ManagerHandler();
                    var opManager = new OperationalManagerHandler();
                    var ceo = new CEOHandler();

                    //concateniamo i vari handler: monkey, dog, cat
                    manager.SetNext(opManager).SetNext(ceo);

                    //per ogno spesa la passo a chi la deve rimborsare
                    foreach (var soldi in spese)
                    {
                        Console.WriteLine("Spese: " + soldi.Importo);

                        //metto solo il primo anello della catena, che se non è lui la manda agli anelli dopo
                        var result = manager.Handle(soldi.Importo);

                        if (result != null)
                        {
                            Console.WriteLine(result);
                            LivApprovazione.Add(result);
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine(soldi.Importo + " non è stato pagatto da nessuno!");
                            LivApprovazione.Add("-");
                            Console.WriteLine();
                        }
                    }

                    //creo il nuovo file
                    List<Spesa> speseRimborsate = new List<Spesa>();

                    //scrivere su un file
                    using (StreamWriter writer = File.CreateText(@"C:\Users\maria.chiara.colla\Documents\EsamiAccademy\week1\Spese\spese_elaborate.txt"))
                    {
                        int i = 0;

                        foreach (var riga in spese)
                        {
                            if(LivApprovazione[i] != "-")
                            {
                                writer.WriteLine(riga.Data + "," +
                                riga.Categoria + "," +
                                riga.Descrizione + "," +
                                riga.Importo + "," +
                                "APPROVATA," +
                                LivApprovazione[i] + "," +
                                Rimborsi[i]);

                                i++;
                            }
                            else
                            {
                                writer.WriteLine(riga.Data + "," +
                                riga.Categoria + "," +
                                riga.Descrizione + "," +
                                riga.Importo + "," +
                                "NEGATA," +
                                LivApprovazione[i] + "," +
                                "-");

                                i++;
                            }
                            
                        }
                        
                        writer.Close();
                    }


                }   
            }

            return;
        }







    }
}
