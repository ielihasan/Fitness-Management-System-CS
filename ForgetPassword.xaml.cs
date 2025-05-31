using System;
using System.Windows;

namespace FitnessTrackingSystemWPF
{
    public partial class ForgetPassword : Window
    {
        public ForgetPassword()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Get the entered Admin ID
            string adminId = AdminIdInput.Text;

            if (string.IsNullOrWhiteSpace(adminId))
            {
                MessageBox.Show("Please enter a valid Admin ID.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Initialize DBHelper to fetch Admin details
            DBHelperAdmin dbHelper = new DBHelperAdmin();
            Admin admin = dbHelper.SearchAdminById(adminId);

            if (admin != null)
            {
                // Show the admin's password in a message box
                MessageBox.Show($"The password for Admin ID: {adminId} is: {admin.Password}",
                    "Password Retrieval", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                // If admin not found, show an error message
                ErrorMessage.Visibility = Visibility.Visible;
                ErrorMessage.Text = "Admin ID not found. Please check and try again.";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Navigate back to the login screen
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to the login screen
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Close();
        }
    }
}
