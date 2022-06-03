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

namespace TimerGUI
{
    /// <summary>
    /// Interaktionslogik für Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
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
            WorkOutWorkMin.ItemsSource = numbers;
            WorkOutWorkSec.ItemsSource = numbers;
            WotkOutPauseMin.ItemsSource = numbers;
            WotkOutPauseSec.ItemsSource = numbers;
            RepsCount.ItemsSource = numbers;
        }

        private void StartWork(object sender, RoutedEventArgs e)
        {

        }
    }
}
