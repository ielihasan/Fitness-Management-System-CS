using System;
using System.Windows;
using System.Windows.Input;

namespace FitnessTrackingSystemWPF
{
    public partial class UpdateInstrument : Window
    {
        private readonly InstrumentsCollection instrumentsCollection;

        public UpdateInstrument()
        {
            InitializeComponent();
            instrumentsCollection = new InstrumentsCollection(); // Initialize InstrumentsCollection
        }

        // Event handler for the "Update Instrument" button click
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get input values from TextBox CaretBrush="white"es
                int instrumentId;
                if (!int.TryParse(InstrumentIdInput.Text, out instrumentId))
                {
                    MessageBox.Show("Please enter a valid Instrument ID.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Search for the instrument by ID
                Instruments existingInstrument = instrumentsCollection.SearchInstrumentById(instrumentId);
                if (existingInstrument == null)
                {
                    MessageBox.Show("Instrument not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Update the instrument's properties if new values are provided
                if (!string.IsNullOrEmpty(InstrumentNameInput.Text))
                    existingInstrument.InstrumentsName = InstrumentNameInput.Text;

                if (!string.IsNullOrEmpty(InstrumentPriceInput.Text))
                    existingInstrument.InstrumentsPrice = InstrumentPriceInput.Text;

                // Update the instrument info in the collection
                instrumentsCollection.UpdateInstrumentInfo(existingInstrument);

                // Provide feedback to the user
                MessageBox.Show("Instrument updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Optionally, clear the form
                ClearForm();
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Method to clear the form inputs
        private void ClearForm()
        {
            InstrumentIdInput.Clear();
            InstrumentNameInput.Clear();
            InstrumentPriceInput.Clear();
        }

        private void ScrollViewer_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                // Create an instance of the ManageInstruments window
                ManageInstruments manageInstrumentsWindow = new ManageInstruments();

                // Show the window
                manageInstrumentsWindow.Show();
                this.Close();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the ManageInstruments window
            ManageInstruments manageInstrumentsWindow = new ManageInstruments();

            // Show the window
            manageInstrumentsWindow.Show();
            this.Close();
        }
    }
}
