using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRentalSystem
{
    class Database_Class
    {
    }
}
SqlConnection SqlCnn = new SqlConnection("Data Source = DESKTOP - QULTHGL\\SQLEXPRESS; Initial Catalog = VideoRentalDB; Integrated Security = True");
SqlCommand Sqlcamd = new SqlCommand();
SqlDataReader SqlReader;
String SqlString;

public DataTable CustomerData()
{
    DataTable Dat = new DataTable();
    try
    {
        SqlStr.Connection = SqlCnn;
        SqlString = "Select * from customer";
        SqlStr.CommandText = SqlString;

        SqlCnn.Open();
        SqlReader = Sqlcamd.ExecuteReader();
        if (SqlReader.HasRows)
        {
            Dat.Load(SqlReader);
        }
        SqlCnn.Close();
        return Dat;
    }
    catch (Exception ex)
    {
        MessageBox.Show("Database Exception" + ex.Message);
        SqlCnn.Close();
        return false;
    }
    }
   
      public void Add_Customer(string FirstName_TextBox, string LastName_TextBox,string Address_TextBox,string Phone_TextBox)
{
    SqlCamd.Parameter.Clear();
    try
    {
        SqlCamd.Parameter.Clear();
        SqlCamd.Connection = SqlCnn;
        SqlString = "Insert into Customer(FirstName, LastName, Address, Phone) Values @Fistname, @LastName, @Address, @Phone)";

        SqlCamd.Parameters.Add(para[0]);
        SqlCamd.Parameters.Add(para[1]);
        SqlCamd.Parameters.Add(para[2]);
        SqlCamd.Parameters.Add(para[3]);

        SqlCamd.CommandText = SqlString;

        SqlCnn.Open();
        SqlCamd.ExecuteNonQuery();
        SqlCnn.Close();

    }
    catch (Exception ex)
    {
        MessageBox.Show("DataBase Exception" + ex.Message);
        SqlCnn.Close();
    }
}

public void Update_Customer(int CustomerID, string FirstName, string LastName, string Address, int Phone)
{
    try
    {
        Sqlcamd.Parameters.Clear();
        Sqlcamd.Connection = Sqlcnn;
        Sqlstring = "Update Customer Set FirstName = @FirstName, LastName = @Lastname, Address = @Address, Phone = @Phone where CustID = @CustomerID";

        SqlParameter[] para = new SqlParameter[5];
        para[0] = new SqlParameter("@CustomerID", CustomerID);
        para[1] = new SqlParameter("@FirstName", FirstName);
        para[2] = new SqlParameter("@LastName", LastName);
        para[3] = new SqlParameter("@Address", Address);
        para[4] = new SqlParameter("@Phone", Phone);

        Sqlcamd.Parameters.Add(para[0]);
        Sqlcamd.Parameters.Add(para[1]);
        Sqlcamd.Parameters.Add(para[2]);
        Sqlcamd.Parameters.Add(para[3]);
        Sqlcamd.Parameters.Add(para[4]);


        Sqlcamd.CommandText = Sqlstring;

       
        Sqlcnn.Open();

        
        Sqlcamd.ExecuteNonQuery();
    }
    catch (Exception ex)
    {
        
        MessageBox.Show("Database Exception" + ex.Message);
    }
    finally
    {
   
        if (Sqlcnn != null)
        {
            Sqlcnn.Close();
        }
    }
}
public void Delete_Customer(int CustomerID)
{
    try
    {
        Sqlcamd.Connection = Sqlcnn;
        Sqlstring = "Delete from Customer where CustID like @CustomerID";

        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@CustomerID", CustomerID);
        Sqlcamd.Parameters.Add(para[0]);

        Sqlcamd.CommandText = Sqlstring;
       

        Sqlcnn.Open();

       
        Sqlcamd.ExecuteNonQuery();

    }
    catch (Exception ex)
    {
        
        MessageBox.Show("Database Exception" + ex.Message);
    }
    finally
    {
       
        if (Sqlcnn != null)
        {
            Sqlcnn.Close();
        }
    }
}

