using System;
using System.Windows;
using System.Windows.Input;

namespace FitnessTrackingSystemWPF
{
    public partial class RemoveAdmin : Window
    {
        private AdminCollection adminCollection;

        public RemoveAdmin()
        {
            InitializeComponent();

            // Initialize AdminCollection instance
            adminCollection = new AdminCollection();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get the Admin ID from the input field
                string adminId = AdminIdInput.Text.Trim();

                // Validate input
                if (string.IsNullOrWhiteSpace(adminId))
                {
                    MessageBox.Show("Admin ID is required.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Attempt to remove the admin using AdminCollection
                adminCollection.RemoveAdmin(adminId);

                // Display success message
                MessageBox.Show($"Admin with ID {adminId} has been removed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Clear the input field for next entry
                AdminIdInput.Clear();
            }
            catch (Exception ex)
            {
                // Handle exceptions and display an error message
                MessageBox.Show($"An error occurred while removing the admin: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
