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
    /// Interaction logic for TestingDisplayWindow.xaml
    /// </summary>
    public partial class TestingDisplayWindow : Window
    {
        DataClassesDataContext dc = new DataClassesDataContext();

        public TestingDisplayWindow()
        {
            InitializeComponent();

            loadData();
        }



        private void loadData()
        {
            var recipes = from r in dc.Recipes
                          select r;

            recipes_data_grid.ItemsSource = recipes;


            var ingredients = from i in dc.Ingredients
                              select i;

            ingredients_data_grid.ItemsSource = ingredients;


            var instructions = from intr in dc.Instructions
                               select intr;

            instructions_data_grid.ItemsSource = instructions;

            var tags = from t in dc.Tags
                       select t;

            tags_data_grid.ItemsSource = tags;


            var utensils = from u in dc.Utensils
                           select u;

            utensils_data_grid.ItemsSource = utensils;

            var users = from u in dc.Users
                        select u;
            user_data_grid.ItemsSource = users;
        }

        private void back_btn_Click(object sender, RoutedEventArgs e)
        {

            MainWindowM mw = new MainWindowM();
            //MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
