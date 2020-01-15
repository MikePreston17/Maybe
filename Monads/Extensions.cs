using System;
using System.Collections.Generic;

namespace Monads
{
    public static partial class Extensions
    {
        public static A With<A>(this A value, Action<A> action)
        {
            action(value);
            return value;
        }

        public static E Parse<E>(this string input) where E : struct, IConvertible =>
            (E) Enum.Parse(typeof(E), input, true);

        public static void Case<E, V>(this IDictionary<E, Action<V>>lookup,E expected,  V input)
            where E : struct, IConvertible
        {
            var action = lookup.Case(expected);
            action(input);
        }
        
        public static Action<V> Case<E, V>(this IDictionary<E, Action<V>>lookup, E expected)
            where E : struct, IConvertible
        {
            if(lookup.Count == 0) 
                throw new ArgumentException($"{nameof(lookup)} cannot not be empty!");
            lookup.TryGetValue(expected, out var action);
            return action ?? throw new ArgumentException($"No action found for enum <{typeof(E).Name}>!");
        }
    }
}