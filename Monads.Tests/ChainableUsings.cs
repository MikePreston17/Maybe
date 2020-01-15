using Xunit;

namespace Monads.Tests
{
    public class ChainableUsings
    {
        /// <summary>
        /// // Test whether we can dispose of a using + IDisposable inside a monad.
        /// <see cref="Session.cs"/>
        /// </summary>
        [Fact]
        public void CanChainUsings()
        {
            
            
           // var c = Connection("user=blah;pwd=1234");
           // var array = TArray<int>(1,2,3);
        }
        
        

        struct TArray<A>
        {
            static A[] values;
            static readonly A[] empty = new A[0];
            
            public static readonly TArray<A> Instance = default(TArray<A>);
            public static A[] Empty => empty;

            public TArray<A> Array(params A [] args)
            {
                values = args;
                return this;
            }
        }
    }
}