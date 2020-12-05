using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;

namespace WarsztatTimeTimePeriod
{
    public readonly struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
        public readonly long Seconds;
        public TimePeriod(int hours,int minutes, int seconds)
        {
            if(minutes>59 || seconds > 59)
            {
                throw new Exception("Minutes and seconds cant be higher than 59");
            }
                Seconds = (hours * 60 * 60) + (minutes * 60) + seconds;
        }
        public TimePeriod(int hours, int minutes)
        {
            if (minutes > 59)
            {
                throw new Exception("Minutes and seconds cant be higher than 59");
            }
            Seconds = (hours * 60 * 60) + (minutes * 60);
        }
        public TimePeriod(int seconds)
        {

            Seconds = seconds;
        }
        public TimePeriod(Time time1, Time time2)
        {
            if(time1._seconds > time2._seconds)
                Seconds = time1._seconds - time2._seconds;
            else
                Seconds = time2._seconds - time1._seconds;
        }
        public override string ToString()
        {
            return $"{Seconds / 3600:00}:{(Seconds % 3600) / 60:00}:{Seconds % 60:00}";
        }

        public int CompareTo(TimePeriod other)
        {
            if (other == null) return 1;

            return this.Seconds.CompareTo(other.Seconds);
        }
        public static bool operator ==(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            if (((object)timePeriod1) == null || ((object)timePeriod2) == null)
                return Object.Equals(timePeriod1, timePeriod2);

            return timePeriod1.Equals(timePeriod2);
        }
        public static bool operator !=(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            if (((object)timePeriod1) == null || ((object)timePeriod2) == null)
                return !Object.Equals(timePeriod1, timePeriod2);

            return !(timePeriod1.Equals(timePeriod2));
        }
        public static bool operator >(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            return timePeriod1.CompareTo(timePeriod2) == 1;
        }
        public static bool operator <(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            return timePeriod1.CompareTo(timePeriod2) == -1;
        }
        public static bool operator >=(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            return timePeriod1.CompareTo(timePeriod2) == 0;
        }
        public static bool operator <=(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            return timePeriod1.CompareTo(timePeriod2) == 0;
        }

        public bool Equals(TimePeriod other)
        {
            if (other == null)
                return false;

            if (this.Seconds == other.Seconds)
                return true;
            else
                return false;
        }
        public TimePeriod Plus(TimePeriod timePeriod)
        {
            var newTime = Seconds + timePeriod.Seconds;
            return new TimePeriod(Convert.ToByte(newTime / 3600),
                Convert.ToByte((newTime % 3600) / 60),
                Convert.ToByte(newTime % 60));
        }
        public TimePeriod Minus(TimePeriod timePeriod)
        {
            if (Seconds > timePeriod.Seconds)
            {
                var newTime = Seconds - timePeriod.Seconds;
                return new TimePeriod(Convert.ToByte(newTime / 3600),
                Convert.ToByte((newTime % 3600) / 60),
                Convert.ToByte(newTime % 60));
            }
            else
            {
                throw new Exception("Returned TimePeriod cant be lower than 0 ");
            }

        }
        public static TimePeriod Plus(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            var newTime = timePeriod1.Seconds + timePeriod1.Seconds;
            return new TimePeriod(Convert.ToByte(newTime / 3600),
                Convert.ToByte((newTime % 3600) / 60),
                Convert.ToByte(newTime % 60));
        }
        public static TimePeriod Minus(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            if(timePeriod1.Seconds > timePeriod2.Seconds)
            {
                var newTime = timePeriod1.Seconds - timePeriod2.Seconds;
                return new TimePeriod(Convert.ToByte(newTime / 3600),
                Convert.ToByte((newTime % 3600) / 60),
                Convert.ToByte(newTime % 60));
            }
            else
            {
                var newTime = timePeriod2.Seconds - timePeriod1.Seconds;
                return new TimePeriod(Convert.ToByte(newTime / 3600),
                Convert.ToByte((newTime % 3600) / 60),
                Convert.ToByte(newTime % 60));
            }
        }
        public static TimePeriod operator +(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            return Plus(timePeriod1, timePeriod2);
        }
        public static TimePeriod operator -(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            return Minus(timePeriod1, timePeriod2);
        }
    }
}
