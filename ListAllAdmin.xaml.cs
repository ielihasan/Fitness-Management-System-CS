using System;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;

namespace FitnessTrackingSystemWPF
{
    public partial class ListAllAdmin : Window
    {
        private AdminCollection adminCollection;

        public ListAllAdmin()
        {
            InitializeComponent();
            adminCollection = new AdminCollection();
        }

        // Event handler for the "Load All Admins" button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Retrieve all admins and bind them to the ListView
                List<Admin> admins = adminCollection.GetAllAdmins();
                AdminListView.ItemsSource = admins;

                if (admins.Count == 0)
                {
                    MessageBox.Show("No admins found.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading admins: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Event handler for handling key presses in the ScrollViewer
        private void ScrollViewer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                try
                {
                    // Navigate back to the ManageAdmins window
                    ManageAdmins manageAdminsWindow = new ManageAdmins();
                    manageAdminsWindow.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while navigating: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
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
