using System;
using System.Windows;
using System.Windows.Input;

namespace FitnessTrackingSystemWPF
{
    public partial class SearchAdmin : Window
    {
        private AdminCollection adminCollection;

        public SearchAdmin()
        {
            InitializeComponent();

            // Initialize AdminCollection to access admin-related functionalities
            adminCollection = new AdminCollection();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Validate Admin ID input
            string adminId = AdminIdInput.Text.Trim();
            if (string.IsNullOrEmpty(adminId))
            {
                MessageBox.Show("Please enter a valid Admin ID.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                // Search for the admin by ID
                Admin foundAdmin = adminCollection.SearchAdminById(adminId);

                if (foundAdmin != null)
                {
                    // Display the found admin's details
                    ResultText.Text = $"Admin Found:\n\nUsername: {foundAdmin.Username}\nAdmin ID: {foundAdmin.AdminId}";
                }
                else
                {
                    // Display a message if no admin is found
                    ResultText.Text = "Admin not found with the provided ID.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while searching for the admin:\n{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
