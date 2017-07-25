using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer;

namespace Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            TimerCooking timer = new TimerCooking();
            Cook cook = new Cook();
            cook.Register(timer);
            Oven oven = new Oven();
            oven.Register(timer);

            timer.StartCooking("fish", new TimeSpan(0, 0, 3));
            oven.Unregister(timer);
            timer.StartCooking("cake", new TimeSpan(0, 0, 3));

            Console.ReadLine();
        }
    }
}
