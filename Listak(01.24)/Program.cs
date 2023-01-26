using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Listak_01._24_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> DB = new List<int>();
            List<int> ParosDB = new List<int>();
            List<int> ParatlanDB = new List<int>();
            List<int> KisebbDB = new List<int>();
            List<int> NagyobbDB = new List<int>();

            StreamWriter listakiir = new StreamWriter("Lista.txt", false, Encoding.UTF8);

            Random r = new Random();
            for (int i = 0; i < 1000; i++)
            {
                DB.Add(r.Next(-350, 450));
            }
            
            foreach (var item in DB)
            {
                if (item % 2 == 0)
                {
                    ParosDB.Add(item);
                }
                else
                    ParatlanDB.Add(item);
            }

            StreamWriter sw = new StreamWriter("Páros.txt", false, Encoding.UTF8);
            Console.WriteLine($"[Páros elemek]");
            listakiir.Write($"\n\n[Páros elemek]");

            foreach (var item in ParosDB)
            {
                Console.Write($"{item};");
                sw.Write($"{item};");
                listakiir.Write($"{item}");
            }
            sw.Flush();
            sw.Close();

            StreamWriter swr = new StreamWriter("Páratlan.txt", false, Encoding.UTF8);
            Console.WriteLine($"\n\n[Páratlan elemek]");
            listakiir.Write($"\n\n[Páratlan elemek]");

            foreach (var item in ParatlanDB)
            {
                Console.Write($"{item};");
                swr.Write($"{item};");
                listakiir.Write($"{item}");
            }
            foreach (var item in DB)
            {
                if (item >= 100)
                {
                    NagyobbDB.Add(item);
                }
                else
                {
                    KisebbDB.Add(item);
                }
            }
            swr.Flush();
            swr.Close();

            StreamWriter srl = new StreamWriter("Értékkészlet.txt", false, Encoding.UTF8);
            Console.WriteLine("\n\n[Nagyobb számok listája]");
            srl.WriteLine("[Nagyobb számok listája]");
            listakiir.Write($"\n\n[Nagyobb számok listája]");
            foreach (var item in NagyobbDB)
            {
                Console.Write($"{item}  ");
                srl.Write($"{item};");
                listakiir.Write($"{item}");
            }
            Console.WriteLine("\n\n[Kisebb számok listája]");
            srl.WriteLine("\n\n[Kisebb számok listája]");
            listakiir.Write($"\n\n[Kisebb számok listája]");
            foreach (var item in KisebbDB)
            {
                Console.Write($"{item} ");
                srl.Write($"{item};");
                listakiir.Write($"{item}");
            }
            srl.Flush();
            srl.Close();

            Console.ReadKey(true);

            Console.WriteLine("\n\nA Páros.txt tartalma importálva > ");

            StreamReader import = new StreamReader("Páros.txt");
            string importTartalom;
            while (!import.EndOfStream)
            {
                importTartalom = import.ReadLine();
                //Console.WriteLine(importTartalom);
                string[] tartalom = importTartalom.Split(';');
                StreamWriter export = new StreamWriter("PárosLista.txt", false, Encoding.UTF8);
                export.WriteLine("A Páros lista tartalma:");
                foreach (var item in tartalom)
                {
                    Console.WriteLine(item);
                    export.WriteLine(item);
                    listakiir.Write($"{item}");
                }
                export.Flush();
                export.Close();

                listakiir.Flush();
                listakiir.Close();
            }


            Console.ReadKey(true);
        }
    }
}
