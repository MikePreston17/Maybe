namespace DesignPatterns.Tests
{
    public class Car
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }

        // public Car With(string name = null, int year = 1979) =>
        //     new Car
        //     {
        //         Name = name ?? Name,
        //         Year = year
        //     };

        public override string ToString()
        {
            return $"{Name} {Model} {Year} {Make}";
        }
    }
}
