using System;
using Xunit.Abstractions;

namespace Monads.Tests
{
    public abstract class TestBase
    {
        public Action<string> Print;
        protected TestBase(ITestOutputHelper output) => Print = output.WriteLine;

        // public void Print(string s) => logger.WriteLine(s);
        // public void Print<T>(T obj) => Print(obj.ToString());
        
        // [Fact]
        // public abstract void ObeysMonadicLaws();
    }

    // class MonadicLawman<M, T> where M : Monad<T>
    // {
    //     readonly Func<Car, M<T>> modification = myObject => { return myObject; }; //myObject.With(name: "Tesla");
    //
    //     public bool LeftIdentity<A, M<A>>(A value, Monad<A> monad)
    //     {
    //         Car car = CarFactory.Create();
    //         Assert.Equal(new Maybe<Car>(car).Bind(modification).ToString(), modification(car).ToString());
    //     }
    // }
    
    // class MonadicLaws<A, M>
    // {
    //     public bool ObeysMonadicLaws()
    //     {
    //         return RightIdentity<A>(null, null);
    //     }
    //     
    //     public bool RightIdentity<A, M<A>>(A value, Monad<A> monad) //where A: class
    //         // where A : class
    //     {
    //         // Left Identity:
    //         // Car car = CarFactory.Create();
    //         // Func<Car, Maybe<Car>> modify = myCar => myCar.With(name: "Tesla"); 
    //         //
    //         // Assert.Equal(new Maybe<Car>(car).Bind(modify).ToString(), modify(car).ToString());
    //         //
    //         // // Right Identity:
    //         // Maybe<Car> monad = new Maybe<Car>(car);
    //         // // Assert.Equal(monad.Bind(c => new Maybe<Car>(c)), monad);  //TODO: upgrade Maybe : Monad so as to auto-invoke the Equals override in Monad<A>
    //         //
    //         // // Associativity:
    //         // // Monad<T> m;
    //         // // Func<T, Monad<U>> f;
    //         // // Func<U, Monad<V>> g;
    //         //
    //         // // m.Bind(f).Bind(g) == m.Bind(a => f(a).Bind(g))
    //         return true;
    //     }
    // }
    
}