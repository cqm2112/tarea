using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    static class Menu
    {
        public static void Render(List<Option> options)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                options.ForEach(d =>
                {
                    Console.WriteLine(d.Description);
                });
                Console.WriteLine("X - Salir");
                Console.Write("Opcion: ");
                string selectedOpt = (Console.ReadLine() + "").ToLower();
                exit = selectedOpt == "x";
                if (exit)
                {
                    Console.WriteLine("Hablamo");
                    Thread.Sleep(1500);
                    break;
                }
                var option = options.FirstOrDefault(u => u.Key == selectedOpt);
                if (option == null)
                {
                    Console.WriteLine("La opcion no existe, bobo");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
                Console.Clear();
                option.Function();
                Console.ReadKey();
            }
        }
    }

    class Option
    {
        public string ID { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
        public delegate void Invoker();
        public Invoker Function;
        
        public Option(string key, string description, Invoker function, string id = "")
        {
            ID = id;
            Key = key;
            Description = description;
            Function = function;
        }
    }
}
