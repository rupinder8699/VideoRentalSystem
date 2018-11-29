﻿using System;
using System.Collections.Generic;
using System.Data;
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

namespace VideoRentalSystem
{
    /// <summary>
    /// Interaction logic for VideoRental.xaml
    /// </summary>
    public partial class VideoRental: Window
    {
        
        DatabaseClass Obj_data = new DatabaseClass();
        public int CustID;
        public int MovieID;
       
        public VideoRental()
        {
            this.InitializeComponent();
            base.WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }

       

        private void Rating_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

        private void Tab_Cust_Loaded(object sender, RoutedEventArgs e)
        {
            CustomerData.ItemsSource = Obj_data.CustData().DefaultView;
        }

        private void SelectCustDataRow(object sender, MouseButtonEventArgs e)
        {
            DataRowView view = (DataRowView)CustomerData.SelectedItems[0];
            CustID = Convert.ToInt32(view["CustID"]);
            FirstName_TxtBox.Text = Convert.ToString(view["FirstName"]);
            LastName_TxtBox.Text = Convert.ToString(view["LastName"]);
            Address_TxtBox.Text = Convert.ToString(view["Address"]);
            Phone_TxtBox.Text = Convert.ToString(view["Phone"]);
            CustomerData.ItemsSource = Obj_data.CustData().DefaultView;
        }

        private void Add_Cust_Btn_Click(object sender, RoutedEventArgs e)
    {

            if (((FirstName_TxtBox.Text != "") && ((LastName_TxtBox.Text != "") && (Address_TxtBox.Text != ""))) && Phone_TxtBox.Text != "")
            {
                Obj_data.Add_cust(FirstName_TxtBox.Text, LastName_TxtBox.Text, Address_TxtBox.Text,  Phone_TxtBox.Text);
                MessageBox.Show("Customer Added");
                CustomerData.ItemsSource = Obj_data.CustData().DefaultView;
                FirstName_TxtBox.Text = "";
                LastName_TxtBox.Text = "";
                Address_TxtBox.Text = "";
                Phone_TxtBox.Text = "";
            }

        }

    private void Update_Cust_Btn_Click(object sender, RoutedEventArgs e)
    {
            Obj_data.Update_cust(CustID, FirstName_TxtBox.Text, LastName_TxtBox.Text, Address_TxtBox.Text, Convert.ToInt32(Phone_TxtBox.Text));
            MessageBox.Show("Customer Updated");
            CustomerData.ItemsSource = Obj_data.CustData().DefaultView;
            FirstName_TxtBox.Text = "";
            LastName_TxtBox.Text = "";
            Address_TxtBox.Text = "";
            Phone_TxtBox.Text = "";
        }

    private void Delete_Cust_Btn_Click(object sender, RoutedEventArgs e)
    {

            if (MessageBox.Show("Are you sure you want to delete the User?", "User", MessageBoxButton.YesNo).ToString() == "Yes")
            {
                Obj_data.Delete_cust(CustID);
                MessageBox.Show("User Deleted");
                CustomerData.ItemsSource = Obj_data.CustData().DefaultView;
                FirstName_TxtBox.Text = "";
                LastName_TxtBox.Text = "";
                Address_TxtBox.Text = "";
                Phone_TxtBox.Text = "";
            }

        }



        private void Tab_Movi_Loaded(object sender, RoutedEventArgs e)
        {
            VideoData.ItemsSource = Obj_data.MoviData().DefaultView;
        }

        private void SelectMoviDataRow(object sender, MouseButtonEventArgs e)
        {
            DataRowView view = (DataRowView)VideoData.SelectedItems[0];
            MovieID = Convert.ToInt32(view["MovieID"]);
            Rating_TxtBox.Text = Convert.ToString(view["Rating"]);
            Title_TxtBox.Text = Convert.ToString(view["Title"]);
            Year_TxtBox.Text = Convert.ToString(view["Year"]);
            Rental_Cost_TxtBox.Text = Convert.ToString(view["Rental_Cost"]);
            Copies_TxtBox.Text = Convert.ToString(view["Copies"]);
            Plot_TxtBox.Text = Convert.ToString(view["Plot"]);
            Genre_TxtBox.Text = Convert.ToString(view["Genre"]);
            VideoData.ItemsSource = Obj_data.MoviData().DefaultView;
        }

        private void Add_Movie_Btn_Click(object sender, RoutedEventArgs e)
    {
            if (((Rating_TxtBox.Text != "") && ((Title_TxtBox.Text != "") && (Year_TxtBox.Text != ""))) && (((Rental_Cost_TxtBox.Text != "") && (( Copies_TxtBox.Text !="") && (( Plot_TxtBox.Text !="") && (Genre_TxtBox.Text !=""))))))
            {
                Obj_data.Add_movi(Rating_TxtBox.Text, Title_TxtBox.Text, Year_TxtBox.Text, Rental_Cost_TxtBox.Text, Copies_TxtBox.Text, Plot_TxtBox.Text, Genre_TxtBox.Text);
                MessageBox.Show("Movie Added");
                VideoData.ItemsSource = Obj_data.MoviData().DefaultView;
                Rating_TxtBox.Text = "";
                Title_TxtBox.Text = "";
                Year_TxtBox.Text = "";
                Rental_Cost_TxtBox.Text = "";
                Copies_TxtBox.Text = "";
                Plot_TxtBox.Text = "";
                Genre_TxtBox.Text = "";
            }
        }

    private void Update_Movie_Btn_Click(object sender, RoutedEventArgs e)
    {
            Obj_data.Update_movi(MovieID, Rating_TxtBox.Text, Title_TxtBox.Text, Year_TxtBox.Text, Convert.ToInt32(Rental_Cost_TxtBox.Text), Copies_TxtBox.Text, Plot_TxtBox.Text, Genre_TxtBox.Text);
            MessageBox.Show("Movie Updated");
            VideoData.ItemsSource = Obj_data.MoviData().DefaultView;
            Rating_TxtBox.Text = "";
            Title_TxtBox.Text = "";
            Year_TxtBox.Text = "";
            Rental_Cost_TxtBox.Text = "";
            Copies_TxtBox.Text = "";
            Plot_TxtBox.Text = "";
            Genre_TxtBox.Text = "";
        }

    private void Delete_Movie_Btn_Click(object sender, RoutedEventArgs e)
    {
            if (MessageBox.Show("Are you sure you want to delete the Movie?", "User", MessageBoxButton.YesNo).ToString() == "Yes")
            {
                Obj_data.Delete_movi(MovieID);
                MessageBox.Show("Movie Deleted");
                VideoData.ItemsSource = Obj_data.MoviData().DefaultView;
                Rating_TxtBox.Text = "";
                Title_TxtBox.Text = "";
                Year_TxtBox.Text = "";
                Rental_Cost_TxtBox.Text = "";
                Copies_TxtBox.Text = "";
                Plot_TxtBox.Text = "";
                Genre_TxtBox.Text = "";
            }

        }



        private void Add_Rent_Btn_Click(object sender, RoutedEventArgs e)
    {

    }

    private void Update_Rent_Btn_Click(object sender, RoutedEventArgs e)
    {

    }

    private void Delete_Rent_Btn_Click(object sender, RoutedEventArgs e)
    {

    }



    private void Back_Btn_Click(object sender, RoutedEventArgs e)
    {
            new MainWindow().Show();
            base.Close();
        }

    private void Exit_Btn_Click(object sender, RoutedEventArgs e)
    {
            base.Close();

        }


        private void Tab_Rent_Loaded(object sender, RoutedEventArgs e)
        {

        }

      
    }
}