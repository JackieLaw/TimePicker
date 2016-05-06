using System.ComponentModel;
using System.Windows;

namespace RoyT.TimePicker.Sample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private AnalogueTime time;
        private DigitalTime digitalTime;

        public MainWindow()
        {
            this.time = new AnalogueTime(0, 0, Meridiem.AM);
            this.DataContext = this;
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public AnalogueTime Time
        {
            get { return this.time; }
            set
            {
                if (!this.time.Equals(value))
                {
                    this.time = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Time)));
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DigitalTime)));
                }
            }
        }

        public DigitalTime MinTime { get { return new DigitalTime(9, 0); } }
        public DigitalTime MaxTime { get { return new DigitalTime(21, 0); } }
        
        public DigitalTime DigitalTime
        {
            get { return this.Time.ToDigitalTime(); }
            set
            {
                this.Time = value.ToAnalogueTime();
            }
        }

        private void AMPMButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.Time.Meridiem == Meridiem.AM)
            {
                this.Time = new AnalogueTime(this.Time.Hour, this.Time.Minute, Meridiem.PM);
            }
            else
            {
                this.Time = new AnalogueTime(this.Time.Hour, this.Time.Minute, Meridiem.AM);
            }

        }
    }
}
