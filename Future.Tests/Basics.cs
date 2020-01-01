using System;
using System.Threading.Tasks;
using Futures;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        Action myAction;

        [SetUp]
        public void Setup()
        {
            myAction = new Action(() =>
            {
                Console.WriteLine("Running my action..."); 
            });
        }

        [Test]
        public void ActionExists()
        {
            Assert.IsNotNull(myAction);
            myAction();
        }

        [Test]
        public Task<object> CanRunActionAsPromise()
        {
            ActionExists();

            // var obj = new object();
            // var promise = new Future<object>(obj);

            // var speaker = await new SpeakerRepository().LoadSpeaker();
            // .Bind<>(speaker => speaker.NextTalk());
            throw new NotImplementedException();
        }
    }
}