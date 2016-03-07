using System;
using System.Windows;
using static RoyT.TimePicker.ClockMath;
using static RoyT.TimePicker.TimePicker;

namespace RoyT.TimePicker
{
    /// <summary>
    /// Controls mouse and touch input for the TimePicker control https://github.com/roy-t/TimePicker    
    /// </summary>
    public class TimePickerInputController
    {
        private readonly TimePicker TimePicker;

        // TimePicker.ActualHeight * MinDistanceRatio is the max
        // distance away from the tip of the indicator you can 
        // click to still start dragging it
        private const double MinDistanceRatio = 0.2;

        private Indicator indicator;
        private bool isDragging;

        public TimePickerInputController(TimePicker timePicker)
        {
            this.TimePicker = timePicker;

            this.TimePicker.PreviewMouseLeftButtonDown += TimePicker_MouseLeftButtonDown;
            this.TimePicker.PreviewMouseMove           += TimePicker_MouseMove;
            this.TimePicker.MouseLeave                 += TimePicker_MouseLeave;
            this.TimePicker.PreviewMouseLeftButtonUp   += TimePicker_MouseLeftButtonUp;
        }

        private void StartDragging(Point mouse)
        {
            var width  = this.TimePicker.ActualWidth;
            var height = this.TimePicker.ActualHeight;
            var radius = (Math.Min(width, height) - this.TimePicker.BorderThickness.Left) / 2.0;
            var center = new Point(width / 2.0, height / 2.0);

            // TODO: highlight indicator that you're dragging
            FindIndicator(width, height, radius, center, mouse);

            this.isDragging = true;
        }

        private void StopDragging()
        {
            this.indicator  = Indicator.None;
            this.isDragging = false;
        }

        private void TimePicker_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if(this.isDragging)
            {
                var width  = this.TimePicker.ActualWidth;
                var height = this.TimePicker.ActualHeight;
                var radius = (Math.Min(width, height) - this.TimePicker.BorderThickness.Left) / 2.0;
                var center = new Point(width / 2.0, height / 2.0);
                var mouse  = e.GetPosition(this.TimePicker);
                
                var time = this.TimePicker.Time;

                if (this.indicator == Indicator.HourIndicator)
                {
                    var hour = AngleToHour(center, mouse);
                    this.TimePicker.Time = new Time(hour, time.Minute, time.Meridiem);
                }

                if(this.indicator == Indicator.MinuteIndicator)
                {
                    var minutes = AngleToMinutes(center, mouse);
                    this.TimePicker.Time = new Time(time.Hour, minutes, time.Meridiem);
                }                
            }
        }

        private void FindIndicator(double width, double height, double radius, Point center, Point mouse)
        {
            var minuteTip = LineOnCircle((Math.PI * 2 * this.TimePicker.Time.Minute / 60) - Math.PI / 2.0, center, 0, radius * MinuteIndicatorRatio)[1];
            var hourTip   = LineOnCircle((Math.PI * 2 * this.TimePicker.Time.Hour / 12) - Math.PI / 2.0, center, 0, radius * HourIndicatorRatio)[1];

            var maxDistance = width * MinDistanceRatio;

            var minuteDistance = Distance(mouse, minuteTip);
            var hourDistance   = Distance(mouse, hourTip);

            if(minuteDistance < hourDistance && minuteDistance < maxDistance)
            {             
                this.indicator = Indicator.MinuteIndicator;
            }
            else if (hourDistance <=  minuteDistance && hourDistance < maxDistance)
            {
                this.indicator = Indicator.HourIndicator;
            }
        }

        private void TimePicker_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            StartDragging(e.GetPosition(this.TimePicker));
        }

        private void TimePicker_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            StopDragging();
        }

        private void TimePicker_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            StopDragging();
        }       

        private enum Indicator
        {
            None,
            HourIndicator,
            MinuteIndicator
        }

    }
}
