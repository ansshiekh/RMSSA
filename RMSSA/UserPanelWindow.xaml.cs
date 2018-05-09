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
    /// Interaction logic for UserPanelWindow.xaml
    /// </summary>
    public partial class UserPanelWindow : Window
    {
        DataClassesDataContext dc = new DataClassesDataContext();
        public UserPanelWindow()
        {
            InitializeComponent();
        }

        private void cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            if (!Session.RECIPE_ADDED)
            {
                MainWindowM mw = new MainWindowM();
                mw.Show();
                this.Close();
            }
            else
            {
                //If user has already added recipe and cancels then we should have to remove it
                //Because its an incomplete record...
                var res = (from r in dc.Recipes
                          where r.Recipe_Id == Session.RECIPE_ID
                          select r).FirstOrDefault();

                dc.Recipes.DeleteOnSubmit(res);
                dc.SubmitChanges();

                Session.RECIPE_ADDED = false;
                MessageBox.Show("Record Deleted" + Session.RECIPE_ID);

            }
           
        }

        private void next_btn_Click(object sender, RoutedEventArgs e)
        {
            string name = name_box.Text;
            string subtitle = subtitle_box.Text;
            string description = description_box.Text;
            string preparation_time = preparation_time_box.Text;
            string difficulty = difficult_box.Text;

            Recipe recipe = new Recipe()
            {
                Recipe_Name = name,
                Recipe_Subtitle = subtitle,
                Recipe_Description = description,
                Recipe_PreperationTime = preparation_time,
                Recipe_Difficulty = difficulty,
                Recipe_Rating = -1,
                Recipe_User_Id = Session.USER_ID

            };


            dc.Recipes.InsertOnSubmit(recipe);
            dc.SubmitChanges();


            //Getting the ID of recently added Recipe ...
            var res = from r in dc.Recipes
                      orderby r.Recipe_Id descending
                      select r;

            Session.RECIPE_ID = res.First().Recipe_Id;
            Session.RECIPE_ADDED = true;

            IngredientsWindow ingredientsWindow = new IngredientsWindow();
            ingredientsWindow.Show();
            this.Close();
        }
    }
}
