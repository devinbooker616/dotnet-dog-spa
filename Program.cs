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
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, dynamic>> menu = LoadMenu();
            foreach (var service in menu)
            {
                foreach (var services in service.Value)
                {
                    Console.WriteLine(services);
                }
            }
        }
    }
}
