using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace TimerGUI
{
    public partial class ShutDownPage : Page
    {
        DispatcherTimer ShutdownTimer = new DispatcherTimer();

        int min, sec = 0, hour;

        bool isClicked = false;

        public ShutDownPage()
        {
            InitializeComponent();
        }

        void FillMinBoxWithNumbers(object sender, RoutedEventArgs args)
        {
            int runs = 60;
            List<string> numbers = new List<string>();

            for (int i = 1; i <= runs; i++)
            {
                numbers.Add(i.ToString());
            }

            ShutDownMinComboBox.ItemsSource = numbers;
        }

        void FillHourBoxWithNumbers(object sender, RoutedEventArgs args)
        {
            int runs = 48;
            List<string> numbers = new List<string>();

            for (int i = 1; i <= runs; i++)
            {
                numbers.Add(i.ToString());
            }

            ShutDownHourComboBox.ItemsSource = numbers;
        }

        private void ResetShutdown(object sender, RoutedEventArgs e)
        {
            ShutdownTimer.Stop();
            ShutDownTimerLabel.Content = "00:00:00";
            isClicked = false;
        }

        private void StartShutdown(object sender, RoutedEventArgs e)
        {
            if (!isClicked)
            {
                isClicked = true;
                hour = Convert.ToInt32(ShutDownHourComboBox.SelectedItem);
                min = Convert.ToInt32(ShutDownMinComboBox.SelectedItem);

                ShutdownTimer.Interval = TimeSpan.FromSeconds(1);
                ShutdownTimer.Tick += ShutdownTimer_Tick;
                ShutdownTimer.Start();
            }
        }

        private void ShutdownTimer_Tick(object sender, EventArgs e)
        {
            if (sec > 0)
            {
                sec--;
            }
            if (min > 0 && sec == 0)
            {
                min--;
                sec = 59;
            }
            if (hour > 0 && min == 0 && sec == 0)
            {
                hour--;
                min = 59;
                sec = 59;
            }
            if(hour == 0 && min == 0 && sec == 0)
            {
                Process.Start("shutdown", "/s /t 0");
            }

            ShutDownTimerLabel.Content = hour.ToString() + ":" + min.ToString() + ":" + sec.ToString();
        }
    }
}
