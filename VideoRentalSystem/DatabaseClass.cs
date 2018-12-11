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


                //first of the all select the record from the Rented Movie is he already has a movie on rent or not if he has a movie on rent then he can't be able to delete the record from the table
                String Strr = "";
                Strr = "select Count(*) from RentalMovies where CustIDFK= @CustID and DateReturned ='1900-01-01' ";
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@CustID", CustID) };
                Cmdd.Parameters.Add(parameterArray[0]);

                Cmdd.CommandText = Strr;
                Conn.Open();
                int count = Convert.ToInt32(Cmdd.ExecuteScalar());
                if (count == 0)
                {
                    Strr = "Delete from Customer where CustID like @CustID";
                    Cmdd.CommandText = Strr;
                    Cmdd.ExecuteNonQuery();
                    MessageBox.Show("User Deleted");
                }
                else
                {
                    //display the message if he has a movie on rent 
                    MessageBox.Show("Customer has rented the movie. First take the movie back than you can delete the customer");
                }
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

        public void Add_movi(string Rating_TextBox, string Title_TextBox, string Year_TextBox, string Copies_TextBox, string Plot_TextBox, string Genre_TextBox)
        {
            int Rental_Cost = 0;
            
            try
            {
                int MovieYear = Convert.ToInt32(Year_TextBox);
                int CurrentYear = DateTime.Now.Year;
                if (MovieYear>(CurrentYear-5))
                {
                    Rental_Cost = 5;
                }
                else
                {
                    Rental_Cost = 2;
                }
               
                this.Cmdd.Parameters.Clear();
                this.Cmdd.Connection = this.Conn;
                this.Strr = "Insert into Movies(Rating,Title,Year,Rental_Cost,Copies,Plot,Genre) Values(@Rating, @Title, @Year, @Rental_Cost, @Copies, @Plot, @Genre)";
                Cmdd.Parameters.AddWithValue("@Rental_Cost", Rental_Cost); 
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@Rating", Rating_TextBox), new SqlParameter("@Title", Title_TextBox), new SqlParameter("@Year", Year_TextBox), new SqlParameter("@Copies", Copies_TextBox), new SqlParameter("@Plot", Plot_TextBox), new SqlParameter("@Genre", Genre_TextBox) };
                this.Cmdd.Parameters.Add(parameterArray[0]);
                this.Cmdd.Parameters.Add(parameterArray[1]);
                this.Cmdd.Parameters.Add(parameterArray[2]);
                this.Cmdd.Parameters.Add(parameterArray[3]);
                this.Cmdd.Parameters.Add(parameterArray[4]);
                this.Cmdd.Parameters.Add(parameterArray[5]);
                
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

        public void Update_movi(int MovieID, string Rating, string Title, string Year, string Copies, string Plot, string Genre)
        {
            int Rental_Cost = 0;

            try
            {
                int MovieYear = Convert.ToInt32(Year);
                int CurrentYear = DateTime.Now.Year;
                if (MovieYear > (CurrentYear - 5))
                {
                    Rental_Cost = 5;
                }
                else
                {
                    Rental_Cost = 2;
                }
                Cmdd.Parameters.Clear();
                Cmdd.Connection = Conn;
                Strr = "Update Movies Set Rating= @Rating,Title = @Title, Year = @Year,Rental_Cost = @Rental_Cost,Copies= @Copies,Plot = @Plot, Genre = @Genre where MovieID = @MovieID";
               
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@MovieID", MovieID), new SqlParameter("@Rating", Rating), new SqlParameter("@Title", Title), new SqlParameter("@Year", Year), new SqlParameter("@Rental_Cost", Rental_Cost), new SqlParameter("@Copies", Copies), new SqlParameter("@Plot", Plot), new SqlParameter("@Genre", Genre) };
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


                //first of the all select the record from the Rented Movie is he already has a movie on rent or not if he has a movie on rent then he can't be able to delete the record from the table
                String Strr = "";
                Strr = "select Count(*) from RentalMovies where MovieIDFK= @MovieID and DateReturned ='1900-01-01' ";
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@MovieID", MovieID) };
                Cmdd.Parameters.Add(parameterArray[0]);

                Cmdd.CommandText = Strr;
                Conn.Open();
                int count = Convert.ToInt32(Cmdd.ExecuteScalar());
                if (count == 0)
                {
                    Strr = "Delete from Movies where MovieID like @MovieID";
                     Cmdd.CommandText = Strr;
                    Cmdd.ExecuteNonQuery();
                    MessageBox.Show("Movie Deleted");
                }
                else
                {
                    //display the message if he has a movie on rent 
                    MessageBox.Show("Customer has rented the movie. First take the movie back than you can delete the movie");
                }

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

        public DataTable RentData()
        {
            DataTable table = new DataTable();
            try
            {
                this.Cmdd.Connection = this.Conn;
                this.Strr = "Select * from RentalMovies";
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
                MessageBox.Show("Database Exception " + exception.Message);
                this.Conn.Close();
                return null;
            }
        }

        public void Top_Movie()
        {
            int Top_MovieID = 0, Max_number = 0, Total_Movies = 0;
            string Strr = "";
            try
            {
                Cmdd.Parameters.Clear();
                Cmdd.Connection = Conn;
                string Strr1 = "Select IDENT_CURRENT('Movies')";
                
                Cmdd.CommandText = Strr1;
                Conn.Open();
                Total_Movies = Convert.ToInt32(Cmdd.ExecuteScalar());

                for(int i = 1; i<= Total_Movies; i++)
                {
                    
                    Strr = "select Count(*) from RentalMovies where MovieIDFK= '" + i + "'";
                   

                    Cmdd.CommandText = Strr;
                    int count = Convert.ToInt32(Cmdd.ExecuteScalar());
                      if (count > Max_number)
                    {
                        Max_number = count;
                        Top_MovieID = i;
                    }
                }
                this.Strr = "Select Title from Movies where MovieID ='" + Top_MovieID + "'";
                this.Cmdd.CommandText = this.Strr;
                String Title = Convert.ToString(Cmdd.ExecuteScalar());
                MessageBox.Show(Title + " (Movie ID "+ Top_MovieID + " ) is maximum rented movie with " + Max_number + " times");
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

        public void Best_Buyer()
        {
            int Best_BuyerID = 0, Max_number = 0, Total_Customer = 0;
            string Strr = "";
            try
            {
                Cmdd.Parameters.Clear();
                Cmdd.Connection = Conn;
                string Strr1 = "Select IDENT_CURRENT('Customer')";

                Cmdd.CommandText = Strr1;
                Conn.Open();
                Total_Customer = Convert.ToInt32(Cmdd.ExecuteScalar());

                for (int i = 1; i <= Total_Customer; i++)
                {

                    Strr = "select Count(*) from RentalMovies where CustIDFK= '" + i + "'";


                    Cmdd.CommandText = Strr;
                    int count = Convert.ToInt32(Cmdd.ExecuteScalar());
                    if (count > Max_number)
                    {
                        Max_number = count;
                        Best_BuyerID = i;
                    }
                }
                this.Strr = "Select FirstName from Customer where CustID ='" + Best_BuyerID + "'";
                this.Cmdd.CommandText = this.Strr;
                String FirstName = Convert.ToString(Cmdd.ExecuteScalar());
                MessageBox.Show(FirstName + " (Cust ID " + Best_BuyerID + " ) is maximum movie buyer with " + Max_number + " times");
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

        public void Issue_Movi(int MovieID, int CustID, DateTime DateRent, int Copies)
        {
            try
            {
                this.Cmdd.Parameters.Clear();
                this.Cmdd.Connection = this.Conn;
                this.Strr = "Insert into RentalMovies(MovieIDFK, CustIDFK, DateRented, DateReturned) Values(@MovieIDFK, @CustIDFK, @DateRented,'1900-01-01')";
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@MovieIDFK", MovieID), new SqlParameter("@CustIDFK", CustID), new SqlParameter("@DateRented",DateRent)};
                this.Cmdd.Parameters.Add(parameterArray[0]);
                this.Cmdd.Parameters.Add(parameterArray[1]);
                this.Cmdd.Parameters.Add(parameterArray[2]);
                
                this.Cmdd.CommandText = this.Strr;

                this.Conn.Open();
                this.Cmdd.ExecuteNonQuery();
                this.Conn.Close();

                Strr = "Update Movies set Copies = Copies-1 where MovieID = @MovieIDFK";
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



    public void Return_Movi(int RMID, int MovieID, DateTime DateRent, DateTime DateReturned, int Copies)
    {
            try
            {
                Cmdd.Parameters.Clear();
                Cmdd.Connection = Conn;
                int Total_Rent = 0, Rental_Cost = 0;
                double days = (DateReturned - DateRent).TotalDays;
               
                string Strr1 = "Select Rental_Cost from Movies where MovieID = @MovieIDFK";
                Cmdd.Parameters.AddWithValue("@MovieIDFK", MovieID);

                Cmdd.CommandText = Strr1;
                Conn.Open();
                Rental_Cost = Convert.ToInt32(Cmdd.ExecuteScalar());

                if (Convert.ToInt32(days) == 0)
                {
                    Total_Rent = Rental_Cost;
                }
                else
                {
                    Total_Rent = Rental_Cost*Convert.ToInt32(days);
                }
                
                
                Strr = "Update RentalMovies Set DateReturned= @DateReurned , Total_Charge = @Total_Charge,Number_Of_Days = @Number_Of_Days,Rent_Per_Day =@Rent_Per_Day where RMID = @RMID";
                Cmdd.Parameters.AddWithValue("@Total_Charge", Total_Rent);
                Cmdd.Parameters.AddWithValue("@Number_Of_Days", days);
                Cmdd.Parameters.AddWithValue("@Rent_Per_Day", Rental_Cost);
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@DateReurned", DateReturned),new SqlParameter("@RMID", RMID)};
                Cmdd.Parameters.Add(parameterArray[0]);
                Cmdd.Parameters.Add(parameterArray[1]);
                             
                Cmdd.CommandText = Strr;
                
                Cmdd.ExecuteNonQuery();
           

                Strr = "Update Movies set Copies = Copies+1 where MovieID = @MovieIDFK";
                this.Cmdd.CommandText = this.Strr;
               
                this.Cmdd.ExecuteNonQuery();
               

                MessageBox.Show("Total Rent is " + Total_Rent);
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


    }
}
