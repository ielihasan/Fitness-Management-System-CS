using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FitnessTrackingSystemWPF
{
    public partial class ListAllInstructor : Window
    {
        private readonly InstructorCollection instructorCollection;

        public ListAllInstructor()
        {
            InitializeComponent();

            // Initialize the InstructorCollection with the table name "Instructors"
            instructorCollection = new InstructorCollection("Instructors");
        }

        // Event handler for the Load All Instructors button click
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get all instructors from the collection
                List<Instructor> instructors = instructorCollection.GetAllInstructors();

                // Check if there are any instructors to display
                if (instructors.Count == 0)
                {
                    MessageBox.Show("No instructors found.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    // Bind the list of instructors to the ListView
                    InstructorListView.ItemsSource = instructors;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions and show error message
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ScrollViewer_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                // Create an instance of the ManageInstructor window
                ManageInstructor manageInstructorWindow = new ManageInstructor();

                // Show the window
                manageInstructorWindow.Show();
                this.Close();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the ManageInstructor window
            ManageInstructor manageInstructorWindow = new ManageInstructor();

            // Show the window
            manageInstructorWindow.Show();
            this.Close();
        }
    }
}
