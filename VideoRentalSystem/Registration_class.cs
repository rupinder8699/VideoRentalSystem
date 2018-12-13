using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VideoRentalSystem
{
    public class Registration_class
    {

        // Sql database connection link used for storing data database.
        SqlConnection Conn_Regis = new SqlConnection("Data Source=DESKTOP-QULTHGL\\SQLEXPRESS;Initial Catalog=VideoRentalDB;Integrated Security=True");
        SqlCommand Cmdd_Regis = new SqlCommand();
        String Strr_Regis;

        //Regis() used to instert new user data in database table with the help of insert query 
        public void Regis(string UserName, string Password, string FullName, int Age)
        {
            try
            {
                Cmdd_Regis.Parameters.Clear();
                Cmdd_Regis.Connection = Conn_Regis;

               //here the insert query inset the new user data to the database table.
                Strr_Regis = "Insert into UserTable(UserName, Password, FullName, Age) Values(@UserName, @Password, @FullName, @Age)";

                // below parameters add to command the object
                Cmdd_Regis.Parameters.AddWithValue("@UserName", UserName);
                Cmdd_Regis.Parameters.AddWithValue("@Password", Password);
                Cmdd_Regis.Parameters.AddWithValue("@FullName", FullName);
                Cmdd_Regis.Parameters.AddWithValue("@Age", Age);

                Cmdd_Regis.CommandText = Strr_Regis;

                //here connection is opened
                Conn_Regis.Open();

                //the executed query
                Cmdd_Regis.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                // if there is error this message will pop up.
                MessageBox.Show("Database Exception" + ex.Message);
                
            }
            finally
            {
                // connection closed here
                if (Conn_Regis != null)
                {
                    Conn_Regis.Close();
                }
            }
        }
    }
}
