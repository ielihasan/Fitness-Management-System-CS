using System;
using System.Windows;
using System.Windows.Input;

namespace FitnessTrackingSystemWPF
{
    /// <summary>
    /// Interaction logic for SearchInstrument.xaml
    /// </summary>
    public partial class SearchInstrument : Window
    {
        private readonly InstrumentsCollection instrumentsCollection;

        public SearchInstrument()
        {
            InitializeComponent();
            instrumentsCollection = new InstrumentsCollection(); // Initialize InstrumentsCollection
        }

        // Event handler for the "Search Instrument" button click
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get the Instrument ID from input and validate it
                int instrumentId;
                if (!int.TryParse(InstrumentIdInput.Text, out instrumentId))
                {
                    MessageBox.Show("Please enter a valid Instrument ID.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Search for the instrument by ID
                Instruments instrument = instrumentsCollection.SearchInstrumentById(instrumentId);
                if (instrument == null)
                {
                    ResultText.Text = "Instrument not found.";
                }
                else
                {
                    // Display the instrument details in ResultText
                    ResultText.Text = $"Instrument ID: {instrument.InstrumentsID}\n" +
                                      $"Name: {instrument.InstrumentsName}\n" +
                                      $"Price: {instrument.InstrumentsPrice}\n" +
                                      $"Barcode: {instrument.InstrumentsBarcode}\n" +
                                      $"Type (in minutes): {instrument.InstrumentsType}";
                }
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
