using Xunit;
using Xunit.Abstractions;

namespace DesignPatterns.Tests
{
    public class MaybeTest : TestBase
    {
        [Fact]
        public void CanCreateMaybe()
        {
            var car = CarFactory.Create();
            var maybe = new Maybe<Car>(car);
            Assert.True(maybe.HasValue);
            maybe.IfSome(c => Print(c.ToString()));
        }

        [Fact]
        public void CanCreateEnumerableMaybe()
        {
            
        }

        public MaybeTest(ITestOutputHelper output) : base(output)
        {
        }
    }
}