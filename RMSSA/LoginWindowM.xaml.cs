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
    /// Interaction logic for LoginWindowM.xaml
    /// </summary>
    public partial class LoginWindowM : Window
    {
        DataClassesDataContext dc = new DataClassesDataContext();
        public LoginWindowM()
        {
            InitializeComponent();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void login_btn_Click(object sender, RoutedEventArgs e)
        {

            string username = username_box.Text;
            string password = password_box.Password.ToString();

            var res = from u in dc.Users
                      where u.User_Username == username && u.User_Password == password
                      select u;

            if (res.Count() > 0)
            {
                //Credentials Verified..
                //Setting Up a Session for login User..
                User user = res.First();
                Session.USER_ID = user.User_Id;
                Session.USER_NAME = user.User_Username;
                Session.USER_PROFILE_IMAGE_BYTES = user.User_Image.ToArray();
                //Navigating Back to Main Window...
                MainWindowM mw = new MainWindowM();
                mw.Show();
                this.Close();
            }
            else
            {
                dialog_host.IsOpen = true;
                dialog_textblock.Text = "Invalid Credentials. Please try again";
                dialog_icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.AlertCircle;

            }

        }

        private void signup_btn_Click(object sender, RoutedEventArgs e)
        {
            SignUpWindowM signUpWindow = new SignUpWindowM();
            signUpWindow.Show();
            this.Close();
        }
    }
}
