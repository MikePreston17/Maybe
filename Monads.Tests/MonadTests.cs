using DesignPatterns.Tests;
using Xunit;
using Xunit.Abstractions;

namespace Monads.Tests
{
    public class MonadTests : TestBase
    {
        static Car Car => CarFactory.Create();
        
        [Fact]
        public void CanModifyWithAction()
        {
            Print(Car.ToString());
            Print(Car.With(car => { car.Year = 2018; }).ToString());
        }

        [Fact]
        public void CanModifyWithFunction()
        {
            Print(Car.ToString());
            Print(Car.With(car => { car.Make = "Civic"; }).ToString());
        }

        public MonadTests(ITestOutputHelper output) 
            : base(output)
        {
        }
    }
}