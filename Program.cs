﻿using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace dotnet_dog_spa
{
    class Program
    {

        static Dictionary<string, Dictionary<string, DogSpa>> LoadMenu()
        {
            string spaOptions = File.ReadAllText(@"./services.json");
            return JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, DogSpa>>>(spaOptions);
        }

        static string GetService(Dictionary<string, Dictionary<string, DogSpa>> menu)
        {
            foreach (var service in menu)
            {
                foreach (var services in service.Value)
                {
                    Console.WriteLine($"service: {services.Value.Name} @ price: {services.Value.Price}");

                }
            }
            Console.Write("What service would you like: ");
            string choice = Console.ReadLine();
            foreach (var service in menu)
            {
                foreach (var services in service.Value)
                {
                    if (services.Value.Name == choice)
                    {
                        return choice;
                    }

                }
            }
            return "Do not work";
        }

        static decimal GetServicePrice(Dictionary<string, Dictionary<string, DogSpa>> menu, string userChoice)
        {
            foreach (var service in menu)
            {
                foreach (var services in service.Value)
                {
                    if (services.Value.Name == userChoice)
                    {
                        return services.Value.Price;
                    }
                }
            }
            return 0.00M;

        }

        static void WriteTransaction(DateTime time, string userChoice, decimal servicePrice)
        {
            File.AppendAllText("./transaction.txt", $"\n{time}, {userChoice}, {servicePrice}");
        }

        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, DogSpa>> menu = LoadMenu();
            string userChoice = GetService(menu);
            Console.WriteLine($"{userChoice} is an excellent choice! Your dog is going to love it!");
            decimal servicePrice = GetServicePrice(menu, userChoice);
            Console.WriteLine($"That is going to be {servicePrice} dollars");
            Console.WriteLine("Have a wonderful day!");
            DateTime time = DateTime.Now;
            WriteTransaction(time, userChoice, servicePrice);
        }
    }
}
