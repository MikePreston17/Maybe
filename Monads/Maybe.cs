using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns
{
    //Source from: https://www.pluralsight.com/tech-blog/maybe
    public struct Maybe<A>
    {
        readonly IEnumerable<A> values;

        public bool HasValue => values != null && values.Any();

        public static implicit operator Maybe<A>(A value) => Some(value);

        public static Maybe<A> Some(A value) => value != null
                ? new Maybe<A>(new[] { value })
                : throw new ArgumentNullException($"Cannot add a null value for a reference type like {typeof(A).Name}");

        public static Maybe<A> None => new Maybe<A>(new A[0]);

        public A Value => HasValue
                ? values.Single()
                : throw new Exception($"Maybe of type {typeof(A).Name} does not have a value");

        /// Source from: https://mikhail.io/2016/01/monads-explained-in-csharp/
        /// https://mikhail.io/2018/07/monads-explained-in-csharp-again/
        public Maybe(A value) => values = Enumerable.Repeat(value, 1);

        Maybe(IEnumerable<A> values) => this.values = values;

        public A ValueOrDefault(A @default) => HasValue
                ? values.Single()
                : @default;

        public A ValueOrThrow(Exception ex) => HasValue
                ? Value
                : throw ex;

        //Handle the cases where there is some value or there is none:
        public B Case<B>(Func<A, B> some, Func<B> none) => HasValue
                ? some(Value)
                : none();

        public Maybe<A> Case(Action<A> some, Action none)
        {
            if (HasValue)
                some(Value);
            else
                none();
            return this;
        }

        /// <summary>
        /// Performing an action if there is a value:
        /// 
        /// var maybeAccount = repository.Find(accountId);
        /// maybeAccount.IfSome(account =>
        /// {
        ///     account.LastUpdated = DateTimeOffset.UtcNow;
        ///     repository.Save(account);
        /// });
        /// </summary>
        public Maybe<A> IfSome(Action<A> some)
        {
            if (HasValue)
                some(Value);
            
            return this;
        }

        /// <summary>
        /// Source from : https://mikhail.io/2018/07/monads-explained-in-csharp-again/
        /// Sample Usage:
        /// Maybe<Shipper> shipperOfLastOrderOnCurrentAddress =
        ///     repo.GetCustomer(customerId)
        ///     .Bind(c => c.Address)
        ///     .Bind(a => repo.GetAddress(a.Id))
        ///     .Bind(a => a.LastOrder)
        ///     .Bind(lo => repo.GetOrder(lo.Id))
        ///     .Bind(o => o.Shipper);
        /// </summary>
        public Maybe<B> Bind<B>(Func<A, Maybe<B>> func) where B : class
        {
            var value = values.SingleOrDefault();
            return value != null ? func(value) : new Maybe<B>();
        }

        /// <summary>
        /// Map
        /// Maybe<string> maybeFirstName = maybeAccount.Map(account => account.FirstName);
        /// Maybe<IList<string>> emails = maybeAccount.Map(account => repository.GetEmailAddresses(account));
        /// </summary>
        public Maybe<B> Map<B>(Func<A, Maybe<B>> map) => HasValue
                ? map(Value)
                : Maybe<B>.None;

        public Maybe<B> Map<B>(Func<A, B> map) => HasValue
                ? Maybe.Some(map(Value))
                : Maybe<B>.None;
    }

    public static class Maybe
    {
        public static Maybe<A> Some<A>(A value) => 
            Maybe<A>.Some(value);
    }
}