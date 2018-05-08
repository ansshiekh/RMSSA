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
        public Recipe_User_Control()
        {
            InitializeComponent();
        }
        public Recipe_User_Control(String[] Title)
        {
            //UserControl1 contains the template of the recipe to be shown as single item
            InitializeComponent();
            UserControl1 uc = new UserControl1();
            uc.recipe_title.Content = Title[0];
            string path = "pack://application:,,,/Resources/Images/1.jpg";

            BitmapImage dp = new BitmapImage(new Uri(path));

            uc.image_container.Source = dp;
            UserControl1 uc1 = new UserControl1();
            uc1.recipe_title.Content = Title[1];
            path = "pack://application:,,,/Resources/Images/2.jpg";

            dp = new BitmapImage(new Uri(path));

            uc1.image_container.Source = dp;
            UserControl1 uc2 = new UserControl1();
            uc2.recipe_title.Content = Title[2];
            path = "pack://application:,,,/Resources/Images/3.jpg";
            dp = new BitmapImage(new Uri(path));

            uc2.image_container.Source = dp;
            Left.Children.Add(uc);
            Center.Children.Add(uc1);
            Right.Children.Add(uc2);
        }
    }
}
