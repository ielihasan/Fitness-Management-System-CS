using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FitnessTrackingSystemWPF
{
    public partial class AddInstructor : Window
    {
        private readonly InstructorCollection instructorCollection;

        public AddInstructor()
        {
            InitializeComponent();

            // Initialize the InstructorCollection with the desired table name
            instructorCollection = new InstructorCollection("Instructors");
        }

        // Event handler for AddInstructor button click
        private void AddInstructor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Retrieve input values from text boxes
                string instructorId = InstructorIdInput.Text.Trim();
                string name = InstructorNameInput.Text.Trim();
                string specialization = InstructorSpecializationInput.Text.Trim();

                // Validate inputs
                if (string.IsNullOrEmpty(instructorId) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(specialization))
                {
                    MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Create a new Instructor object
                Instructor newInstructor = new Instructor
                {
                    InstructorId = instructorId,
                    Name = name,
                    Specialization = specialization
                };

                // Add the instructor to the collection
                instructorCollection.AddInstructor(newInstructor);

                // Show success message
                MessageBox.Show("Instructor added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Clear input fields
                InstructorIdInput.Clear();
                InstructorNameInput.Clear();
                InstructorSpecializationInput.Clear();
            }
            catch (Exception ex)
            {
                // Handle any exceptions and show error message
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