public DataTable MoviesData()
{
    DataTable Dat = new DataTable();
    try
    {
        SqlStr.Connection = SqlCnn;
        SqlString = "Select * from Movies";
        SqlStr.CommandText = SqlString;

        SqlCnn.Open();
        SqlReader = Sqlcamd.ExecuteReader();
        if (SqlReader.HasRows)
        {
            Dat.Load(SqlReader);
        }
        SqlCnn.Close();
        return Dat;
    }
    catch (Exception ex)
    {
        MessageBox.Show("Database Exception" + ex.Message);
        SqlCnn.Close();
        return false;
    }
}

public void Add_Movies(string Rating_TextBox, string Title_TextBox, string Year_TextBox, string Rental_Cost_TextBox, string Copies_TextBox, string Plot_TextBox, string Genre_TextBox)
{
    SqlCamd.Parameter.Clear();
    try
    {
        SqlCamd.Parameter.Clear();
        SqlCamd.Connection = SqlCnn;
        SqlString = "Insert into Movies(Rating, Title, year, Rental_Cost,Copies,Plot, Genre) Values @Rating, @Title, @year, @Rental_Cost,@Copies,@Plot, @Genre)";

        SqlCamd.Parameters.Add(para[0]);
        SqlCamd.Parameters.Add(para[1]);
        SqlCamd.Parameters.Add(para[2]);
        SqlCamd.Parameters.Add(para[3]);
        SqlCamd.Parameters.Add(para[4]);
        SqlCamd.Parameters.Add(para[5]);
        SqlCamd.Parameters.Add(para[6]);
        

        SqlCamd.CommandText = SqlString;

        SqlCnn.Open();
        SqlCamd.ExecuteNonQuery();
        SqlCnn.Close();

    }
    catch (Exception ex)
    {
        MessageBox.Show("DataBase Exception" + ex.Message);
        SqlCnn.Close();
    }
}

public void Update_Movies(int MovieID, string Rating_TextBox, string Title_TextBox, string Year_TextBox, string Rental_Cost_TextBox, string Copies_TextBox, string Plot_TextBox, string Genre_TextBox)
{
    try
    {
        Sqlcamd.Parameters.Clear();
        Sqlcamd.Connection = Sqlcnn;
        Sqlstring = "Update Customer Set Rating = @Rating, Title = @Title, Year = @year, Rental_Cost = @Rental_Cost, Copies = @Copies, Plot = @Plot, genre =  @Genre where MovieID = @MovieID";

        SqlParameter[] para = new SqlParameter[8];
        para[0] = new SqlParameter("@MovieID", MovieID);
        para[1] = new SqlParameter("@Rating", Rating);
        para[2] = new SqlParameter("@Title", Title);
        para[3] = new SqlParameter("@Year", Year);
        para[4] = new SqlParameter("@Rental_Cost", Rental_Cost);
        para[5] = new SqlParameter("@Copies", Copies);
        para[6] = new SqlParameter("@Plot",Plot);
        para[7] = new SqlParameter("@Genre",Genre);
        

        Sqlcamd.Parameters.Add(para[0]);
        Sqlcamd.Parameters.Add(para[1]);
        Sqlcamd.Parameters.Add(para[2]);
        Sqlcamd.Parameters.Add(para[3]);
        Sqlcamd.Parameters.Add(para[4]);
        Sqlcamd.Parameters.Add(para[5]);
        Sqlcamd.Parameters.Add(para[6]);
        Sqlcamd.Parameters.Add(para[7]);


        Sqlcamd.CommandText = Sqlstring;


        Sqlcnn.Open();


        Sqlcamd.ExecuteNonQuery();
    }
    catch (Exception ex)
    {

        MessageBox.Show("Database Exception" + ex.Message);
    }
    finally
    {

        if (Sqlcnn != null)
        {
            Sqlcnn.Close();
        }
    }
}
public void Delete_Movie(int MovieID)
{
    try
    {
        Sqlcamd.Connection = Sqlcnn;
        Sqlstring = "Delete from Customer where MovieID like @MovieID";

        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@MovieID", MovieID);
        Sqlcamd.Parameters.Add(para[0]);

        Sqlcamd.CommandText = Sqlstring;


        Sqlcnn.Open();


        Sqlcamd.ExecuteNonQuery();

    }
    catch (Exception ex)
    {

        MessageBox.Show("Database Exception" + ex.Message);
    }
    finally
    {

        if (Sqlcnn != null)
        {
            Sqlcnn.Close();
        }
    }
}


