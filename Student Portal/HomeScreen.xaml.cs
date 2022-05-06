using Student_Portal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Student_Portal
{
    /// <summary>
    /// Interaction logic for HomeScreen.xaml
    /// </summary>
    public partial class HomeScreen : Window
    {
        public HomeScreen()
        {
            InitializeComponent();
            DataContext = new HomeViewModel();

            
        }

        public bool AdminValid = false;

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new HomeViewModel();
            SelectedItemLbl.Content = "Home";
        }

        private void CreateUserBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AdminValid)
            {
                DataContext = new CreateUserAccountViewModel();
                SelectedItemLbl.Content = "Create New User Account";
            }
        }

        private void UpdateUserBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AdminValid)
            {
                DataContext = new UpdateUserAccountViewModel();
                SelectedItemLbl.Content = "Update User Account";
            } 
        }

        private void DeleteUserBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AdminValid)
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
