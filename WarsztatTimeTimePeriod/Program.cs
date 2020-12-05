using System;

namespace WarsztatTimeTimePeriod
{
    class Program
    {
        static void Main(string[] args)
        {
            //var input = "1:59:59";
            var time = new Time(12);
            var time2 = new Time(12);
            var timeperiod = new TimePeriod(12);
            Console.WriteLine(time + timeperiod);
            Console.WriteLine(time >= time2);
            Console.WriteLine(time.Plus(timeperiod));
        }

        
    }
}
