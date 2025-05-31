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

namespace FitnessTrackingSystemWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string videoPath = @"C:\Users\Ali Hassan\source\repos\FitnessTrackingSystemWPF\FitnessTrackingSystemWPF\bg0.mp4";
            mediaElement.Source = new Uri(videoPath);
            mediaElement.Play();
        }

        // Code-behind for MainWindow.xaml.cs

        private void GetStartedButton_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the LoginPage
            LoginPage loginPage = new LoginPage();

            // Show the LoginPage window
            loginPage.Show();

            // Optionally, close the MainWindow (if you don't want the user to return to it)
            this.Close();
        }

    }
}
