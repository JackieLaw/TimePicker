using System;

namespace RoyT.TimePicker
{
    /// <summary>
    ///  Represents a time, rules for AM and PM from 
    ///  http://www.timeanddate.com/time/am-and-pm.html
    /// </summary>
    public struct Time
    {
        public Time(int hour, int minute, Meridiem meridiem)
        {
            if(hour < 0 || hour > 12)
            {
                throw new ArgumentException("Hour should be in [0..12]" ,nameof(hour));
            }

            if (minute < 0 || minute > 59)
            {
                throw new ArgumentException("Minute should be in [0..59]", nameof(minute));
            }

            this.Hour     = hour;
            this.Minute   = minute;
            this.Meridiem = meridiem;
        }

        public Time(TimeSpan time)
        {
            this.Minute = time.Minutes;

            if (time.Hours == 0)
            {
                // 12:00 AM to 12:59 AM
                this.Hour = time.Hours + 12;
                this.Meridiem = Meridiem.AM;
            }
            else if(time.Hours <= 11)
            {
                // 01:00 AM to 11:59 AM
                this.Hour     = time.Hours;
                this.Meridiem = Meridiem.AM;    
            }   
            else if(time.Hours == 12)
            {
                // 12:00PM to 12:59 PM
                this.Hour     = time.Hours;
                this.Meridiem = Meridiem.PM;
            }
            else if(time.Hours < 24)
            {
                // 01:00PM to 11:59 PM
                this.Hour     = time.Hours - 12;
                this.Meridiem = Meridiem.PM;
            }
            else
            {
                throw new ArgumentException("Cannot create a time from a TimeSpan that represents more than 24 hours", nameof(time));
            }
        }

        public int Hour { get; }
        public int Minute { get; }

        public Meridiem Meridiem { get; }

        public TimeSpan ToTimeSpan()
        {
            if(this.Meridiem == Meridiem.AM)
            {
                if (this.Hour == 12)
                {
                    // 12:00 AM to 12:59 AM is 00:00 to 00:59
                    return new TimeSpan(this.Hour - 12, this.Minute, 0);
                }
                else
                {
                    // 01:00 AM to 11:59 AM is 01:00 to 11:59
                    return new TimeSpan(this.Hour, this.Minute, 0);
                }
            }
            else
            {
                if(this.Hour == 12)
                {
                    // 12:00 PM to 12:59 PM is 12:00 to 12:59
                    return new TimeSpan(this.Hour, this.Minute, 0);
                }
                else
                {
                    // 01:00 PM to 11:59 PM is 13:00 to 23:59 
                    return new TimeSpan(this.Hour + 12, this.Minute, 0);
                }
            }
        }
        
        public override bool Equals(object obj)
        {
            return obj != null && obj is Time 
                && Equals((Time)obj);
        }

        public bool Equals(Time other)
        {
            return other.ToTimeSpan().Equals(this.ToTimeSpan());
        }

        public override int GetHashCode()
        {
            return ToTimeSpan().GetHashCode();
        }

        public override string ToString()
        {
            var dt = DateTime.Today.Add(ToTimeSpan());
            return dt.ToString("HH:mm (tt)");
        }
    }
}
