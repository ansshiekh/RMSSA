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
    /// Interaction logic for RecipeUserControl.xaml
    /// </summary>
    public partial class RecipeUserControl : UserControl
    {
        DataClassesDataContext dc = new DataClassesDataContext();
        private int recipeId = -1;
        public RecipeUserControl()
        {
            InitializeComponent();

        }

        private void recipe_edit_btn_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Testing Edit Button" + recipe_id.Text);

            recipeId = int.Parse(recipe_id.Text);
            dialog_host.IsOpen = true;
            
            
        }

        private void dialog_delete_btn_Click(object sender, RoutedEventArgs e)
        {
            
            var res = (from r in dc.Recipes
                       where r.Recipe_Id == this.recipeId
                       select r).FirstOrDefault();

            
            dc.Recipes.DeleteOnSubmit(res);
            dc.SubmitChanges();

            Window parentWindow = Window.GetWindow(this);
            new MainWindowM().Show();
            parentWindow.Close();

        }

        private void dialog_edit_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dialog_exit_btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
