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
using System.Linq;

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
            setupMainGrid();
            //Check  if user is logged in

            if (Session.USER_ID != -1)
            {
                //user is logged in
                //userinfo_stack_panel.Visibility = Visibility.Visible;
                //login_btn.Visibility = Visibility.Collapsed;

                userinfo_name.Text = Session.USER_NAME;

                showUserInfoProfileImage();


            }

            //else
            //{
            //    //Normal Viewer
            //    userinfo_stack_panel.Visibility = Visibility.Collapsed;
            //    login_btn.Visibility = Visibility.Visible;


            //}


        }

        private void showUserInfoProfileImage()
        {
            if (Session.USER_PROFILE_IMAGE_BYTES != null && !Session.USER_PROFILE_IMAGE_BYTES.Equals("")) 
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
            new LoginWindowM().Show();
            this.Close();
        }

      

        private void exit_drawer_item_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //private void test_display_btn_Click(object sender, RoutedEventArgs e)
        //{
        //    TestingDisplayWindow tw = new TestingDisplayWindow();
        //    tw.Show();
        //    this.Close();
        //}

       


        private void setupMainGrid()
        {

            string selectedMode = Session.SELECTED_MODE;
            switch (selectedMode)
            {
                case "add":
                    AddScreen();
                    break;

                case "view":
                    //Syntax of HomeScreen(isHomeScreen)
                    HomeScreen(false);
                    break;

                case "edit":
                    // Syntax of HomeScreen(isHomeScreen)
                    HomeScreen(false);
                    break;

                default:
                    HomeScreen(true);
                    break;
            }
      
        }

      

        private void AddScreen()
        {
            AddRecipeUserControl addRecipeUserControl = new AddRecipeUserControl();
            view_recipe_stackpanel.Children.Add(addRecipeUserControl);
        }

        private void HomeScreen(bool isHome)
        {
            DataClassesDataContext dc = new DataClassesDataContext();
            Recipe recipe = new Recipe();
            User user = new User();

            //Select All Recipes..
            var recipes = from r in dc.Recipes
                          select r;

            if (!isHome) { 
                int currentUserId = Session.USER_ID;
                recipes = from r in dc.Recipes
                          where r.User.User_Id == currentUserId
                          select r;
            }
          

            if (recipes.Count() > 0)
            {
                int count = 0;
                RecipeSingleRow recipe_row = new RecipeSingleRow();

                foreach (Recipe r in recipes)
                {
                    
                   
                    //Adding RecipeUserControl
                    RecipeUserControl recipeUserControl = new RecipeUserControl();

                    //CHeck for EDITING or VIEWING Screen
                    if(Session.SELECTED_MODE == "edit")
                    {
                        recipeUserControl.recipe_edit_btn.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        recipeUserControl.recipe_edit_btn.Visibility = Visibility.Hidden;

                    }

                    recipeUserControl.recipe_id.Text = r.Recipe_Id.ToString();
                    recipeUserControl.recipe_name.Text = r.Recipe_Name;
                    recipeUserControl.recipe_subtitle.Text = r.Recipe_Subtitle;
                    recipeUserControl.recipe_description.Text = r.Recipe_Description;
                    recipeUserControl.recipe_preparation_time.Text = r.Recipe_PreperationTime;
                    recipeUserControl.recipe_difficulty.Text = r.Recipe_Difficulty;
                    recipeUserControl.recipe_username.Text = r.User.User_Username;

                    recipe_row.listbox.Items.Add(recipeUserControl);

                    if(count == 2)
                    {
                        view_recipe_stackpanel.Children.Add(recipe_row);
                        recipe_row = new RecipeSingleRow();
                        count = -1;
                    }

                    count++;

                }
                view_recipe_stackpanel.Children.Add(recipe_row);
            }
         
        }

        private void home_drawer_item_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Session.SELECTED_MODE = null;
            view_recipe_stackpanel.Children.Clear();
            setupMainGrid();
        }

        private void add_drawer_item_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Session.SELECTED_MODE = "add";
            view_recipe_stackpanel.Children.Clear();
            setupMainGrid();
        }

        private void view_drawer_item_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Session.SELECTED_MODE = "view";
            view_recipe_stackpanel.Children.Clear();
            setupMainGrid();
        }

        private void edit_drawer_item_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Session.SELECTED_MODE = "edit";
            view_recipe_stackpanel.Children.Clear();
            setupMainGrid();

        }
    }
}
