using ClockLogic;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            Prostore prostore = new Prostore();
            Euroopt euroopt = new Euroopt();
            prostore.Register(clock);
            euroopt.Register(clock);
            clock.StartTime(0, 1, 3);
            prostore.Unregister(clock);
            clock.StartTime(0, 1, 2);
        }
    }
}
