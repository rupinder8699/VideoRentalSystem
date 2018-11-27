using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VideoRentalSystem
{
    class DatabaseClass
    {
        private SqlConnection Conn = new SqlConnection(@"Data Source=DESKTOP-QULTHGL\SQLEXPRESS;Initial Catalog=VideoRentalDB;Integrated Security=True");
        private SqlCommand Cmdd = new SqlCommand();
        private SqlDataReader SqlReader;
        private string Strr;

        public DataTable CustData()
        {
            DataTable table = new DataTable();
            try
            {
                this.Cmdd.Connection = this.Conn;
                this.Strr = "Select * from Customer";
                this.Cmdd.CommandText = this.Strr;
                this.Conn.Open();
                this.SqlReader = this.Cmdd.ExecuteReader();
                if (this.SqlReader.HasRows)
                {
                    table.Load(this.SqlReader);
                }
                this.Conn.Close();
                return table;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception" + exception.Message);
                this.Conn.Close();
                return null;
            }
        }

        public void Add_cust(string FirstName_TextBox, string LastName_TextBox, string Address_TextBox, string Phone_TextBox)
        {
            this.Cmdd.Parameters.Clear();
            try
            {
                this.Cmdd.Parameters.Clear();
                this.Cmdd.Connection = this.Conn;
                this.Strr = "Insert into Customer(FirstName,LastName,Address,Phone) Values(@FirstName, @LastName, @Address, @Phone)";
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@FirstName", FirstName_TextBox), new SqlParameter("@LastName", LastName_TextBox), new SqlParameter("@Address", Address_TextBox), new SqlParameter("@Phone", Phone_TextBox) };
                this.Cmdd.Parameters.Add(parameterArray[0]);
                this.Cmdd.Parameters.Add(parameterArray[1]);
                this.Cmdd.Parameters.Add(parameterArray[2]);
                this.Cmdd.Parameters.Add(parameterArray[3]);
                
                this.Cmdd.CommandText = this.Strr;
                this.Conn.Open();
                this.Cmdd.ExecuteNonQuery();
                this.Conn.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception" + exception.Message);
                this.Conn.Close();
            }
        }

        public void Update_cust(int CustID, string FirstName, string LastName, string Address, int Phone)
        {
            try
            {
                Cmdd.Parameters.Clear();
                Cmdd.Connection = Conn;
                Strr = "Update Customer Set FirstName= @FirstName, LastName = @LastName, Address = @Address, Phone = @Phone where CustID = @CustID";
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@CustID", CustID), new SqlParameter("@FirstName", FirstName), new SqlParameter("@LastName", LastName), new SqlParameter("@Address", Address), new SqlParameter("@Phone", Phone) };
                Cmdd.Parameters.Add(parameterArray[0]);
                Cmdd.Parameters.Add(parameterArray[1]);
                Cmdd.Parameters.Add(parameterArray[2]);
                Cmdd.Parameters.Add(parameterArray[3]);
                Cmdd.Parameters.Add(parameterArray[4]);
               
                Cmdd.CommandText = Strr;
                Conn.Open();
                Cmdd.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception " + exception.Message);
            }
            finally
            {
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }
        public void Delete_cust(int CustID)
        {
            try
            {
                this.Cmdd.Connection = this.Conn;
                this.Strr = "Delete from Customer where CustID like @CustID";
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@CustID", CustID) };
                this.Cmdd.Parameters.Add(parameterArray[0]);
                this.Cmdd.CommandText = this.Strr;
                this.Conn.Open();
                this.Cmdd.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception" + exception.Message);
            }
            finally
            {
                if (this.Conn != null)
                {
                    this.Conn.Close();
                }
            }
        }

    }
}