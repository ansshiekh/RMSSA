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
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        DataClassesDataContext dc = new DataClassesDataContext();
        public SignUpWindow()
        {
            InitializeComponent();
        }

        private void cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void done_btn_Click(object sender, RoutedEventArgs e)
        {
            string username = username_box.Text;
            string password = password_box.Text;
            string confirm_password = confirm_password_box.Text;
            string country = country_box.Text;
            string city = city_box.Text;

            if(string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(country) || string.IsNullOrWhiteSpace(city))
            {
                MessageBox.Show("One or more fields are Empty!!");
            }

            else
            {
             
                if (!password.Equals(confirm_password))
                {
                    MessageBox.Show("Password Mismatch!!!");
                }
                else
                {

                    //Check if the username already exists or not..
                    var res = from u in dc.Users
                              where u.User_Username == username
                              select u;
                    if(res.Count() > 0)
                    {
                        MessageBox.Show("username already exists!! Choose other username");
                    }
                    else
                    {

                        //Everything is ok lets add the data to the database...

                        User user = new User()
                        {
                            User_Username = username,
                            User_Password = password,
                            User_Country = country,
                            User_City = city
                        };

                        dc.Users.InsertOnSubmit(user);
                        dc.SubmitChanges();

                        MessageBox.Show("Record Added Successfully");

                        LoginWindow loginWindow = new LoginWindow();
                        loginWindow.Show();
                        this.Close();

                    }

                }

            }
           
        }
    }
}
