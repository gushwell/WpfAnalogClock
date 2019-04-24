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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAnalogClock2
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeAngle();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StartAnimation("HourHand", this.AngleHour.Angle);
            StartAnimation("MinuteHand", this.AngleMinute.Angle);
            StartAnimation("SecondHand", this.AngleSecond.Angle);
        }

        void InitializeAngle()
        {
            DateTime dt = DateTime.Now;
            this.AngleSecond.Angle = dt.Second * 360.0 / 60.0;
            this.AngleMinute.Angle = (dt.Minute + dt.Second / 60.0) * 360.0 / 60.0;
            this.AngleHour.Angle = (dt.Hour + dt.Minute / 60.0) * 360.0 / 12;
        }

        private void StartAnimation(string name, double angle)
        {
            var sb = this.Resources[name] as Storyboard;
            var da = sb.Children[0] as DoubleAnimation;
            da.From = angle;
            da.To = da.From + 360.0;
            sb.Begin();
        }

    }
}
