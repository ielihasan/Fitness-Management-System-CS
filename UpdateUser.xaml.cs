using System;
using System.Windows;
using System.Windows.Controls;

namespace FitnessTrackingSystemWPF
{
    public partial class UpdateUser : Window
    {
        private readonly UserCollection userCollection;

        // Constructor without parameters
        public UpdateUser()
        {
            InitializeComponent();
            userCollection = new UserCollection("Users"); // Initialize UserCollection for the "Users" table
        }

        private void UpdateUser_Click(object sender, RoutedEventArgs e)
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
                User userToUpdate = userCollection.SearchUserById(userId);

                if (userToUpdate == null)
                {
                    MessageBox.Show("User not found. Please check the User ID.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Update fields if provided
                if (!string.IsNullOrWhiteSpace(UsernameInput.Text))
                    userToUpdate.Username = UsernameInput.Text;

                if (!string.IsNullOrWhiteSpace(PasswordInput.Password))
                    userToUpdate.Password = PasswordInput.Password;

                if (int.TryParse(CompletedDaysInput.Text, out int completedDays))
                    userToUpdate.CompletedDays = completedDays;

                if (MembershipTypeInput.SelectedItem is ComboBoxItem selectedMembership)
                    userToUpdate.MembershipType = selectedMembership.Content.ToString();

                if (FeePaidInput.SelectedItem is ComboBoxItem selectedFeePaid)
                    userToUpdate.FeePaid = selectedFeePaid.Content.ToString();

                if (!string.IsNullOrWhiteSpace(EmailInput.Text))
                    userToUpdate.Email = EmailInput.Text;

                if (!string.IsNullOrWhiteSpace(PhoneInput.Text))
                    userToUpdate.Phone = PhoneInput.Text;

                // Update user in the database
                userCollection.UpdateUserInfo(userToUpdate);

                MessageBox.Show("User updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ManageUser manageUser = new ManageUser();
            manageUser.Show();
            this.Close();
        }
    }
}
