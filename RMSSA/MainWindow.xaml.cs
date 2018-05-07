﻿using System;
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
using Microsoft.Win32;
using RMSSA.Utils;

namespace RMSSA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int img_count=1;
        public MainWindow()
        {
            InitializeComponent();
            setupWindow();
            change_slider_image();
        }


        /*
        * If User Logged In -----> Show User Related Information
        * Else Hide User specific Information
        * */
        private void setupWindow()
        {
            //Check  if user is logged in
            if(Session.USER_ID != -1)
            {
                //user is logged in
                panel_btn.Visibility = Visibility.Visible;

                //login User has tag 1
                login_btn.Content = "Log Out";
                login_btn.Tag = "1";
            }

            else
            {
                //Normal Viewer
                panel_btn.Visibility = Visibility.Collapsed;

                //When user logs out set content to login and tag to 0
                login_btn.Content = "Login";
                login_btn.Tag = "0";
            }
        }




        private void search_txt_GotFocus(object sender, RoutedEventArgs e)
        {
           if(search_txt.Text=="Search...")
            {
                search_txt.Text = "";
            }
        }
        private void change_slider_image()
        {
            if (img_count > 4)
            {
                img_count = 1;
            }
            //string path = "C:\\Users\\Muhammad Anas\\Documents\\University_Stuff\\Visual Programming\\project\\RMSSA\\RMSSA\\images\\"+img_count+".jpg";
            string path = "pack://application:,,,/Resources/Images/" + img_count + ".jpg";
            img_count++;
            BitmapImage dp = new BitmapImage(new Uri(path));

            slider_image.Source = dp;
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btnClicked = (Button)sender;
            if(btnClicked.Tag == "0")
            {
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
                this.Close();
            }
            else
            {
                //User is already logged in and wants to logout...
                Session.USER_ID = -1;
                new MainWindow().Show();
                this.Close();
            }
           

        }

        private void panel_btn_Click(object sender, RoutedEventArgs e)
        {
            UserPanelWindow userPanelWindow = new UserPanelWindow();
            userPanelWindow.Show();
            this.Close();
        }
    }
}
