using System.Windows;

namespace FitnessTrackingSystemWPF
{
    /// <summary>
    /// Interaction logic for ManageInstructor.xaml
    /// </summary>
    public partial class ManageInstructor : Window
    {
        public ManageInstructor()
        {
            InitializeComponent();
        }

        private void AddInstructor_Click(object sender, RoutedEventArgs e)
        {
            AddInstructor addInstructorWindow = new AddInstructor();
            addInstructorWindow.Show();
            this.Close();
        }

        private void UpdateInstructor_Click(object sender, RoutedEventArgs e)
        {
            UpdateInstructor updateInstructorWindow = new UpdateInstructor();
            updateInstructorWindow.Show();
            this.Close();
        }

        private void SearchInstructor_Click(object sender, RoutedEventArgs e)
        {
            SearchInstructor searchInstructorWindow = new SearchInstructor();
            searchInstructorWindow.Show();
            this.Close();
        }

        private void RemoveInstructor_Click(object sender, RoutedEventArgs e)
        {
            RemoveInstructor removeInstructorWindow = new RemoveInstructor();
            removeInstructorWindow.Show();
            this.Close();
        }

        private void ListInstructors_Click(object sender, RoutedEventArgs e)
        {
            ListAllInstructor listAllInstructor = new ListAllInstructor();
            listAllInstructor.Show();
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
