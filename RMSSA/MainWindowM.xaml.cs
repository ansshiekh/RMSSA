using RMSSA.Utils;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for MainWindowM.xaml
    /// </summary>
    public partial class MainWindowM : Window
    {
        public MainWindowM()
        {
            InitializeComponent();
            setupWindow();
        }


        private void setupWindow()
        {
            //Check  if user is logged in

            if (Session.USER_ID != -1)
            {
                //user is logged in
                userinfo_stack_panel.Visibility = Visibility.Visible;
                login_btn.Visibility = Visibility.Collapsed;

                userinfo_name.Text = Session.USER_NAME;

                showUserInfoProfileImage();


            }

            else
            {
                //Normal Viewer
                userinfo_stack_panel.Visibility = Visibility.Collapsed;
                login_btn.Visibility = Visibility.Visible;
                

            }
        }

        private void showUserInfoProfileImage()
        {
            if(Session.USER_PROFILE_IMAGE_BYTES != null)
            {
                string strfn = Convert.ToString(DateTime.Now.ToFileTime());
                FileStream fs1 = new FileStream(strfn, FileMode.CreateNew, FileAccess.Write);
                fs1.Write(Session.USER_PROFILE_IMAGE_BYTES, 0, Session.USER_PROFILE_IMAGE_BYTES.Length);
                fs1.Flush();
                fs1.Close();
                ImageSourceConverter imgs = new ImageSourceConverter();
                userinfo_profile_image.SetValue(Image.SourceProperty, imgs.ConvertFromString(strfn));

            }
          
        }




        private void button_open_menu_Click(object sender, RoutedEventArgs e)
        {
            button_open_menu.Visibility = Visibility.Collapsed;
            button_close_menu.Visibility = Visibility.Visible;
        }

        private void button_close_menu_Click(object sender, RoutedEventArgs e)
        {
            button_open_menu.Visibility = Visibility.Visible;
            button_close_menu.Visibility = Visibility.Collapsed;
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //DragMove();
        }

        private void login_btn_Click(object sender, RoutedEventArgs e)
        {
                LoginWindowM loginWindow = new LoginWindowM();
                loginWindow.Show();
                this.Close();
           
        }

        private void popup_logout_btn_Click(object sender, RoutedEventArgs e)
        {
            //User is already logged in and wants to logout...
            Session.USER_ID = -1;
            Session.USER_PROFILE_IMAGE_BYTES = null;
            Session.USER_NAME = null;
            new MainWindowM().Show();
            this.Close();
        }
    }
}
