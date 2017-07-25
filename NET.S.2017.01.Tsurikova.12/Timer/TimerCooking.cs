using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Timer
{
    /// <summary>
    /// class providing data for Timer
    /// </summary>
    public class TimerEventArgs : EventArgs
    {
        /// <summary>
        /// name of product
        /// </summary>
        public string Product { get; }
        /// <summary>
        /// time for baking
        /// </summary>
        public TimeSpan Time { get; }

        public TimerEventArgs(string product, TimeSpan time)
        {
            if (string.IsNullOrEmpty(product)) throw new ArgumentException($"product must be known");
            if (time.Hours > 5) throw new ArgumentException("it's too long");
            Product = product;
            Time = time;
        }
    }

    /// <summary>
    /// class for sending messages for listeners
    /// </summary>
    public class TimerCooking
    {
        /// <summary>
        /// event of cooking something
        /// </summary>
        public event EventHandler<TimerEventArgs> Timer = delegate { };

        protected virtual void OnTimer(TimerEventArgs e)
        {
            EventHandler<TimerEventArgs> temp = Timer;
            temp?.Invoke(this, e);
        }

        /// <summary>
        /// starts timer
        /// </summary>
        /// <param name="product">producted to be baked</param>
        /// <param name="time">cooking time</param>
        public void StartCooking(string product, TimeSpan time)
        {
            Thread.Sleep(time);
            OnTimer(new TimerEventArgs(product, time));
        }
    }
}
