using System;
using System.Windows;
using System.Windows.Input;

namespace FitnessTrackingSystemWPF
{
    public partial class AddInstrument : Window
    {
        private readonly InstrumentsCollection instrumentsCollection;

        public AddInstrument()
        {
            InitializeComponent();
            instrumentsCollection = new InstrumentsCollection(); // Initialize InstrumentsCollection
        }

        // Event handler for the "Add Instrument" button click
        private void AddInstrument_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get input values from TextBox CaretBrush="white"es
                string instrumentName = InstrumentNameInput.Text;
                string instrumentPrice = InstrumentPriceInput.Text;
                string instrumentBarcode = InstrumentBarcodeInput.Text;
                int instrumentType;

                // Validate inputs
                if (string.IsNullOrEmpty(instrumentName) ||
                    string.IsNullOrEmpty(instrumentPrice) ||
                    string.IsNullOrEmpty(instrumentBarcode) ||
                    !int.TryParse(InstrumentTypeInput.Text, out instrumentType))
                {
                    MessageBox.Show("Please fill in all fields correctly.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Create a new instrument object
                Instruments newInstrument = new Instruments
                {
                    InstrumentsName = instrumentName,
                    InstrumentsPrice = instrumentPrice,
                    InstrumentsBarcode = instrumentBarcode,
                    InstrumentsType = instrumentType
                };

                // Add the instrument to the collection using InstrumentsCollection
                instrumentsCollection.AddInstrument(newInstrument);

                // Provide feedback to the user
                MessageBox.Show("Instrument added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

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
            InstrumentNameInput.Clear();
            InstrumentPriceInput.Clear();
            InstrumentBarcodeInput.Clear();
            InstrumentTypeInput.Clear();
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
