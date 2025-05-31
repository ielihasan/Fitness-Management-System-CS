using System;
using System.Linq;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Input;

namespace FitnessTrackingSystemWPF
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the Sign-Up Page
            SignUpPage signUpPage = new SignUpPage();
            signUpPage.Show();

            // Close the current Login Page (optional)
            this.Close();
        }
        private void Check_Validation()
        {
            // Retrieve the entered username and password
            string username = UsernameInput.Text;
            string password = PasswordInput.Password;

            // Create an instance of the AdminCollection class to access the admin data
            AdminCollection adminCollection = new AdminCollection();
            List<Admin> admins = adminCollection.GetAllAdmins();

            // Check if the entered credentials match any admin in the database
            bool isValidAdmin = admins.Any(admin => admin.Username == username && admin.Password == password);

            if (isValidAdmin)
            {
                // If valid, navigate to the Admin Dashboard
                AdminDashboard adminDashboard = new AdminDashboard();
                adminDashboard.Show();

                // Close the current Login Page
                this.Close();
            }
            else
            {
                // If invalid, show an error message
                MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Check_Validation();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ForgetPassword forgetPassword = new ForgetPassword();
            forgetPassword.Show();
            Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Grid_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Check_Validation();

            }
        }
    }
}
