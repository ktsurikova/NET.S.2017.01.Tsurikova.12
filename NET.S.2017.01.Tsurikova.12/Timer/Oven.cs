using System;

namespace Timer
{
    /// <summary>
    /// class that responds to event
    /// </summary>
    public class Oven
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
            Console.WriteLine("OVEN");
            Console.WriteLine($"{eventArgs.Time} elapsed");
            Console.WriteLine("It's time to turn me off");
            Console.WriteLine($"your {eventArgs.Product} is waiting for you");
        }
    }
}
