using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace FitnessTrackingSystemWPF
{
    /// <summary>
    /// Interaction logic for ListAllUser.xaml
    /// </summary>
    public partial class ListAllUser : Window
    {
        private readonly UserCollection userCollection;

        public ListAllUser()
        {
            InitializeComponent();
            userCollection = new UserCollection("Users"); // Initialize UserCollection for the "Users" table
            this.KeyDown += ListAllUser_KeyDown; // Register the KeyDown event for Escape key handling
        }

        // Button Click Event to load all users and display in ListView
        private void LoadAllUsers_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get all users from the UserCollection
                List<User> allUsers = userCollection.GetAllUsers(); // Ensure this method returns the correct list of users

                // Set the ItemsSource of ListView to the list of users
                UserListView.ItemsSource = allUsers;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // KeyDown event handler to listen for Escape key
        private void ListAllUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                // Create an instance of the ManageUser window
                ManageUser manageUserWindow = new ManageUser();

                // Show the window and close the current one
                manageUserWindow.Show();
                this.Close();
            }
        }

        // Back Button Click Event
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the ManageUser window
            ManageUser manageUserWindow = new ManageUser();

            // Show the window and close the current one
            manageUserWindow.Show();
            this.Close();
        }
    }
}
