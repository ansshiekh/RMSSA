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
using Microsoft.Win32;
namespace RMSSA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int img_count=1;
        private String[] recipe ={"Item1","Item2"};
        public MainWindow()
        {
            InitializeComponent();
            change_slider_image();
                SetRecipes("abc");
            
        }


        private void search_txt_GotFocus(object sender, RoutedEventArgs e)
        {
           if(search_txt.Text=="Search...")
            {
                search_txt.Text = "";
            }
        }
        // method to be called in different thread 
        //Work in Progress
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
        //method to set the recipes on the main screen
        //WIP:::
        //Todo:
        //1. connect to database
        //2. add event handlers
        //3.... and much more :p

        private void SetRecipes(String title)
        {
            String[] temp = {"Cookies","Chicken","burger" };
                Recipe_User_Control recipe = new Recipe_User_Control(temp);
                Stack_Panel.Children.Add(recipe);
                String[] temp1 = { "sandwich","rice","bread" };
                recipe = new Recipe_User_Control(temp1);
                Stack_Panel.Children.Add(recipe);




        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();

        }
    }
}
