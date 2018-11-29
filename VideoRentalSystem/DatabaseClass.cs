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
                Cmdd.Parameters.Clear();
                Cmdd.Connection = this.Conn;
                Strr = "Delete from Customer where CustID like @CustID";
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@CustID", CustID) };
                Cmdd.Parameters.Add(parameterArray[0]);
                Cmdd.CommandText = Strr;
                Conn.Open();
                Cmdd.ExecuteNonQuery();
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

    

public DataTable MoviData()
{
    DataTable table = new DataTable();
    try
    {
        this.Cmdd.Connection = this.Conn;
        this.Strr = "Select * from Movies";
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

public void Add_movi(string Rating_TextBox, string Title_TextBox, string Year_TextBox, string Rental_Cost_TextBox, string Copies_TextBox, string Plot_TextBox, string Genre_TextBox)
{
    this.Cmdd.Parameters.Clear();
    try
    {
        this.Cmdd.Parameters.Clear();
        this.Cmdd.Connection = this.Conn;
        this.Strr = "Insert into Movies(Rating,Title,Year,Rental_Cost,Copies,Plot,Genre) Values(@Rating, @Title, @Year, @Rental_Cost, @Copies, @Plot, @Genre)";
        SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@Rating", Rating_TextBox), new SqlParameter("@Title", Title_TextBox), new SqlParameter("@Year", Year_TextBox), new SqlParameter("@Rental_Cost", Rental_Cost_TextBox), new SqlParameter("@Copies", Copies_TextBox), new SqlParameter("@Plot", Plot_TextBox), new SqlParameter("@Genre", Genre_TextBox) };
        this.Cmdd.Parameters.Add(parameterArray[0]);
        this.Cmdd.Parameters.Add(parameterArray[1]);
        this.Cmdd.Parameters.Add(parameterArray[2]);
        this.Cmdd.Parameters.Add(parameterArray[3]);
        this.Cmdd.Parameters.Add(parameterArray[4]);
        this.Cmdd.Parameters.Add(parameterArray[5]);
        this.Cmdd.Parameters.Add(parameterArray[6]);

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

public void Update_movi(int MovieID, string Rating, string Title, string Year, int Rental_Cost, string Copies, string Plot, string Genre)
{
    try
    {
        Cmdd.Parameters.Clear();
        Cmdd.Connection = Conn;
        Strr = "Update Movies Set Rating= @Rating,Title = @Title, Year = @Year,Rental_Cost = @Rental_Cost,Copies= @Copies,Plot = @Plot, Genre = @Genre where MovieID = @MovieID";
        SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@MovieID", MovieID), new SqlParameter("@Rating", Rating), new SqlParameter("@Title", Title), new SqlParameter("@Year", Year), new SqlParameter("@Rental_Cost", Rental_Cost), new SqlParameter("@Copies",Copies), new SqlParameter("@Plot", Plot), new SqlParameter("@Genre", Genre) };
        Cmdd.Parameters.Add(parameterArray[0]);
        Cmdd.Parameters.Add(parameterArray[1]);
        Cmdd.Parameters.Add(parameterArray[2]);
        Cmdd.Parameters.Add(parameterArray[3]);
        Cmdd.Parameters.Add(parameterArray[4]);
        Cmdd.Parameters.Add(parameterArray[5]);
        Cmdd.Parameters.Add(parameterArray[6]);
        Cmdd.Parameters.Add(parameterArray[7]);


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
public void Delete_movi(int MovieID)
{
    try
    {
        Cmdd.Parameters.Clear();
        Cmdd.Connection = this.Conn;
        Strr = "Delete from Movies where MovieID like @MovieID";
        SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@MovieID", MovieID) };
        Cmdd.Parameters.Add(parameterArray[0]);
        Cmdd.CommandText = Strr;
        Conn.Open();
        Cmdd.ExecuteNonQuery();
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