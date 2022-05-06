using System.Windows;
using System.Windows.Input;
using System.Data.OleDb;

//TO DO:
//* Add Exceptions to database connection, commands, and everywhere necessary
//* Update the last commit with a typo
//

namespace Student_Portal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Default Constructor
        public MainWindow()
        {
            InitializeComponent();
            UsernameTxt.Focus();
        }

        #endregion

        #region Database Objects
        SqlDatabase SqlDB = new SqlDatabase();

        #endregion

        #region Private Methods
        /// <summary>
        /// Login button click method.
        /// Checks if text boxes are not empty, 
        /// connects to the data base and compare submited info. from text boxes to the one in the database
        /// Finally open the Home screen if there are no errors
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            //Check if text fields are empty
            if (UsernameTxt.Text == "" && PasswordTxt.Password == "")
            {
                MessageBox.Show("Username and Password fields are empty", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
               
                bool dataReader = SqlDB.UserLogin(UsernameTxt, PasswordTxt);

                //If reading from data source is successful, open the next window (home HomeScreen)
                if (dataReader)
                {
                    SelectUser(UsernameTxt.Text);
                }
                else
                {
                    MessageBox.Show("Invalid username or password, please try again", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                //Clear textboxes
                clearTextboxes();
            }
        }

        /// <summary>
        /// Clears all textboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            //Clear textboxes
            clearTextboxes();
        }

        private void ResetPasswordLbl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void RegisterLbl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new AdminRegister().Show();
            Hide();
        }

        #endregion

        #region Supporting Methods

        /// <summary>
        /// Clears all textboxes
        /// </summary>
        private void clearTextboxes()
        {
            UsernameTxt.Text  = string.Empty;
            PasswordTxt.Password = string.Empty;
        }

        /// <summary>
        /// The SelectUser methods selects a user based on their username
        /// adm == Administrator, 222 = student, other username = lecture
        /// </summary>
        /// <param name="username"></param>
        private void SelectUser(string username)
        {
            //Select the first 3 characters and use them as a user id
            string id = username.Substring(0, 3);

            switch(id)
            {
                case "adm":         //For Administrators the username starts with "adm"
                    new HomeScreen().Show();
                    break;
                case "222":         //For students the username starts with "222" for year 2022
                    new HomeScreen().Show();
                    break;
                default:            //Else the user could be a lecture
                    break;
            }

            Hide();                 //Hide this screen
        }


        #endregion

    }
}
