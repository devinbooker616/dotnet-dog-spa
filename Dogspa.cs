namespace dotnet_dog_spa
{
    class DogSpa
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public DogSpa(string services, string name, decimal price)
        {
            Name = name;
            Price = price;
        }

    }
}