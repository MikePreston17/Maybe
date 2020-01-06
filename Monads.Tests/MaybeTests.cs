using System;
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
            var carLot = CarRepo.Get();
            var maybe = Maybe.Some(carLot);
            
            Assert.True(maybe.HasValue);
            maybe.IfSome(cars =>
            {
                foreach (var car in cars)
                    Print(car);
            });
        }

        [Fact]
        public override void ObeysMonadicLaw()
        {
            // Left Identity:
            Car car = CarFactory.Create();
            Func<Car, Maybe<Car>> modify = myCar => myCar.With(name: "Tesla"); 

            Assert.Equal(new Maybe<Car>(car).Bind(modify).ToString(), modify(car).ToString());
            
            // Right Identity
            Maybe<Car> monad = new Maybe<Car>(car);
            Assert.Equal(monad.Bind(c => new Maybe<Car>(c)), monad);  //TODO: upgrade Maybe : Monad so as to auto-invoke the Equals override in Monad<A>
        }

        public MaybeTest(ITestOutputHelper output) : base(output)
        {
        }
    }
}