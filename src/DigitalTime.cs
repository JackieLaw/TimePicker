using System;

namespace RoyT.TimePicker
{
    /// <summary>
    /// Represents time as on a digital 24 hour clock
    /// </summary>
    public struct DigitalTime : IComparable<DigitalTime>, IEquatable<DigitalTime>
    {
        public DigitalTime(int hour, int minute)
        {
            if (hour < 0 || hour > 23)
            {
                throw new ArgumentException("Hour should be in [0..23]", nameof(hour));
            }

            if (minute < 0 || minute > 59)
            {
                throw new ArgumentException("Minute should be in [0..59]", nameof(minute));
            }

            this.Hour = hour;
            this.Minute = minute;
        }

        public DigitalTime(TimeSpan time)
            : this(time.Hours, time.Minutes) { }


        public DigitalTime(AnalogueTime time)
            : this(time.ToTimeSpan()) { }

        public int Hour { get; }
        public int Minute { get; }

        public TimeSpan ToTimeSpan()
        {
            return new TimeSpan(this.Hour, this.Minute, 0);
        }

        public AnalogueTime ToAnalogueTime()
        {
            return new AnalogueTime(this.ToTimeSpan());
        }

        public int CompareTo(DigitalTime other)
        {
            return this.ToTimeSpan().CompareTo(other.ToTimeSpan());
        }

        public override string ToString()
        {
            var dt = DateTime.Today.Add(ToTimeSpan());
            return dt.ToString("HH:mm");
        }

        public override int GetHashCode()
        {
            return (this.Hour * 100) + this.Minute;
        }

        public override bool Equals(object obj)
        {
            return obj != null &&
                   obj is DigitalTime &&
                   Equals((DigitalTime)obj);
        }

        public bool Equals(DigitalTime other)
        {
            return other.Hour == this.Hour &&
                   other.Minute == this.Minute;
        }

        public static bool operator <(DigitalTime left, DigitalTime right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(DigitalTime left, DigitalTime right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator ==(DigitalTime left, DigitalTime right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(DigitalTime left, DigitalTime right)
        {
            return !Equals(left, right);
        }
    }
}
