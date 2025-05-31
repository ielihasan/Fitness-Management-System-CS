using System;
using System.Windows;
using System.Windows.Input;

namespace FitnessTrackingSystemWPF
{
    public partial class AddAdmin : Window
    {
        private AdminCollection adminCollection;

        public AddAdmin()
        {
            InitializeComponent();

            // Initialize AdminCollection instance
            adminCollection = new AdminCollection();
        }

        private void AddAdmin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get the input values from the form
                string adminId = AdminIdInput.Text.Trim();
                string username = UsernameInput.Text.Trim();
                string password = PasswordInput.Password;

                // Validate input
                if (string.IsNullOrWhiteSpace(adminId) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("All fields are required. Please fill in all the details.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Create a new Admin object
                Admin newAdmin = new Admin
                {
                    AdminId = adminId,
                    Username = username,
                    Password = password
                };

                // Add the new admin using AdminCollection
                adminCollection.AddAdmin(newAdmin);

                // Display a message confirming the addition
                MessageBox.Show($"Admin added successfully: {newAdmin.Username}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Clear the input fields for next entry
                AdminIdInput.Clear();
                UsernameInput.Clear();
                PasswordInput.Clear();
            }
            catch (Exception ex)
            {
                // Handle exceptions and display an error message
                MessageBox.Show($"An error occurred while adding the admin: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ScrollViewer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                // Navigate back to ManageAdmins window
                ManageAdmins manageAdminsWindow = new ManageAdmins();
                manageAdminsWindow.Show();
                this.Close();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to ManageAdmins window
            ManageAdmins manageAdminsWindow = new ManageAdmins();
            manageAdminsWindow.Show();
            this.Close();
        }
    }
}
