using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Monads.Tests
{
    public class EnumCases : TestBase
    {
        [Fact]
        public void Stuff()
        {
            var lookup = new Dictionary<LoggerLevel, Action<string>>
            {
                {LoggerLevel.Info, Print},
                {LoggerLevel.Warning, Print},
                {LoggerLevel.Error, Print},
                {LoggerLevel.Volcano, _ => Print("egads, execution errors everywhere, everyone!")}
            };
            
            LoggerLevel foundEnum = "VoLcAnO".Parse<LoggerLevel>();
            
            Print(foundEnum.ToString());

            var action = lookup.Case(foundEnum);
            action("test");
        }

        public EnumCases(ITestOutputHelper output) : base(output) { }
    }
    
    enum LoggerLevel 
    {
        Info = 1,
        Error = 2,
        Warning = 3,
        Volcano = 4
    }
}