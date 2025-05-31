using System;
using System.Windows;

namespace FitnessTrackingSystemWPF
{
    public partial class SignUpPage : Window
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Get the input values from the UI elements
            string adminId = AdminIdInput.Text;
            string username = UsernameInput.Text;
            string password = PasswordInput.Password;
            string confirmPassword = ConfirmPasswordInput.Password;

            // Check if the passwords match
            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Create a new Admin object
            Admin newAdmin = new Admin
            {
                AdminId = adminId,
                Username = username,
                Password = password
            };

            // Use DBHelperAdmin to add the new admin to the database
            DBHelperAdmin dbHelper = new DBHelperAdmin();
            string result = dbHelper.AddAdmin(newAdmin);

            // Check if the admin was added successfully
            if (!string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Admin created successfully. Please login.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Navigate to the login page
                LoginPage loginPage = new LoginPage();
                loginPage.Show();
                this.Close();
            }
            else
            {
                // If there was an error adding the admin
                MessageBox.Show("Error while creating the admin. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Navigate to the login page
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the login page
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Close();
        }
    
    }
}
