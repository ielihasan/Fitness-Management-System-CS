using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FitnessTrackingSystemWPF
{
    /// <summary>
    /// Interaction logic for RemoveInstrument.xaml
    /// </summary>
    public partial class RemoveInstrument : Window
    {
        private InstrumentsCollection instrumentsCollection;

        public RemoveInstrument()
        {
            InitializeComponent();
            instrumentsCollection = new InstrumentsCollection(); // Initialize the InstrumentsCollection
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Get the instrument ID entered by the user
            if (int.TryParse(InstrumentIdInput.Text, out int instrumentID))
            {
                // Try to remove the instrument
                bool isRemoved = instrumentsCollection.RemoveInstrument(instrumentID);

                // Provide feedback to the user
                if (isRemoved)
                {
                    MessageBox.Show("Instrument removed successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Instrument not found. Please check the ID and try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                // If the ID is not a valid number
                MessageBox.Show("Please enter a valid instrument ID.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Border_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
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
