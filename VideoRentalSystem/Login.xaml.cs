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

     
        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            
                SqlConnection SqlConn = new SqlConnection("Data Source = DESKTOP-QULTHGL\\SQLEXPRESS; Initial Catalog=VideoRentalDB; Integrated Security=True");

                try

                {

                SqlCommand SqlStr = new SqlCommand();

                SqlDataReader SqlReader;

                string SqlStmt;

                SqlStr.Connection = SqlConn;

                SqlStmt = "Select * from UserTable where UserName = '" +TxtUserName.Text + "' and Password = '" + TxtPassword.Text + "'";

                SqlStr.CommandText = SqlStmt;

                SqlConn.Open();

                SqlReader = SqlStr.ExecuteReader();

                int count = 0;

                 while (SqlReader.Read())

                {
                    count++;                                         
                }

                if (count == 1)
                {
                   SqlConn.Close();
                   (new VideoRental()).Show();
                   this.Close();

                }

               

                else

                {

                    MessageBox.Show("Check Username/Password");

                    SqlConn.Close();

                }

            }

            catch (Exception ex)

            {

                MessageBox.Show("Database Exception" + ex.Message);

                SqlConn.Close();

            }





        }

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            (new Registration()).Show();
            this.Close();
        }
    }
}
