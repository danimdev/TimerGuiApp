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
    public partial class Page1 : Page
    {
        DispatcherTimer workDispatchertimer = new DispatcherTimer();
        DispatcherTimer pauseDispTimer = new DispatcherTimer();

        int workMin, workSec;
        int pauseMin, pauseSec;

        int repRepeatMin, repRepeatSec;
        int repeatPauseMin, repeatPauseSec;

        int reps = 0;

        bool isClicked = false;

        bool isWork = true;

        string showPauseSec;

        public Page1()
        {
            InitializeComponent();
            workDispatchertimer.Interval = TimeSpan.FromSeconds(1);
            workDispatchertimer.Tick += WorkTimer;

            pauseDispTimer.Interval = TimeSpan.FromSeconds(1);
            pauseDispTimer.Tick += PauseTimer;
        }

        void FillBoxes(object sender, RoutedEventArgs args)
        {
            List<string> numbers = new List<string>();
            for (int i = 1; i <= 60; i++)
            {
                numbers.Add(i.ToString());
            }

            WorkOutWorkMin.ItemsSource = numbers;
            WorkOutWorkSec.ItemsSource = numbers;
            WotkOutPauseMin.ItemsSource = numbers;
            WotkOutPauseSec.ItemsSource = numbers;

            RepsCount.ItemsSource = numbers;
        }

        private void StartWork(object sender, RoutedEventArgs e)
        {
            if (!isClicked)
            {
                isClicked = true;
                workMin = Convert.ToInt32(WorkOutWorkMin.SelectedItem);
                workSec = Convert.ToInt32(WorkOutWorkSec.SelectedItem);

                pauseMin = Convert.ToInt32(WotkOutPauseMin.SelectedItem);
                pauseSec = Convert.ToInt32(WotkOutPauseSec.SelectedItem);

                reps = Convert.ToInt32(RepsCount.SelectedItem);

                RepCount.Content = "Reps Left: " + reps.ToString();
                ShowWorkTime(workMin,workSec);

                WorkoutMode.Content = "Working";
                WorkoutMode.Foreground = Brushes.LawnGreen;

                repRepeatMin = workMin;
                repRepeatSec = workSec;

                repeatPauseMin = pauseMin;
                repeatPauseSec = pauseSec;

                workDispatchertimer.Start();
            }
        }

        private void WorkTimer(object sender, EventArgs e)
        {
            ShowWorkTime(workMin, workSec);
            if (workMin == 0 && workSec == 0)
            {
                isWork = false;
                if (reps == 0)
                {
                    workSec = 0;
                    workMin = 0;
                    workDispatchertimer.Stop();
                    isClicked = false;
                }

                if (reps > 0 && !isWork) {
                    WorkoutMode.Content = "Pause";
                    WorkoutMode.Foreground = Brushes.Red;
                    pauseDispTimer.Start();
                    workDispatchertimer.Stop();
                }

                workMin = repRepeatMin;
                workSec = repRepeatSec;
            }
            else if (workSec > 0)
            {
                workSec--;
            }
            else if(workMin > 0 && workSec == 0)
            {
                workMin--;
                workSec = 59;
            }
        }

        private void PauseTimer(object sender, EventArgs e)
        {
            ShowWorkTime(pauseMin, pauseSec);
            if (pauseMin == 0 && pauseSec == 0)
            {
                reps--;
                RepCount.Content = "Reps Left: " + reps.ToString();

                pauseMin = repeatPauseMin;
                pauseSec = repeatPauseSec;

                WorkoutMode.Content = "Working";
                WorkoutMode.Foreground = Brushes.LawnGreen;

                isWork = true;
                workDispatchertimer.Start();
                pauseDispTimer.Stop();
            }
            else if (pauseSec > 0)
            {
                pauseSec--;
            }
            else if(pauseMin > 0 && pauseSec == 0)
            {
                pauseMin--;
                pauseSec = 59;
            }
        }

        void ShowWorkTime(int min,int sec)
        {
            if (min < 10 && sec < 10)
                WorkoutTimeLabel.Content = "0" + min.ToString() + ":" + "0" + sec.ToString();
            else if (min < 10)
                WorkoutTimeLabel.Content = "0" + min.ToString() + ":" + sec.ToString();
            else if (sec < 10)
                WorkoutTimeLabel.Content = min.ToString() + ":" + "0" + sec.ToString();
            else if (min > 9 && sec > 9)
                WorkoutTimeLabel.Content = min.ToString() + ":" + sec.ToString();
        }
    }
}
