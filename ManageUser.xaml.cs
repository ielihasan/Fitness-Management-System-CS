using System.Windows;

namespace FitnessTrackingSystemWPF
{
    /// <summary>
    /// Interaction logic for ManageUser.xaml
    /// </summary>
    public partial class ManageUser : Window
    {
        public ManageUser()
        {
            InitializeComponent();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            AddUser addUserWindow = new AddUser();
            addUserWindow.Show();
            this.Close();
        }

        private void UpdateUser_Click(object sender, RoutedEventArgs e)
        {
            UpdateUser updateUser = new UpdateUser();
            updateUser.Show();
            this.Close();
        }

        private void SearchUser_Click(object sender, RoutedEventArgs e)
        {
            SearchUser searchUser = new SearchUser();
            searchUser.Show();
            this.Close();
        }

        private void RemoveUser_Click(object sender, RoutedEventArgs e)
        {
            RemoveUser removeUser = new RemoveUser();
            removeUser.Show();
            this.Close();
        }

        private void ListUsers_Click(object sender, RoutedEventArgs e)
        {
            ListAllUser listAllUser = new ListAllUser();
            listAllUser.Show();
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
