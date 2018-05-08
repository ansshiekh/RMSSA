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

namespace RMSSA
{
    /// <summary>
    /// Interaction logic for Recipe_User_Control.xaml
    /// </summary>
    public partial class Recipe_User_Control : UserControl
    {
        int placeholer = 0;
        public Recipe_User_Control()
        {
            InitializeComponent();
        }
       

        public void setView(RecipeClass resClass, UserClass userObject)
        {
            if (placeholer > 2)
            {
                placeholer = 0;
            }
            if (placeholer == 0)
            {
                UserControl1 uc = new UserControl1();
                uc.recipe_title.Content = resClass.RecipeName;
                uc.recipe_description.Content = resClass.RecipeDescription;
                uc.stars.Content = resClass.RecipeRating;
                uc.username.Content = userObject.UserUsername;
                string path = "pack://application:,,,/Resources/Images/1.jpg";

                BitmapImage dp = new BitmapImage(new Uri(path));

                uc.image_container.Source = dp;
                Left.Children.Add(uc);
            }
            else if (placeholer == 1)
            {
                UserControl1 uc = new UserControl1();
                uc.recipe_title.Content = resClass.RecipeName;
                uc.recipe_description.Content = resClass.RecipeDescription;
                uc.stars.Content = resClass.RecipeRating;
                string path = "pack://application:,,,/Resources/Images/1.jpg";

                BitmapImage dp = new BitmapImage(new Uri(path));
                uc.username.Content = userObject.UserUsername;

                uc.image_container.Source = dp;
                Center.Children.Add(uc);
            }
            else if (placeholer == 2)
            {
                UserControl1 uc = new UserControl1();
                uc.recipe_title.Content = resClass.RecipeName;
                uc.recipe_description.Content = resClass.RecipeDescription;
                uc.stars.Content = resClass.RecipeRating;
                string path = "pack://application:,,,/Resources/Images/1.jpg";

                BitmapImage dp = new BitmapImage(new Uri(path));
                uc.username.Content = userObject.UserUsername;

                uc.image_container.Source = dp;
                Right.Children.Add(uc);
            }
            placeholer++;
        }
           
    } 
    }
