using System.Windows;

namespace FitnessTrackingSystemWPF
{
    /// <summary>
    /// Interaction logic for ManageAdmins.xaml
    /// </summary>
    public partial class ManageAdmins : Window
    {
        public ManageAdmins()
        {
            InitializeComponent();
        }

        private void AddAdmin_Click(object sender, RoutedEventArgs e)
        {
            AddAdmin addAdminWindow = new AddAdmin();
            addAdminWindow.Show();
            this.Close();
        }

        private void RemoveAdmin_Click(object sender, RoutedEventArgs e)
        {
            RemoveAdmin addAdminWindow = new RemoveAdmin();
            addAdminWindow.Show();
            this.Close();
        }

        private void SearchAdmin_Click(object sender, RoutedEventArgs e)
        {
            SearchAdmin searchAdminWindow = new SearchAdmin();
            searchAdminWindow.Show();
            this.Close();
        }

        private void UpdateAdminPassword_Click(object sender, RoutedEventArgs e)
        {
            UpdateAdmin updateAdmin = new UpdateAdmin();
            updateAdmin.Show();
            this.Close();
        }

        private void ViewAdminList_Click(object sender, RoutedEventArgs e)
        {
            ListAllAdmin listAllAdmin = new ListAllAdmin();
            listAllAdmin.Show();
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