public void Add_RentalMovies(int MovieID_TextBox, int CustID_TextBox, datetime DateRented_TextBox, datetime DateReturned_TextBox)
{
    SqlCamd.Parameter.Clear();
    try
    {
        SqlCamd.Parameter.Clear();
        SqlCamd.Connection = SqlCnn;
        SqlString = "Insert into RentalMovies(MovieID, CustID, DateRented, DateReturned) Values @MovieID, @CustID, @DateRented, @DateReturned)";

        SqlCamd.Parameters.Add(para[0]);
        SqlCamd.Parameters.Add(para[1]);
        SqlCamd.Parameters.Add(para[2]);
        SqlCamd.Parameters.Add(para[3]);

        SqlCamd.CommandText = SqlString;

        SqlCnn.Open();
        SqlCamd.ExecuteNonQuery();
        SqlCnn.Close();

    }
    catch (Exception ex)
    {
        MessageBox.Show("DataBase Exception" + ex.Message);
        SqlCnn.Close();
    }
}

public void Update_Movies(int RMD, int MovieID_TextBox, int CustID_TextBox, datetime DateRented_TextBox, datetime DateReturned_TextBox)
{
    try
    {
        Sqlcamd.Parameters.Clear();
        Sqlcamd.Connection = Sqlcnn;
        Sqlstring = "Update Customer Set MovieID= @MovieID, CustID = @CustID, DateRented = @DateRented, DateReturned = @DateReturned, where RMD = @RMD";

        SqlParameter[] para = new SqlParameter[5];
        para[0] = new SqlParameter("@RMD", RMD);
        para[1] = new SqlParameter("@MovieID", MovieID);
        para[2] = new SqlParameter(" @CustID", CustID);
        para[3] = new SqlParameter("@DateRented", DateRented);
        para[4] = new SqlParameter(" @DateReturned", DateReturned);


        Sqlcamd.Parameters.Add(para[0]);
        Sqlcamd.Parameters.Add(para[1]);
        Sqlcamd.Parameters.Add(para[2]);
        Sqlcamd.Parameters.Add(para[3]);
        Sqlcamd.Parameters.Add(para[4]);



        Sqlcamd.CommandText = Sqlstring;


        Sqlcnn.Open();


        Sqlcamd.ExecuteNonQuery();
    }
    catch (Exception ex)
    {

        MessageBox.Show("Database Exception" + ex.Message);
    }
    finally
    {

        if (Sqlcnn != null)
        {
            Sqlcnn.Close();
        }
    }
}
public void Delete_Movie(int RMD)
{
    try
    {
        Sqlcamd.Connection = Sqlcnn;
        Sqlstring = "Delete from Customer where MovieID like @RMD";

        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@MovieID", MovieID);
        Sqlcamd.Parameters.Add(para[0]);

        Sqlcamd.CommandText = Sqlstring;


        Sqlcnn.Open();


        Sqlcamd.ExecuteNonQuery();

    }
    catch (Exception ex)
    {

        MessageBox.Show("Database Exception" + ex.Message);
    }
    finally
    {

        if (Sqlcnn != null)
        {
            Sqlcnn.Close();
        }
    }
}











