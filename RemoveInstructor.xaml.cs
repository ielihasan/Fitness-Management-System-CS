using System;
using System.Windows;
using System.Windows.Input;

namespace FitnessTrackingSystemWPF
{
    public partial class RemoveInstructor : Window
    {
        private readonly InstructorCollection instructorCollection;

        public RemoveInstructor()
        {
            InitializeComponent();

            // Initialize the InstructorCollection with the table name
            instructorCollection = new InstructorCollection("Instructors");
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
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

                // Attempt to remove the instructor
                instructorCollection.RemoveInstructor(instructorId);

                // Display success message
                MessageBox.Show($"Instructor with ID '{instructorId}' has been removed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

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
