using System;
using System.Windows;
using System.Windows.Controls;

namespace FitnessTrackingSystemWPF
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(UserIdInput.Text) ||
                    string.IsNullOrWhiteSpace(UsernameInput.Text) ||
                    string.IsNullOrWhiteSpace(PasswordInput.Password) ||
                    string.IsNullOrWhiteSpace(CompletedDaysInput.Text) ||
                    MembershipTypeInput.SelectedIndex == -1 ||
                    FeePaidInput.SelectedIndex == -1 ||
                    string.IsNullOrWhiteSpace(EmailInput.Text) ||
                    string.IsNullOrWhiteSpace(PhoneInput.Text))
                {
                    MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Validate User ID - Ensure it's a valid positive integer
                if (!int.TryParse(UserIdInput.Text, out int userId) || userId <= 0)
                {
                    MessageBox.Show("User ID must be a valid positive integer.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Validate Completed Days
                if (!int.TryParse(CompletedDaysInput.Text, out int completedDays))
                {
                    MessageBox.Show("Completed Days must be a valid number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Get selected value for FeePaid
                string feePaid = (FeePaidInput.SelectedItem as ComboBoxItem)?.Content.ToString().Trim().ToUpper();
                if (feePaid != "YES" && feePaid != "NO")
                {
                    MessageBox.Show("Fee Paid must be either 'YES' or 'NO'.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Get selected value for MembershipType
                string membershipType = (MembershipTypeInput.SelectedItem as ComboBoxItem)?.Content.ToString().Trim();
                if (membershipType != "Basic" && membershipType != "Premium")
                {
                    MessageBox.Show("Membership Type must be either 'Basic' or 'Premium'.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Create a new user and populate its properties
                User newUser = new User
                {
                    UserId = userId,
                    Username = UsernameInput.Text,
                    Password = PasswordInput.Password,
                    CompletedDays = completedDays,
                    MembershipType = membershipType,
                    FeePaid = feePaid,
                    Email = EmailInput.Text,
                    Phone = PhoneInput.Text
                };

                // Add user to the collection (Assume UserCollection handles database operations)
                UserCollection userCollection = new UserCollection("Users");
                userCollection.AddUser(newUser);

                MessageBox.Show("User added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Clear inputs for a better user experience
                ClearInputs();

                // Navigate to the ManageUser window
                ManageUser manageUserWindow = new ManageUser();
                manageUserWindow.Show();
                this.Close(); // Close current window
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearInputs()
        {
            UserIdInput.Text = string.Empty;
            UsernameInput.Text = string.Empty;
            PasswordInput.Password = string.Empty;
            CompletedDaysInput.Text = string.Empty;
            MembershipTypeInput.SelectedIndex = -1;
            FeePaidInput.SelectedIndex = -1;
            EmailInput.Text = string.Empty;
            PhoneInput.Text = string.Empty;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the ManageUser window
            ManageUser manageUserWindow = new ManageUser();
            manageUserWindow.Show();
            this.Close(); // Close current window
        }
    }
}
