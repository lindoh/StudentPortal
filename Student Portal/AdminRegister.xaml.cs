using System.Windows;
using System.Data.OleDb;

namespace Student_Portal
{
    /// <summary>
    /// Interaction logic for AdminRegister.xaml
    /// </summary>
    public partial class AdminRegister : Window
    {
        #region Default Constractor
        public AdminRegister()
        {
            InitializeComponent();
        }

        #endregion

        #region Database Objects Initialization
        SqlDatabase SqlDB = new SqlDatabase();

        #endregion

        #region Private Methods
        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            //Check if all text fields have data
            if (UsernameTxt.Text == "" && PasswordTxt.Password == "" && ConPasswordTxt.Password == "")
            {
                MessageBox.Show("Username and Password fields are empty", "Registration Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (PasswordTxt.Password == ConPasswordTxt.Password)       //If the passwords match
            {
                SqlDB.SaveUserLogins(UsernameTxt, PasswordTxt);

                MessageBox.Show("Account Successfully Created", "Registration Success", MessageBoxButton.OK, MessageBoxImage.Information);
                clearTextboxes();

                //Navigate to the admin Home screen
                new HomeScreen().Show();
                Hide();
            }
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            clearTextboxes();
        }

        private void BackToLoginLbl_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            //Navigate to the Login Screen
            new MainWindow().Show();
            Hide();
        }

        #endregion

        #region Supporting Methods

        /// <summary>
        /// Clears all textboxes
        /// </summary>
        private void clearTextboxes()
        {
            UsernameTxt.Text = string.Empty;
            PasswordTxt.Password = string.Empty;
            ConPasswordTxt.Password = string.Empty;
        }

        #endregion
    }
}
