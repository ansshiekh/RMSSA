using RMSSA.Utils;
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

namespace RMSSA
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        DataClassesDataContext dc = new DataClassesDataContext();
        public LoginWindow()
        {
            InitializeComponent();
            loadUsers();
        }

        private void back_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void signup_btn_Click(object sender, RoutedEventArgs e)
        {
            SignUpWindow signUpWindow = new SignUpWindow();
            signUpWindow.Show();
            this.Close();
        }

        private void login_btn_Click(object sender, RoutedEventArgs e)
        {
            string username = username_box.Text;
            string password = password_box.Text;

            var res = from u in dc.Users
                      where u.User_Username == username && u.User_Password == password
                      select u;

            if(res.Count() > 0)
            {
                //Credentials Verified..
                //Setting Up a Session for login User..
                Session.USER_ID = res.First().User_Id;
                
                //Navigating Back to Main Window...
                MainWindow mw = new MainWindow();
                mw.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Credentials. Please try again");
            }
                      
        }




        //This method loads user from the database ... 
        //For testing purpose.. .will be removed later...

        private void loadUsers()
        {
            var res = from u in dc.Users
                      select u;

            UserDataGrid.ItemsSource = res;
        }
    }
}
