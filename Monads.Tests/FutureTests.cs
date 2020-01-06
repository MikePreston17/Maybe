using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace DesignPatterns.Tests
{
    public class FutureActions : TestBase
    {
        readonly Action myAction;

        [Fact]
        public void ActionExists()
        {
            Assert.NotNull(myAction);
            myAction();
        }

        [Fact]
        public Task<object> CanRunActionAsPromise()
        {
            ActionExists();

            // var obj = new object();
            // var promise = new Future<object>(obj);

            // var speaker = await new SpeakerRepository().LoadSpeaker();
            // .Bind<>(speaker => speaker.NextTalk());
            throw new NotImplementedException();
        }
        
        public FutureActions(ITestOutputHelper helper) :base(helper) =>
            myAction = () => Console.WriteLine("Running my action...");

        public override void ObeysMonadicLaw()
        {
            throw new NotImplementedException();
        }
    }
}
