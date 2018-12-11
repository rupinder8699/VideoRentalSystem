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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VideoRentalSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }
        //Login_Button_Click() is a login button and it will get login form gor the user.
        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            (new Login()).Show();
            this.Close();
        }

        //Registration_Button_Click() is a Register button and it will get registration form gor the new user.

        private void Registration_Button_Click(object sender, RoutedEventArgs e)
        {
            (new Registration()).Show();
            this.Close();
        }

        //Exit_Button_Click will help to close the whole program.
        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

