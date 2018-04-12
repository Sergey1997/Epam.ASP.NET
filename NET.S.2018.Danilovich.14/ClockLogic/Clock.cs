using System;
using System.Threading;

namespace ClockLogic
{
    public class Clock
    {
        /// <summary>
        /// Delegate for stopping clock
        /// </summary>
        public event EventHandler<StopClockEventArgs> StopClock = delegate { };
        
        /// <summary>
        /// Start time of clock
        /// </summary>
        /// <param name="hour">uint</param>
        /// <param name="minute">uint</param>
        /// <param name="second">uint</param>
        public void StartTime(uint hour, uint minute, uint second)
        {
            int seconds = Convert.ToInt32((hour * 3600) + (minute * 60) + second);
            Console.WriteLine(seconds);
            while (seconds > 0)
            {
                seconds--;
                Console.WriteLine(seconds);
                Thread.Sleep(1000);
            }

            StopTime(new StopClockEventArgs(hour, minute, second));
        }

        /// <summary>
        /// stop the clocks after specified time
        /// </summary>
        /// <param name="e">event</param>
        private void StopTime(StopClockEventArgs e)
        {
            EventHandler<StopClockEventArgs> temp = StopClock;
            temp?.Invoke(this, e);
        }
    }
}
