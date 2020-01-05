using System;

namespace DesignPatterns
{
    public static partial class Monad
    {
        // Peform an action on a value
        public static A With<A>(this A value, Action<A> action)
        {
            action(value);
            return value;
        }

        // Transform A to B by func
        // public static B With<A>( this A value, Func<A, B> func) => func(value);
    }
}