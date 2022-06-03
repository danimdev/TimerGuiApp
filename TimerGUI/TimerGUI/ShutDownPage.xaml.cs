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
    /// Interaktionslogik für ShutDownPage.xaml
    /// </summary>
    public partial class ShutDownPage : Page
    {
        public ShutDownPage()
        {
            InitializeComponent();
        }

        void FillBoxesWithNumbers(object sender, RoutedEventArgs args)
        {
            List<string> numbers = new List<string>();
            for (int i = 1; i <= 60; i++)
            {
                numbers.Add(i.ToString());
            }

            //CountDownListBox.ItemsSource = numbers;
            //WorkOutWorkMin.ItemsSource = numbers;
            //WorkOutWorkSec.ItemsSource = numbers;
            //WotkOutPauseMin.ItemsSource = numbers;
            //WotkOutPauseSec.ItemsSource = numbers;
            //RepsCount.ItemsSource = numbers;
        }

        private void StartShutdown(object sender, RoutedEventArgs e)
        {

        }
    }

    //public partial class LeistenFunctions : Window
    //{
    //    public void MinimizeButton(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

    //    public void CloseWindow(object sender, RoutedEventArgs e) => this.Close();

    //    public void Window_MouseDown2(object sender, MouseButtonEventArgs e)
    //    {
    //        if (e.LeftButton == MouseButtonState.Pressed)
    //        {
    //            this.DragMove();
    //        }
    //    }
    //}
}
