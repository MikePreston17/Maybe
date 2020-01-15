using System;
using DesignPatterns;
using DesignPatterns.Tests;
using Xunit;
using Xunit.Abstractions;

namespace Monads.Tests
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
                    Print(car.ToString());
            });
        }

        public void ObeysMonadicLaws()
        {
            // Left Identity:
            Car car = CarFactory.Create();
            Func<Car, Maybe<Car>> modify = myCar => myCar.With(name: "Tesla"); 

            Assert.Equal(new Maybe<Car>(car).Bind(modify).ToString(), modify(car).ToString());
            
            // Right Identity:
            Maybe<Car> monad = new Maybe<Car>(car);
            // Assert.Equal(monad.Bind(c => new Maybe<Car>(c)), monad);  //TODO: upgrade Maybe : Monad so as to auto-invoke the Equals override in Monad<A>
            
            // Associativity:
            // Monad<T> m;
            // Func<T, Monad<U>> f;
            // Func<U, Monad<V>> g;
            
            // m.Bind(f).Bind(g) == m.Bind(a => f(a).Bind(g))
        }

        public void TestFunc<T, C>(T monad) where T : Monad<C>
        {
            
        }

        public  abstract class MonadicClass<T, C> where T :  Monad<C>
        {
            
        }
        
        public MaybeTest(ITestOutputHelper output) : base(output)
        {
        }

    }
}