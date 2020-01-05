using System;

namespace DesignPatterns
{
    /*
     * TODO Make this like these functions: https://www.toptal.com/javascript/option-maybe-either-future-monads-js 
     */
    
    /// The Identity Monad
    internal abstract partial class Monad<A> : Base
    {
        public A Value { get; }
        public Monad(A value) => Value = value;
        public virtual Monad<B> Bind<B>(Func<A, Monad<B>> functor) => functor(Value);

        // public virtual Monad<A> Return=> new Monad<A>();
        // public Monad<A> Pure(A a);
        // public virtual Monad<A> FlatMap<B>(A instance) => throw new NotImplementedException();
        // public virtual Monad<T> Map<T>(Func<T> func) => this.FlatMap(x => new this.Pure(func(x)));
    }

    public partial interface IMonad
    {
        
    }

}