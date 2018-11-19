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
        SqlConnection Conn_Regis = new SqlConnection("Data Source=DESKTOP-QULTHGL\\SQLEXPRESS;Initial Catalog=VideoRentalDB;Integrated Security=True");
        SqlCommand cmd_Regis = new SqlCommand();
        String Query_Regis;

        public void Regis( string UserName, string Password, string FullName, int Age)
        {
            try
            {
                cmd_Regis.Parameters.Clear();
                cmd_Regis.Connection = Conn_Regis;

               
                Query_Regis = "Insert into UserTable(  UserName, Password, FullName, Age) Values(@UserName, @Password, @FullName, @Age)";

               
                cmd_Regis.Parameters.AddWithValue("@UserName", UserName);
                cmd_Regis.Parameters.AddWithValue("@Password", Password);
                cmd_Regis.Parameters.AddWithValue("@FullName", FullName);
                cmd_Regis.Parameters.AddWithValue("@Age", Age);

                cmd_Regis.CommandText = Query_Regis;

                //connection opened
                Conn_Regis.Open();

                //Executed query
                cmd_Regis.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                // show error Message
                MessageBox.Show("Database Exception" + ex.Message);
                
            }
            finally
            {
              // close connection
                if (Conn_Regis != null)
                {
                    Conn_Regis.Close();
                }
            }
        }
    }
}
