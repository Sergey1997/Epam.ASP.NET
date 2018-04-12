using System;

namespace ClockLogic
{
    public class Euroopt
    {
        public Euroopt()
        {
        }

        public void Register(Clock clock)
        {
            clock.StopClock += Handler;
            Console.WriteLine($"{this.GetType().Name} registred.");
        }

        public void Unregister(Clock clock)
        {
            clock.StopClock -= Handler;
            Console.WriteLine($"{this.GetType().Name} unregistred.");
        }

        private void Handler(object sender, StopClockEventArgs eventArgs)
        {
            Console.WriteLine($"{this.GetType().Name} got message throught {eventArgs.Hour} hours {eventArgs.Minute} minutes {eventArgs.Second} seconds");
        }
    }
}
