using Student_Portal.ViewModels;
using System.Windows;


namespace Student_Portal
{
    /// <summary>
    /// Interaction logic for HomeScreen.xaml
    /// </summary>
    public partial class HomeScreen : Window
    {
        /***********TO DO
         *CREATE A FLAG TO CONTROL THE BUTTONS 
         */

        SqlDatabase SqlDB = new SqlDatabase();

        public HomeScreen()
        {
            InitializeComponent();
            DataContext = new HomeViewModel();
        }

    
        

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new HomeViewModel();
            SelectedItemLbl.Content = "Home";
        }

        private void CreateUserBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SqlDB.AdmnAccExist())
            {
                DataContext = new CreateUserAccountViewModel();
                SelectedItemLbl.Content = "Create New User Account";
            }
        }

        private void UpdateUserBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SqlDB.AdmnAccExist())
            {
                DataContext = new UpdateUserAccountViewModel();
                SelectedItemLbl.Content = "Update User Account";
            } 
        }

        private void DeleteUserBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SqlDB.AdmnAccExist())
            {
                DataContext = new DeleteUserAccountViewModel();
                SelectedItemLbl.Content = "Delete User Account";
            }
        }

        private void UpdateAdminBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new AdminAccontViewModel();
            SelectedItemLbl.Content = "Admin Personal Details";
        }

       
    }
}
