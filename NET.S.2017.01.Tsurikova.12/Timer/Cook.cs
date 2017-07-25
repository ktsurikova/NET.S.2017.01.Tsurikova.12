using System;

namespace Timer
{
    /// <summary>
    /// class that responds to event
    /// </summary>
    public class Cook
    {
        /// <summary>
        /// registrate for event
        /// </summary>
        /// <param name="timer">occuring event</param>
        public void Register(TimerCooking timer) => timer.Timer += Bake;

        /// <summary>
        /// unregistrate for event
        /// </summary>
        /// <param name="timer">occuring event</param>
        public void Unregister(TimerCooking timer) => timer.Timer -= Bake;

        /// <summary>
        /// responds to event
        /// </summary>
        /// <param name="sender">sender of event</param>
        /// <param name="eventArgs">data of event</param>
        private void Bake(object sender, TimerEventArgs eventArgs)
        {
            Console.WriteLine("COOK");
            Console.WriteLine($"time {eventArgs.Time} is elapsed");
            Console.WriteLine($"{eventArgs.Product} is baked");
        }
    }
}
