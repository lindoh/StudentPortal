using System.Data.SqlClient;
using System.Windows.Controls;

namespace Student_Portal
{
    public class SqlDatabase
    {
        public SqlDatabase()
        {
            
        }

        #region Database Objects

        SqlConnection con = new SqlConnection("Server = LAPTOP-J3M5FNUA; Database = StudentPortalData; Trusted_Connection=True");
        SqlCommand cmd = new SqlCommand();

        #endregion

        #region Class Methods

        public bool UserLogin(TextBox username, PasswordBox password)
        {
            con.Open();

            string sqlText = "SELECT * FROM user_logins WHERE username = '"+username.Text+"' and password = '"+password.Password+"'";
            cmd = new SqlCommand(sqlText, con);
            SqlDataReader dr = cmd.ExecuteReader();

            bool dataReader = dr.Read();

            con.Close();

            return dataReader;
   
        }

        //Store infor to the database
        public void SaveUserLogins(TextBox usernameTxt, PasswordBox passwordTxt)
        {

            using (con)
            {
                con.Open();

                //Store user's Username and Password
                string sqlText = "INSERT INTO user_logins (username, password) VALUES ('" + usernameTxt.Text + "', '" + passwordTxt.Password + "')";
                cmd = new SqlCommand(sqlText, con);

                cmd.ExecuteNonQuery();
                con.Close();
            }
        } 

        public void SaveUserDetails(TextBox FnameTxt, TextBox LnameTxt, ComboBox GenderTxt, TextBox IdNumberTxt, TextBox NationalityTxt, 
            DatePicker DOBTxt, TextBox AddressTxt, TextBox NumberTxt, DatePicker DateOfRegTxt, ComboBox Stud_Lec_CBox, ComboBox CourseNameCBox)
        {
            con.Open();     //Open Connection to the database

            //Store user personal details in the database
            string sqlText = "INSERT INTO users_details (ID, Fname, Lname, Gender, IdNumber, Nationality, DOB, Address, PhoneNumber, DateOfReg, StuLec, Course) " +
                "VALUES(SELECT MAX(ID) FROM user_logins, '" + FnameTxt.Text + "', '" + LnameTxt.Text + "', '" + GenderTxt.Text + "', '" + IdNumberTxt.Text + "'," +
                " '" + NationalityTxt.Text + "', '" + DOBTxt.Text + "', '" + AddressTxt.Text + "', '" + NumberTxt.Text + "', '" + DateOfRegTxt.Text + "', " +
                "'" + Stud_Lec_CBox.Text + "', '" + CourseNameCBox.Text + "')";

            cmd = new SqlCommand(sqlText, con);
            cmd.ExecuteNonQuery();

            con.Close();        //Close connection
        }

        public void SaveAdminDetails(TextBox FnameTxt, TextBox LnameTxt, ComboBox GenderTxt, TextBox IdNumberTxt, TextBox NationalityTxt,
            DatePicker DOBTxt, TextBox AddressTxt, TextBox NumberTxt, DatePicker DateOfRegTxt)
        {
            con.Open();     //Open Connection to the database

            //Store user personal details in the database
            string sqlText = "INSERT INTO admin_details (ID, Fname, Lname, Gender, IdNumber, Nationality, DOB, Address, PhoneNumber, DateOfReg) " +
                "VALUES((SELECT MAX(ID) FROM user_logins), '" + FnameTxt.Text + "', '" + LnameTxt.Text + "', '" + GenderTxt.Text + "', '" + IdNumberTxt.Text + "'," +
                " '" + NationalityTxt.Text + "', '" + DOBTxt.Text + "', '" + AddressTxt.Text + "', '" + NumberTxt.Text + "', '" + DateOfRegTxt.Text + "')";

            cmd = new SqlCommand(sqlText, con);
            cmd.ExecuteNonQuery();

            con.Close();        //Close connection
        }

        public bool CheckUsername(string username)
        {
            bool Invalid = true;

            //Open Connection to the database to check the generated username if it exists already
            con.Open();

            string db_username = "SELECT * FROM tbl_users WHERE username = '" + username + "'";
            cmd = new SqlCommand(db_username, con);       //Initialize the command    
            SqlDataReader dr = cmd.ExecuteReader();       //Execute the command

            if (!dr.Read())
            {
                //If the username doesn't exist in the database, exit the loop
                Invalid = false;
                con.Close();      //Close connection to the database
            }

            return Invalid;
        }

        #endregion



        //}
        //catch (OleDbException)
        //{
        //    MessageBox.Show("Couldn't open connection to the database", "Database Connection Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //}
    }
}
