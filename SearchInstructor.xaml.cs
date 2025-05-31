using System;
using System.Windows;
using System.Windows.Input;

namespace FitnessTrackingSystemWPF
{
    public partial class SearchInstructor : Window
    {
        private readonly InstructorCollection instructorCollection;

        public SearchInstructor()
        {
            InitializeComponent();

            // Initialize the InstructorCollection with the table name
            instructorCollection = new InstructorCollection("Instructors");
        }

        // Event handler for the Search Instructor button click
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Retrieve the Instructor ID from the input field
                string instructorId = InstructorIdInput.Text.Trim();

                // Validate input
                if (string.IsNullOrEmpty(instructorId))
                {
                    MessageBox.Show("Instructor ID is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Search for the instructor by ID
                Instructor instructor = instructorCollection.SearchInstructorById(instructorId);

                if (instructor != null)
                {
                    // Display the instructor details
                    ResultText.Text = $"Instructor Found:\n" +
                                      $"ID: {instructor.InstructorId}\n" +
                                      $"Name: {instructor.Name}\n" +
                                      $"Specialization: {instructor.Specialization}";
                }
                else
                {
                    // Show a not found message
                    ResultText.Text = "Instructor not found.";
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
