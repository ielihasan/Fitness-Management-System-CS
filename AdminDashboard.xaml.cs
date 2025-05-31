using System.Windows;
using System.Windows.Input;

namespace FitnessTrackingSystemWPF
{
    public partial class AdminDashboard : Window
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void ManageUsers_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the ManageUser window
            ManageUser manageUserWindow = new ManageUser();

            // Show the window
            manageUserWindow.Show();
            this.Close();
        }

        private void ManageInstructors_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the ManageInstructor window
            ManageInstructor manageInstructorWindow = new ManageInstructor();

            // Show the window
            manageInstructorWindow.Show();
            this.Close();
        }

        private void ManageInstruments_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the ManageInstruments window
            ManageInstruments manageInstrumentsWindow = new ManageInstruments();

            // Show the window
            manageInstrumentsWindow.Show();
            this.Close();
        }

        private void ManageAdmins_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the ManageAdmins window
            ManageAdmins manageAdminsWindow = new ManageAdmins();

            // Show the window
            manageAdminsWindow.Show();
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            // Exit the application
            Application.Current.Shutdown();
            this.Close();
        }

        private void About_Click(object sender, MouseButtonEventArgs e)
        {
            string aboutMessage = @"
=== About Fitness Tracking System ===

The Fitness Tracking System is a comprehensive software solution designed to streamline the management of fitness centers and gyms. It provides an intuitive interface to handle tasks efficiently and ensures the best experience for administrators, trainers, and users alike.

Key Features:
- User Management: Add, update, search, and manage users' profiles.
- Instructor Management: Keep track of instructors, including adding, updating, and searching them by ID.
- Instrument Management: Organize and maintain fitness equipment with options to add, update, and list all instruments.
- Admin Tools: Manage admins with functionalities like adding, removing, searching, and password updates.
- Data Security: Incorporates secure storage and encryption for user and admin credentials.
- Responsive Design: A user-friendly interface optimized for various screen sizes.

License Information:
The Fitness Tracking System is licensed under the MIT License:
--------------------------------------------------------
Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the ""Software""), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
- The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
- THE SOFTWARE IS PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE, AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES, OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT, OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

Support:
- Contact Us: For any inquiries, please reach out to support@fitnesstrackingsystem.com.
- Website: Visit our official website at [www.fitnesstrackingsystem.com](#).
- Documentation: Comprehensive guides and FAQs are available at [docs.fitnesstrackingsystem.com](#).

Version: 1.0.0
Release Date: [Insert Date]

This software is built to revolutionize fitness management and bring digital transformation to your fitness center.

Thank you for using Fitness Tracking System!
";

            MessageBox.Show(aboutMessage,
                            "About Fitness Tracking System",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Display a MessageBox asking the user if they want to log out
            MessageBoxResult result = MessageBox.Show("You are about to log out. Do you want to continue?",
                                                      "Log Out Warning",
                                                      MessageBoxButton.YesNo,
                                                      MessageBoxImage.Warning);

            // If the user clicks "Yes", navigate to the Login page
            if (result == MessageBoxResult.Yes)
            {
                LoginPage loginPage = new LoginPage();
                loginPage.Show();
                this.Close();
            }
            // If the user clicks "No", do nothing and stay on the current page
            else
            {
                // Do nothing, stay on the current page
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            // Display a confirmation message before logging out
            MessageBoxResult result = MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // Navigate to the login page
                LoginPage loginPage = new LoginPage();
                loginPage.Show();
                this.Close(); // Close the current window
            }
        }
    }
}
