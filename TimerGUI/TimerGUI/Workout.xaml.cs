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

        int reps = 0;

        bool isClicked = false;

        enum WORKMODE
        {
            WORK,
            PAUSE,
            IDLE
        }

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
                ShowWorkTime();

                repRepeatMin = workMin;
                repRepeatSec = workSec;

                workDispatchertimer.Start();
            }
        }

        private void WorkTimer(object sender, EventArgs e)
        {
            if (workMin == 0 && workSec == 0)
            {
                if (reps > 0) {
                    --reps;
                    workMin = repRepeatMin;
                    workSec = repRepeatSec;
                }

                if (reps == 0)
                {
                    workSec = 0;
                    workMin = 0;
                    workDispatchertimer.Stop();
                    isClicked = false;
                }

                RepCount.Content = "Reps Left: " + reps.ToString();
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

            ShowWorkTime();
        }

        private void PauseTimer(object sender, EventArgs e)
        {
        }

        void ShowWorkTime()
        {
            if (workMin < 10 && workSec < 10)
                WorkoutTimeLabel.Content = "0" + workMin.ToString() + ":" + "0" + workSec.ToString();
            else if (workMin < 10)
                WorkoutTimeLabel.Content = "0" + workMin.ToString() + ":" + workSec.ToString();
            else if (workSec < 10)
                WorkoutTimeLabel.Content = workMin.ToString() + ":" + "0" + workSec.ToString();
            else if (workSec > 9 && workSec > 9)
                WorkoutTimeLabel.Content = workMin.ToString() + ":" + workSec.ToString();
        }
    }
}
