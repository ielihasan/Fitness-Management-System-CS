using System.Windows;

namespace FitnessTrackingSystemWPF
{
    /// <summary>
    /// Interaction logic for ManageInstruments.xaml
    /// </summary>
    public partial class ManageInstruments : Window
    {
        public ManageInstruments()
        {
            InitializeComponent();
        }

        private void AddInstrument_Click(object sender, RoutedEventArgs e)
        {
            AddInstrument addInstrumentWindow = new AddInstrument();
            addInstrumentWindow.Show();
            this.Close();
        }

        private void UpdateInstrument_Click(object sender, RoutedEventArgs e)
        {
            UpdateInstrument updateInstrumentWindow = new UpdateInstrument();
            updateInstrumentWindow.Show();
            this.Close();
        }

        private void SearchInstrument_Click(object sender, RoutedEventArgs e)
        {
            SearchInstrument searchInstrumentWindow = new SearchInstrument();
            searchInstrumentWindow.Show();
            this.Close();
        }

        private void RemoveInstrument_Click(object sender, RoutedEventArgs e)
        {
            RemoveInstrument searchInstrumentWindow = new RemoveInstrument();
            searchInstrumentWindow.Show();
            this.Close();
        }

        private void ListInstruments_Click(object sender, RoutedEventArgs e)
        {
            ListAllInstrument listAllInstrument = new ListAllInstrument();
            listAllInstrument.Show();
            this.Close();
        }

        private void BackToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
            this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
            this.Close();
        }
    }
}
