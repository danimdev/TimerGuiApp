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

        private void MinimizeButton(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

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
