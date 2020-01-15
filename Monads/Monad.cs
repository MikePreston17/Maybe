using System;

namespace DesignPatterns
{
    /*
    * Big three functions like: 
        https://www.toptal.com/javascript/option-maybe-either-future-monads-js 
    */     
    public abstract partial class Monad<A> : Base
    {
        public abstract Monad<A> Pure(A value);
        public abstract Monad<B> FlatMap<B>(Func<B, Monad<A>> functor);
        public virtual Monad<B> Map<B>(Func<B, A> transform) => FlatMap<B>(b => Pure(transform(b)));
    }

    /// The Identity Monad -  All it does is hold values and bind functors (Lifters)
    public abstract partial class Monad<A>
    {
        public A Value { get; }
        public Monad(A value) => Value = value;
        public virtual Monad<B> Bind<B>(Func<A, Monad<B>> functor) => functor(Value);
    }

    // public interface IFreeMonad<A>
    // {
    //      Monad<A> Map<A>(Func<A> func);  // => this.FlatMap(x => new this.Pure(func(x)));
    //      Monad<A> FlatMap<B>(A instance);// => throw new NotImplementedException();
    // }
    //
    // public interface IPureMonad<A>
    // {
    //     Monad<A> Pure(A a);
    //     Monad<A> Return();
    // }

    // public class PureMonad<A> : IPureMonad<A>
    // {
    //     public Monad<A> Pure(A a) => throw new NotImplementedException();
    //
    //     public Monad<A> Return() => throw new NotImplementedException();
    // }

    // public sealed class PureMonadAdapter<A> : IFreeMonad<A>
    // {
    //     IFreeMonad<A> freeMonad;
    //     PureMonadAdapter(IFreeMonad<A> freeMonad) => this.freeMonad = freeMonad;
    //
    //     public Monad<A> Map<A>(Func<A> func) => throw new NotImplementedException();
    //
    //     public Monad<A> FlatMap<B>(A instance) => throw new NotImplementedException();
    // }
    // public sealed class FreeMonadAdapter<A> : IPureMonad<A>
    // {
    //     Monad<A> monad;
    //     FreeMonadAdapter(A value) => monad = new Monad<A>(value);
    //     public Monad<A> Pure(A a) => throw new NotImplementedException();
    //     public Monad<A> Return() => throw new NotImplementedException();
    // }

}