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
using System.Data.SqlClient;
using System.Data;

namespace VideoRentalSystem
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        //Login_Button_Click() is used to insert select query that will help to select particular user for login from Users table.
        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {

            //Sql database connection used to select user from the database table for login
            SqlConnection Conn = new SqlConnection("Data Source = DESKTOP-QULTHGL\\SQLEXPRESS; Initial Catalog=VideoRentalDB; Integrated Security=True");

                try

                {

                SqlCommand Cmdd = new SqlCommand();

                SqlDataReader SqlReader;

                string Strr;

                Cmdd.Connection = Conn;

                Strr = "Select * from UserTable where UserName = '" +TxtUserName.Text + "' and Password = '" + TxtPassword.Text + "'";

                Cmdd.CommandText = Strr;

                Conn.Open();

                SqlReader = Cmdd.ExecuteReader();

                int count = 0;

                 while (SqlReader.Read())

                {
                    count++;                                         
                }

                 //if the username is match with sql database table then VideoRental form will be open .
                 //after open next form the login foem will be closed.
                if (count == 1)
                {
                   Conn.Close();
                   (new VideoRental()).Show();
                   this.Close();

                }

               

                else

                {
                    //if the username or password did not match to the stored data,this message will pop up.
                    MessageBox.Show("Check Username or Password");

                    Conn.Close();

                }

            }

            catch (Exception ex)

            {

                MessageBox.Show("Database Exception" + ex.Message);

                Conn.Close();

            }





        }
        //Register_Button_Click() button will bring the registration form for the new user if he/she did not have account.
        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            (new Registration()).Show();
            this.Close();
        }

        private void TxtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
