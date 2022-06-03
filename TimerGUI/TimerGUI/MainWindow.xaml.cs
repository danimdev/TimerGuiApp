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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int CountDownMin;
        int CountDownSec;

        bool isCountDownStarted = false;
        bool isAlreadyStarted = false;
        bool startCountdownIsPressed = false;

        DispatcherTimer CountDownTimer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new CountDownPage();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void CloseWindow(object sender, RoutedEventArgs e) => this.Close();

        //private void StartCountdown(object sender, RoutedEventArgs e)
        //{
        //    if (!isCountDownStarted && CountDownListBox.SelectedIndex > -1 && !isAlreadyStarted)
        //    {
        //        isAlreadyStarted = true;
        //        isCountDownStarted = true;
        //        CountDownSec = 60;
        //        CountDownMin = CountDownListBox.SelectedIndex;
        //        CountDownTimer.Interval = TimeSpan.FromSeconds(1);
        //        CountDownTimer.Tick += timer_Tick;
        //        CountDownTimer.Start();
        //    }
        //    else if(!isCountDownStarted && isAlreadyStarted)
        //    {
        //        isCountDownStarted = true;
        //        CountDownSec = 60;
        //        CountDownMin = CountDownListBox.SelectedIndex;
        //        CountDownTimer.Start();
        //    }
        //}

        //void timer_Tick(object sender, EventArgs e)
        //{
        //    if (CountDownSec == 0)
        //    {
        //        CountDownMin--;
        //        CountDownSec = 60;
        //    }
        //    if(CountDownSec > 0)
        //    {
        //        CountDownSec--;
        //    }
        //    if(CountDownMin < 0)
        //    {
        //        CountDownMin = 0;
        //        CountDownSec = 0;
        //        CountDownTimer.Stop();
        //        MessageBox.Show("Stop");
        //        isCountDownStarted=false;
        //    }
        //    CountDownLabel.Content = CountDownMin.ToString() + ":" + CountDownSec.ToString();
        //}

        //private void StartWork(object sender, RoutedEventArgs e)
        //{

        //}

        //private void StartShutdown(object sender, RoutedEventArgs e)
        //{

        //}

        //void FillBoxesWithNumbers(object sender, RoutedEventArgs args)
        //{
        //    List<string> numbers = new List<string>();
        //    for (int i = 1; i <= 60; i++)
        //    {
        //        numbers.Add(i.ToString());
        //    }

        //    CountDownListBox.ItemsSource = numbers;
        //    //WorkOutWorkMin.ItemsSource = numbers;
        //    //WorkOutWorkSec.ItemsSource = numbers;
        //    //WotkOutPauseMin.ItemsSource = numbers;
        //    //WotkOutPauseSec.ItemsSource = numbers;
        //    //RepsCount.ItemsSource = numbers;
        //}

        private void MinimizeButton(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

        //private void ResetCountdown(object sender, RoutedEventArgs e)
        //{
        //    CountDownMin = 0;
        //    CountDownSec = 0;
        //    CountDownTimer.Stop();
        //    isCountDownStarted = false;
        //    CountDownLabel.Content = "00" + ":" + "00";
        //}

        private void ShutDownPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ShutDownPage();
        }

        private void CountDownPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new CountDownPage();
        }

        private void WorkoutPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Page1();
        }
    }
}
