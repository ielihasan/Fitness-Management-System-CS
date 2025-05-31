using System;
using System.Windows;
using System.Windows.Input;

namespace FitnessTrackingSystemWPF
{
    public partial class SearchUser : Window
    {
        private readonly UserCollection userCollection;

        // Constructor
        public SearchUser()
        {
            InitializeComponent();
            userCollection = new UserCollection("Users"); // Initialize UserCollection for the "Users" table
        }

        private void SearchUser_Click(object sender, RoutedEventArgs e)
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
                User userToSearch = userCollection.SearchUserById(userId);

                if (userToSearch == null)
                {
                    MessageBox.Show("User not found. Please check the User ID.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Display user details in a well-structured way
                ResultStackPanel.Visibility = Visibility.Visible; // Show result stack panel
                ResultText.Visibility = Visibility.Collapsed; // Hide initial result text

                // Fill result fields
                UsernameResult.Text = $"Username: {userToSearch.Username}";
                EmailResult.Text = $"Email: {userToSearch.Email}";
                PhoneResult.Text = $"Phone: {userToSearch.Phone}";
                CompletedDaysResult.Text = $"Completed Days: {userToSearch.CompletedDays}";
                MembershipTypeResult.Text = $"Membership Type: {userToSearch.MembershipType}";
                FeePaidResult.Text = $"Fee Paid: {userToSearch.FeePaid}";

                // Show Go Back button
                GoBackButton.Visibility = Visibility.Visible;

                MessageBox.Show("User found and displayed.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            // Close the current window and go back to the previous one
            this.Close();
        }

        // Handle key press event to detect Escape key and go back
        private void Window_KeyDown(object sender, KeyEventArgs e)
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
