using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfAnalogClock1
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
            DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Normal, this.Dispatcher);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        void Update()
        {
            DateTime dt = DateTime.Now;
            this.AngleSecond.Angle = dt.Second * 360.0 / 60.0;
            this.AngleMinute.Angle = (dt.Minute + dt.Second / 60.0) * 360.0 / 60.0;
            this.AngleHour.Angle = (dt.Hour + dt.Minute / 60.0) * 360.0 / 12;
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            Update();
        }
    }
}
