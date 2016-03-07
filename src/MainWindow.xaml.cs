using System;
using System.ComponentModel;
using System.Timers;
using System.Windows;

namespace RoyT.TimePicker
{    
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Time time;

        public MainWindow()
        {
            this.time = new Time(0, 0, Meridiem.AM);
            this.DataContext = this;
            InitializeComponent();         
        }        

        public event PropertyChangedEventHandler PropertyChanged;

        public Time Time
        {
            get { return this.time; }
            set
            {
                if(!this.time.Equals(value))
                {
                    this.time = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Time)));
                }
            }
        }

        private void AMPMButton_Click(object sender, RoutedEventArgs e)
        {
            if(this.Time.Meridiem == Meridiem.AM)
            {
                this.Time = new Time(this.Time.Hour, this.Time.Minute, Meridiem.PM);
            }
            else
            {
                this.Time = new Time(this.Time.Hour, this.Time.Minute, Meridiem.AM);
            }

        }
    }
}
