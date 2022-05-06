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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Student_Portal.Views
{
    /// <summary>
    /// Interaction logic for AdminAccountView.xaml
    /// </summary>
    public partial class AdminAccountView : UserControl
    {
        #region Default Constructor
        public AdminAccountView()
        {
            InitializeComponent();
        }
        #endregion

        #region Outside Class Objects
        HomeScreen Home = new HomeScreen();
        SqlDatabase SqlDB = new SqlDatabase();
        #endregion

        #region Private Methods
        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            //Check if none of the text fields is empty
            if (FnameTxt.Text == "" || LnameTxt.Text == "" || GenderTxt.Text == "" || IdNumberTxt.Text == "" || NationalityTxt.Text == "" || DOBTxt.Text == ""
                 || AddressTxt.Text == "" || NumberTxt.Text == "" || DateOfRegTxt.Text == "")
            {
                MessageBox.Show("One or more text fields are empty", "Registration Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (IdNumberTxt.Text.Length != 13)
            {
                //If Id number is not 13 digits long, notify the user
                MessageBox.Show("ID Number must have 13 digits", "ID Number Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                //Save admin details to the database
                SqlDB.SaveAdminDetails(FnameTxt, LnameTxt, GenderTxt, IdNumberTxt, NationalityTxt, DOBTxt, AddressTxt, NumberTxt, DateOfRegTxt);

                //If storing to database is successful
                MessageBox.Show("Account Successfully Updated", "Update Successful", MessageBoxButton.OK, MessageBoxImage.Information);

                clearTextBoxes();

            }
        }

        #endregion

        #region Supporting Methods
        private void clearTextBoxes()
        {
            FnameTxt.Text = "";
            LnameTxt.Text = "";
            GenderTxt.Text = "";
            IdNumberTxt.Text = "";
            NationalityTxt.Text = "";
            DOBTxt.Text = "";
            AddressTxt.Text = "";
            NumberTxt.Text = "";
            DateOfRegTxt.Text = "";
        }

        #endregion
    }
}
