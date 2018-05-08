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
            SetRecipes("abc");
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

        private void test_display_btn_Click(object sender, RoutedEventArgs e)
        {
            TestingDisplayWindow tw = new TestingDisplayWindow();
            tw.Show();
            this.Close();
        }
        private void SetRecipes(String title)
        {
            
            DataClassesDataContext dc = new DataClassesDataContext();
            RecipeClass resClass = new RecipeClass();
            UserClass userObject = new UserClass();
            var resObj = from recipee in dc.Recipes
                         select recipee;


            if (resObj.Count() > 0)
            {
                foreach (var rec in resObj)
                {
                    resClass.RecipeId = rec.Recipe_Id;
                    resClass.RecipeName = rec.Recipe_Name;
                    resClass.RecipeSubtitle = rec.Recipe_Subtitle;
                    resClass.RecipeRating = Convert.ToDouble(rec.Recipe_Rating);
                    resClass.RecipeDescription = rec.Recipe_Description;
                    resClass.RecipeTime = rec.Recipe_PreperationTime;
                    resClass.RecipeDifficulty = rec.Recipe_Difficulty;
                    resClass.RecipeUserId = Convert.ToInt32(rec.Recipe_User_Id);
                    var usrObj = (from user in dc.Users
                                  where user.User_Id == resClass.RecipeUserId
                                  select user).SingleOrDefault();

                    userObject.UserUsername = usrObj.User_Username;
                    userObject.UserPassword = usrObj.User_Password;
                    userObject.UserCountry = usrObj.User_Country;


                    setView(resClass, userObject);
                    
                }
                Stack_Panel.Children.Add(recipe);
            }



        }
        int number = 0;
        Recipe_User_Control recipe = new Recipe_User_Control();
        private void setView(RecipeClass resClass, UserClass userObject)
        {
            recipe.setView(resClass, userObject);
            if(number==2)
            {
                Stack_Panel.Children.Add(recipe);
                recipe = new Recipe_User_Control();
                number = 0;
            }
            number++;
        }
    }
}
