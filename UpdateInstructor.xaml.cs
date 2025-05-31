using System;
using System.Windows;
using System.Windows.Controls;

namespace FitnessTrackingSystemWPF
{
    public partial class UpdateInstructor : Window
    {
        private readonly InstructorCollection instructorCollection;

        public UpdateInstructor()
        {
            InitializeComponent();

            // Initialize the InstructorCollection with the table name
            instructorCollection = new InstructorCollection("Instructors");
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Retrieve input values
                string instructorId = InstructorIdInput.Text.Trim();
                string newName = NameInput.Text.Trim();
                string newSpecialization = SpecializationInput.Text.Trim();

                // Validate Instructor ID
                if (string.IsNullOrEmpty(instructorId))
                {
                    MessageBox.Show("Instructor ID is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Search for the instructor by ID
                Instructor existingInstructor = instructorCollection.SearchInstructorById(instructorId);

                if (existingInstructor == null)
                {
                    MessageBox.Show("Instructor not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Update fields if new values are provided
                if (!string.IsNullOrEmpty(newName))
                {
                    existingInstructor.Name = newName;
                }

                if (!string.IsNullOrEmpty(newSpecialization))
                {
                    existingInstructor.Specialization = newSpecialization;
                }

                // Update instructor in the collection
                instructorCollection.UpdateInstructorInfo(existingInstructor);

                // Show success message
                MessageBox.Show("Instructor updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Clear input fields
                InstructorIdInput.Clear();
                NameInput.Clear();
                SpecializationInput.Clear();

                // Create an instance of the ManageInstructor window
                ManageInstructor manageInstructorWindow = new ManageInstructor();

                // Show the window
                manageInstructorWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                // Handle any exceptions and show error message
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ManageInstructor manageInstructor = new ManageInstructor();
            manageInstructor.Show();
            this.Close();
        }
    }
}
