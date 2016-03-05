using System;
using System.ComponentModel;
using System.Timers;
using System.Windows;

namespace RoyT.TimePicker
{    
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private TimeSpan time;

        public MainWindow()
        {
            this.time = TimeSpan.Zero;
            this.DataContext = this;
            InitializeComponent();         
        }        

        public event PropertyChangedEventHandler PropertyChanged;

        public TimeSpan Time
        {
            get { return this.time; }
            set
            {
                if(this.time != value)
                {
                    this.time = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Time)));
                }
            }
        }      

    }
}
