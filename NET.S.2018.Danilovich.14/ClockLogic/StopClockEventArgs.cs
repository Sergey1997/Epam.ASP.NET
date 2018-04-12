using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockLogic
{
    public class StopClockEventArgs : EventArgs
    {
        #region Fields
        private uint second;
        private uint minute;
        private uint hour;
        #endregion

        #region Constructors
        /// <summary>
        /// Specify time
        /// </summary>
        /// <param name="hour">uint</param>
        /// <param name="minute">uint</param>
        /// <param name="second">uint</param>
        public StopClockEventArgs(uint hour, uint minute, uint second)
        {
            this.Second = second;
            this.Minute = minute;
            this.Hour = hour;
        }
        #endregion

        #region Properties
        public uint Second
        {
            get
            {
                return this.second;
            }

            set
            {
                while (value >= 60)
                {
                    value -= 60;
                    this.minute++;
                }

                this.second = value;
            }
        }

        public uint Minute
        {
            get
            {
                return this.minute;
            }

            set
            {
                while (value >= 60)
                {
                    value -= 60;
                    this.hour++;
                }

                this.minute = value;
            }
        }

        public uint Hour
        {
            get
            {
                return this.hour;
            }

            set
            {
                if (value >= 24)
                {
                    throw new ArgumentOutOfRangeException($"{ (value)} doesnt correct for hour");
                }

                this.hour = value;
            }
        }
        #endregion
    }
}
