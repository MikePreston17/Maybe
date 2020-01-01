using Futures;

namespace Tests
{
    public class SpeakerRepository {
        
      public Future< Speaker> LoadSpeaker() =>  new Future<Speaker>(new Speaker());
    }
    
    public class Conference
    {
        public City GetCity() => new City();
    }

    public class Speaker
    {
      public  Talk NextTalk() => new Talk();
    }

    public class City
    {
        public Reservations Reservations = new Reservations();
    }

    public class   Reservations
    {
        public   bool BookFlight(City city) => true;
    }

    public class  Talk
    {
        public    Conference GetConference() => new Conference();
    }
}