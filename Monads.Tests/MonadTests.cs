using Xunit;
using Xunit.Abstractions;

namespace DesignPatterns.Tests
{
    public class MonadTests : TestBase
    {
        static Car Car => CarFactory.Create();
        
        [Fact]
        public void CanModifyWithAction()
        {
            Print(Car);
            Print(Car.With(car => { car.Year = 2018; }));
        }

        [Fact]
        public void CanModifyWithFunction()
        {
            Print(Car);
            Print(Car.With(car => { car.Make = "Civic"; }));
        }

        public MonadTests(ITestOutputHelper output) : base(output)
        {
        }

        public override void ObeysMonadicLaw()
        {
            throw new System.NotImplementedException();
        }
    }
}