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
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        Registration_class Obj_Register = new Registration_class();

        public Registration()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        //Submit_Button_Click() used register the new user,*after that (User Registered Successful) message will pop up for successfull registration of the new user.
        //this form will be closed after clicks ok button on pop up message.
        private void Submit_Button_Click(object sender, RoutedEventArgs e)
        {

            int age = Convert.ToInt32(Age_textbox.Text);
            Obj_Register.Regis(UserName_textbox.Text, Password_textbox.Text, FullName_textbox.Text, age);
            MessageBox.Show("User Registered Successful");
            MainWindow w = new MainWindow();
            w.ShowDialog();
            this.Close();

        }
    

    //Login_Button_Click() brings the login form if user already have an account. 
    private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            (new Login()).Show();
            this.Close();
        }
    }
}

