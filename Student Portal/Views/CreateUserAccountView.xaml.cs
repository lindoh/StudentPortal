using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;


namespace Student_Portal.Views
{
    /// <summary>
    /// Interaction logic for CreateUserAccountView.xaml
    /// </summary>
    public partial class CreateUserAccountView : UserControl
    {
        #region Default Constructor
        public CreateUserAccountView()
        {
            InitializeComponent();
        }
        #endregion

        #region Database Objects Initialization
        SqlDatabase SqlDB = new SqlDatabase();

        #endregion

        #region Private Methods

        /// <summary>
        /// Registration button:
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            //Check if none of the text fields is empty
            if (FnameTxt.Text == "" || LnameTxt.Text == "" || GenderTxt.Text == "" || IdNumberTxt.Text == "" || NationalityTxt.Text == "" || DOBTxt.Text == ""
                || AddressTxt.Text == "" || NumberTxt.Text == "" || DateOfRegTxt.Text == "" || Stud_Lec_CBox.Text == "" || CourseNameCBox.Text == "")
            {
                MessageBox.Show("One or more text fields are empty", "Registration Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (GenUsernameTxt.Text == "" || GenPasswordTxt.Password == "")    
            {
                MessageBox.Show("Username and/or Password fields are empty", "Registration Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (IdNumberTxt.Text.Length != 13)
            {
                MessageBox.Show("ID Number must have 13 digits", "ID Number Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                //Save user login details first and save personal details
                //so that the auto generated Id from the user_logins table can be used for the user_details table 
                SqlDB.SaveUserLogins(GenUsernameTxt, GenPasswordTxt);
                SqlDB.SaveUserDetails(FnameTxt, LnameTxt, GenderTxt, IdNumberTxt, NationalityTxt, DOBTxt, AddressTxt, NumberTxt, DateOfRegTxt, Stud_Lec_CBox, CourseNameCBox);
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
            ClearTextboxes('u');
        }

        private void GenUsernameBtn_Click(object sender, RoutedEventArgs e)
        {
            //A string to store the 10 digits long username
            string username = "";

            string YearOfReg = "";

            try
            {
                //Get the year of registration
                YearOfReg = DateOfRegTxt.Text.Substring(0, 4);

                //Remove the '0' from 2022 or current year
                YearOfReg = YearOfReg.Substring(0, 1) + YearOfReg.Substring(2);
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("The Date of Registration field is Empty", "Username Generation Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            //The Invalid Flag becomes false when a valid username has been found
            bool Invalid = true;

            while (Invalid)
            {
                //Create username using year of registration and 7 random digits (1000000 - 9999999)
                username = YearOfReg + GenRandomNum(1000000, 9999999);

                //Check if generated username matches another in the database
                Invalid = SqlDB.CheckUsername(username);
            }

            //Update the GenUsername Textbox
            GenUsernameTxt.Text = username;
        }

        private void GenPasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            //Generate an 8 characters long password, with 2 upper case letters, 
            //3 numbers, and 3 lower case letters
            StringBuilder builder = new StringBuilder();
            builder.Append(GenRandomStr(2, false));
            builder.Append(GenRandomNum(100, 999));
            builder.Append(GenRandomStr(3, true));

            GenPasswordTxt.Password = builder.ToString();
        }

        #endregion

        #region Supporting Methods

        /// <summary>
        /// Clears all textboxes
        /// If argument character is 'u' clear all textboxes including Username
        /// Else clear Password textboxes only --> c = 'p'
        /// </summary>
        private void ClearTextboxes(char c)
        {
            if (c == 'u')
            {

            }
            else if (c == 'p')
            {

            }
        }

        private string GenRandomNum(int start, int end)
        {
            //Generate a random number between start and end values
            Random rnd = new Random();
            int Num = rnd.Next(start, end);

            return Num.ToString();
        }

        private string GenRandomStr(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random rnd = new Random();
            char c;

           for (int i = 0; i < size; i++)
           {
                //Create an ASCII Upper Case letter (A - Z) ==> (65 - 90)
                c = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * rnd.NextDouble() + 65)));
                builder.Append(c);
           }

           //If Lower Case Letters required
           if (lowerCase)
           {
                return builder.ToString().ToLower();
           }

           //Otherwise return an upper case string
           return builder.ToString();
        }

        #endregion
    }
}
