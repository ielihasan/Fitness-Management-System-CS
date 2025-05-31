using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FitnessTrackingSystemWPF
{
    public partial class ListAllInstrument : Window
    {
        private readonly DBHelperInstruments dbHelper;

        public ListAllInstrument()
        {
            InitializeComponent();

            // Initialize the DBHelperInstruments class to interact with the database
            dbHelper = new DBHelperInstruments();
        }

        // Event handler for the "Load All Instruments" button click
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get all instruments from the database
                List<Instruments> instruments = dbHelper.GetAllInstruments();

                // Check if there are any instruments to display
                if (instruments.Count == 0)
                {
                    MessageBox.Show("No instruments found.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    // Bind the list of instruments to the ListView
                    InstrumentListView.ItemsSource = instruments;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions and show error message
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ScrollViewer_KeyDown(object sender, KeyEventArgs e)
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
