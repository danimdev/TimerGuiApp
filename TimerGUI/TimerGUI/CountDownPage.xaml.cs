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

namespace TimerGUI
{
    /// <summary>
    /// Interaktionslogik für CountDownPage.xaml
    /// </summary>
    public partial class CountDownPage : Page
    {
        int CountDownMin;
        int CountDownSec;

        bool isCountDownStarted = false;
        bool isAlreadyStarted = false;

        DispatcherTimer CountDownTimer = new DispatcherTimer();


        public CountDownPage()
        {
            InitializeComponent();
        }

        private void StartCountdown(object sender, RoutedEventArgs e)
        {
            if (!isCountDownStarted && CountDownListBox.SelectedIndex > -1 && !isAlreadyStarted)
            {
                isAlreadyStarted = true;
                isCountDownStarted = true;
                CountDownSec = 60;
                CountDownMin = CountDownListBox.SelectedIndex;
                CountDownTimer.Interval = TimeSpan.FromSeconds(1);
                CountDownTimer.Tick += timer_Tick;
                CountDownTimer.Start();
            }
            else if (!isCountDownStarted && isAlreadyStarted)
            {
                isCountDownStarted = true;
                CountDownSec = 60;
                CountDownMin = CountDownListBox.SelectedIndex;
                CountDownTimer.Start();
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (CountDownSec == 0)
            {
                CountDownMin--;
                CountDownSec = 60;
            }
            if (CountDownSec > 0)
            {
                CountDownSec--;
            }
            if (CountDownMin < 0)
            {
                CountDownMin = 0;
                CountDownSec = 0;
                CountDownTimer.Stop();
                MessageBox.Show("Stop");
                isCountDownStarted = false;
            }
            CountDownLabel.Content = CountDownMin.ToString() + ":" + CountDownSec.ToString();
        }

        void FillBoxesWithNumbers(object sender, RoutedEventArgs args)
        {
            List<string> numbers = new List<string>();
            for (int i = 1; i <= 60; i++)
            {
                numbers.Add(i.ToString());
            }

            CountDownListBox.ItemsSource = numbers;
        }

        private void ResetCountdown(object sender, RoutedEventArgs e)
        {
            CountDownMin = 0;
            CountDownSec = 0;
            CountDownTimer.Stop();
            isCountDownStarted = false;
            CountDownLabel.Content = "00" + ":" + "00";
        }
    }
}
