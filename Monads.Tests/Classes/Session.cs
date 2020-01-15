using System;
using System.Diagnostics;

namespace DesignPatterns.Tests
{
    // For testing whether we can dispose of a using + IDisposable inside a monad.
    public sealed class Connection : IDisposable, IConnection
    {
        public readonly string ConnectionString;

        public Connection(string connectionString)
        {
            ConnectionString = connectionString;
            // ... Some SQL connection wiring up
            Console.WriteLine("Connected to client!");
        }

        public void Dispose()
        {
            string message = "Connection disposed.";
            Console.WriteLine(message);
            Debug.WriteLine(message);
        }

        public Connection Close()
        {
            Dispose();
            return this;
        }
    }

    public interface IConnection
    {
        Connection Close();
    }

    // public sealed class TestClass
    // {
    //     IConnection DoSomething()
    //     {
    //         return this;
    //     }
    // }
    //
}