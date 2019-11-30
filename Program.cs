using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace dotnet_dog_spa
{
    class Program
    {

        static Dictionary<string, Dictionary<string, dynamic>> LoadMenu()
        {
            string spaOptions = File.ReadAllText(@"./services.json");
            return JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, dynamic>>>(spaOptions);
        }

        static string GetService(Dictionary<string, Dictionary<string, dynamic>> menu)
        {
            menu = LoadMenu();
            foreach (var service in menu)
            {
                foreach (var services in service.Value)
                {
                    Console.WriteLine($"service: {services.Value.name} @ price: {services.Value.price}");

                }
            }
            Console.Write("What service would you like: ");
            string choice = Console.ReadLine();
            foreach (var services in menu)
            {
                foreach (var service in services.Value)
                {
                    if (choice == service.Value.Name)
                    {
                        return choice;
                    }
                }
            }
        }


        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, dynamic>> menu = LoadMenu();
            foreach (var service in menu)
            {
                foreach (var services in service.Value)
                {
                    Console.Write(">>> ");
                    string name = Console.ReadLine();
                    if (name == services.Key)
                    {
                        Console.WriteLine(services.Key);
                        Console.WriteLine(services.Value.price);
                    }

                }
            }
        }
    }
}
