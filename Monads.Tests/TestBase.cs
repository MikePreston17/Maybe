using Xunit.Abstractions;

namespace DesignPatterns.Tests
{
    public class TestBase
    {
        readonly ITestOutputHelper logger;
        protected TestBase(ITestOutputHelper output) => logger = output;

        public void Print(string s) => logger.WriteLine(s);
        public void Print<T>(T obj) => Print(obj.ToString());
    }
}