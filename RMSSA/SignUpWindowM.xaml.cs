using System;
using System.Collections.Generic;
using System.Data.Linq;
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
using Microsoft.Win32;


namespace RMSSA
{
    /// <summary>
    /// Interaction logic for SignUpWindowM.xaml
    /// </summary>
    public partial class SignUpWindowM : Window
    {

        private string profileImageUrl = null;
        private byte[] profileImageBytes = null;
        DataClassesDataContext dc = new DataClassesDataContext();
        public SignUpWindowM()
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

        private void done_btn_Click(object sender, RoutedEventArgs e)
        {
            string username = username_box.Text;
            string password = password_box.Password.ToString();
            string confirm_password = confirm_password_box.Password.ToString();
            string country = country_box.Text;
            string city = city_box.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(country) || string.IsNullOrWhiteSpace(city))
            {

                dialog_host.IsOpen = true;
                dialog_textblock.Text = "One or more fields are Empty!!";
                dialog_icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.AlertCircle;

            }

            else
            {

                if (!password.Equals(confirm_password))
                {
                    dialog_host.IsOpen = true;
                    dialog_textblock.Text = "Password Mismatch. Confirm the password";
                    dialog_icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.AlertCircle;
                }
                else
                {

                    //Check if the username already exists or not..
                    var res = from u in dc.Users
                              where u.User_Username == username
                              select u;
                    if (res.Count() > 0)
                    {
                        dialog_host.IsOpen = true;
                        dialog_textblock.Text = "Username already exists.";
                        dialog_icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.AlertCircle;

                    }
                    else
                    {

                        //Getting Binary of Image from profileImageBytes
                        Binary binaryImage = new Binary(profileImageBytes);

                        //Everything is ok lets add the data to the database...

                        User user = new User()
                        {
                            User_Username = username,
                            User_Password = password,
                            User_Country = country,
                            User_City = city,
                            User_Image = binaryImage

                        };

                        dc.Users.InsertOnSubmit(user);
                        dc.SubmitChanges();

                        dialog_host.IsOpen = true;
                        dialog_textblock.Text = "Record Added Successfully.";
                        dialog_icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Information;

                        

                    }

                }

            }
        }

        private void cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            LoginWindowM loginWindow = new LoginWindowM();
            loginWindow.Show();
            this.Close();
        }

        private void dialog_ok_btn_Click(object sender, RoutedEventArgs e)
        {
            LoginWindowM loginWindow = new LoginWindowM();
            loginWindow.Show();
            this.Close();
        }

        private void profile_image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.png; *.jpeg)|*.png;*.jpeg|All file (*.*)|*.*";
            dialog.InitialDirectory = @"D:\";
            if(dialog.ShowDialog() == true)
            {
                profileImageUrl = dialog.FileName;
                profileImageBytes = System.IO.File.ReadAllBytes(dialog.FileName);
            }


            if(profileImageUrl != null)
            {
                profile_image.ImageSource = new BitmapImage(new Uri(profileImageUrl));
               
            }
            else
            {
                profile_image.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/default_profile.png"));
            }
        }

       
    }
}
