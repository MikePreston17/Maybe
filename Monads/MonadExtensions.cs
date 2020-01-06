using System;

namespace DesignPatterns
{
    public static partial class Monad
    {
        public static A With<A>(this A value, Action<A> action)
        {
            action(value);
            return value;
        }
    }
}