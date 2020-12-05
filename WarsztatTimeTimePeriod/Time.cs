using System;
using System.Diagnostics.CodeAnalysis;

namespace WarsztatTimeTimePeriod
{
    public readonly struct Time : IEquatable<Time>, IComparable<Time>
    {

        public readonly long _seconds;
        public byte Hours { get; }
        public byte Minutes { get; }
        public byte Seconds { get;}

        public Time(byte hours,byte minutes, byte seconds)
        {
            if (hours > 23 || minutes > 59 || seconds > 59)
            {
                throw new Exception("Wrong data format");
            }

            _seconds = (hours * 3600) + (minutes * 60) + seconds;
            Hours = Convert.ToByte(_seconds / 3600);
            Minutes = Convert.ToByte((_seconds % 3600) / 60);
            Seconds = Convert.ToByte(_seconds % 60);
        }
        public Time(byte hours, byte minutes)
        {
            if (hours > 23 || minutes > 59)
            {
                throw new Exception("Wrong data format");
            }

            _seconds = (hours * 3600) + (minutes * 60);
            Hours = Convert.ToByte(_seconds / 3600);
            Minutes = Convert.ToByte((_seconds % 3600) / 60);
            Seconds = Convert.ToByte(_seconds % 60);
        }
        public Time(byte hours)
        {
            if (hours > 23)
            {
                throw new Exception("Wrong data format");
            }

            _seconds = (hours * 3600);
            Hours = Convert.ToByte(_seconds / 3600);
            Minutes = Convert.ToByte((_seconds % 3600) / 60);
            Seconds = Convert.ToByte(_seconds % 60);
        }
        public Time(string input)
        {
            var time = input.Split(":");
            byte hours = Convert.ToByte(time[0]);
            byte minutes = Convert.ToByte(time[1]);
            byte seconds = Convert.ToByte(time[2]);

            if (hours > 23 || minutes > 59 || seconds > 59)
            {
                throw new Exception("Wrong data format");
            }

            _seconds = (hours * 3600) + (minutes * 60) + seconds;
            Hours = Convert.ToByte(_seconds / 3600);
            Minutes = Convert.ToByte((_seconds % 3600) / 60);
            Seconds = Convert.ToByte(_seconds % 60);
        }
        public override string ToString()
        {
            return $"{Hours:00}:{Minutes:00}:{Seconds:00}";
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public bool Equals(Time other)
        {
            if (other == null)
                return false;

            if (this._seconds == other._seconds)
                return true;
            else
                return false;
        }

        public static bool operator == (Time time1, Time time2)
        {
            if (((object)time1) == null || ((object)time2) == null)
                return Object.Equals(time1, time2);

            return time1.Equals(time2);
        }
        public static bool operator != (Time time1, Time time2)
        {
            if (((object)time1) == null || ((object)time2) == null)
                return ! Object.Equals(time1, time2);

            return ! (time1.Equals(time2));
        }
        public int CompareTo(Time other)
        {
           if(other == null) return 1;

            return this._seconds.CompareTo(other._seconds);
        }
        public static bool operator > (Time time1, Time time2)
        {
            return time1.CompareTo(time2) == 1;
        }
        public static bool operator < (Time time1, Time time2)
        {
            return time1.CompareTo(time2) == -1;
        }
        public static bool operator >= (Time time1, Time time2)
        {
            return time1.CompareTo(time2) == 0;
        }
        public static bool operator <= (Time time1, Time time2)
        {
            return time1.CompareTo(time2) == 0;
        }
        public static Time operator + (Time time,TimePeriod timePeriod)
        {
            return Plus(time, timePeriod);
        }
        public static Time operator - (Time time, TimePeriod timePeriod)
        {
            return Minus(time, timePeriod);
        }
        public Time Plus(TimePeriod timePeriod)
        {
            var newTime = _seconds + timePeriod.Seconds;
            return new Time(Convert.ToByte((newTime / 3600) % 24),
                Convert.ToByte((newTime % 3600) / 60),
                Convert.ToByte(newTime % 60));
        }
        public Time Minus(TimePeriod timePeriod)
        {
            if (_seconds > timePeriod.Seconds)
            {
                var output = _seconds - timePeriod.Seconds;
                return new Time(Convert.ToByte((output / 3600) % 24),
                    Convert.ToByte((output % 3600) / 60),
                    Convert.ToByte(output % 60));
            }
            else
            {
                var output = timePeriod.Seconds - _seconds;
                return new Time(Convert.ToByte((output / 3600) % 24),
                    Convert.ToByte((output % 3600) / 60),
                    Convert.ToByte(output % 60));
            }
        }
        public static Time Plus(Time time, TimePeriod timePeriod)
        {
            var newTime = time._seconds + timePeriod.Seconds;
            return new Time(Convert.ToByte((newTime / 3600) % 24),
                Convert.ToByte((newTime % 3600) / 60),
                Convert.ToByte(newTime % 60));
        }
        public static Time Minus(Time time, TimePeriod timePeriod)
        {
            if (time._seconds > timePeriod.Seconds)
            {
                var output = time._seconds - timePeriod.Seconds;
                return new Time(Convert.ToByte((output / 3600) % 24),
                    Convert.ToByte((output % 3600) / 60),
                    Convert.ToByte(output % 60));
            }
            else
            {
                var output = timePeriod.Seconds - time._seconds;
                return new Time(Convert.ToByte((output / 3600) % 24),
                    Convert.ToByte((output % 3600) / 60),
                    Convert.ToByte(output % 60));
            }
        }

    }
}
