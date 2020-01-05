
namespace DesignPatterns.Tests
{
    public class CarFactory
    {
        public static Car Create() => new Car
        {
            Model = "TL", Name = "Acura", Year = 2012
        };
    }

    public class CarRepo
    {
        public static Car [] Get() => new Car[]
        {
            new Car
            {
                Model = "Civic", Name = "Honda", Year = 2018
            },
            new Car
            {
                Model = "TL", Name = "Acura", Year = 2012
            },
        };
    }
}