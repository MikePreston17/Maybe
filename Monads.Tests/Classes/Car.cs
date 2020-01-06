using System;

namespace DesignPatterns.Tests
{
    public class Car
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }

        public Car With(string name = null, int year = 1979, string make = null, string model = null ) =>
            new Car
            {
                Name = name ?? Name,
                Make = make ?? Make,
                Model = model ?? Model,
                Year = year,
            };

        public override string ToString()
        {
            return $"{Name} {Model} {Year} {Make}";
        }

        public bool Equals(Car other)
        {
            return ToString().Equals(other.ToString());
        }
    }
}
