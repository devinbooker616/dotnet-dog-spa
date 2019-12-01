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
            foreach (var service in menu)
            {
                foreach (var services in service.Value)
                {
                    Console.WriteLine($"service: {services.Value.name} @ price: {services.Value.price}");

                }
            }
            Console.Write("What service would you like: ");
            string choice = Console.ReadLine();
            foreach (var service in menu)
            {
                foreach (var services in service.Value)
                {
                    if (services.Value.name == choice)
                    {
                        return choice;
                    }

                }
            }
            return "Do not work";
        }

        static decimal GetServicePrice(Dictionary<string, Dictionary<string, dynamic>> menu, string userChoice)
        {
            foreach (var service in menu)
            {
                foreach (var services in service.Value)
                {
                    if (services.Value.name == userChoice)
                    {
                        return services.Value.price;
                    }
                }
            }
            return 0.00M;

        }


        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, dynamic>> menu = LoadMenu();
            string userChoice = GetService(menu);
            Console.WriteLine(userChoice);
            decimal servicePrice = GetServicePrice(menu, userChoice);
            Console.WriteLine(servicePrice);
            DateTime time = DateTime.Now;
            Console.WriteLine(time);
        }
    }
}
