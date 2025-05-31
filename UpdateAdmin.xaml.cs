using System;
using System.Windows;
using System.Windows.Input;

namespace FitnessTrackingSystemWPF
{
    public partial class UpdateAdmin : Window
    {
        private AdminCollection adminCollection = new AdminCollection();

        public UpdateAdmin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Get the Admin ID and new details from the form
            string adminId = AdminIdInput.Text;
            string newUsername = UsernameInput.Text;
            string newPassword = PasswordInput.Password;

            // Search for the admin by ID
            Admin adminToUpdate = adminCollection.SearchAdminById(adminId);

            if (adminToUpdate != null)
            {
                // Update only the fields with new values
                if (!string.IsNullOrWhiteSpace(newUsername))
                {
                    adminToUpdate.Username = newUsername;
                }

                if (!string.IsNullOrWhiteSpace(newPassword))
                {
                    adminToUpdate.Password = newPassword;
                }

                // Update the admin info in the database
                adminCollection.UpdateAdminInfo(adminToUpdate);

                // Display a success message
                MessageBox.Show($"Admin {adminToUpdate.AdminId} updated successfully.", "Admin Updated", MessageBoxButton.OK, MessageBoxImage.Information);

                // Clear the input fields
                AdminIdInput.Clear();
                UsernameInput.Clear();
                PasswordInput.Clear();
            }
            else
            {
                // Display an error message if the admin is not found
                MessageBox.Show("Admin not found with the provided ID.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ScrollViewer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                // Navigate back to the ManageAdmins window
                ManageAdmins manageAdminsWindow = new ManageAdmins();
                manageAdminsWindow.Show();
                this.Close();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to the ManageAdmins window
            ManageAdmins manageAdminsWindow = new ManageAdmins();
            manageAdminsWindow.Show();
            this.Close();
        }
    }
}
