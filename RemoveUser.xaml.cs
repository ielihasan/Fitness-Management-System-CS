using System;
using System.Windows;
using System.Windows.Input;

namespace FitnessTrackingSystemWPF
{
    /// <summary>
    /// Interaction logic for RemoveUser.xaml
    /// </summary>
    public partial class RemoveUser : Window
    {
        private readonly UserCollection userCollection;

        public RemoveUser()
        {
            InitializeComponent();
            userCollection = new UserCollection("Users"); // Initialize UserCollection for the "Users" table
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validate User ID input
                if (!int.TryParse(UserIdInput.Text, out int userId))
                {
                    MessageBox.Show("Please enter a valid User ID.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Search for the user by ID
                User userToRemove = userCollection.SearchUserById(userId);

                if (userToRemove == null)
                {
                    MessageBox.Show("User not found. Please check the User ID.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Try to remove the user from the collection/database
                userCollection.RemoveUser(userId); // No return value expected here

                MessageBox.Show("User removed successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Create an instance of the ManageUser window
                ManageUser manageUserWindow = new ManageUser();

                // Show the window
                manageUserWindow.Show();
                this.Close();

                // Optionally close the window
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Method to handle the 'Escape' key press for going back to ManageUser window
        private void GoBack_click(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                // Create an instance of the ManageUser window
                ManageUser manageUserWindow = new ManageUser();

                // Show the window
                manageUserWindow.Show();
                this.Close();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the ManageUser window
            ManageUser manageUserWindow = new ManageUser();

            // Show the window
            manageUserWindow.Show();
            this.Close();
        }
    }
}
