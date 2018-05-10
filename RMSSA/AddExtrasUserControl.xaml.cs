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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RMSSA
{
    /// <summary>
    /// Interaction logic for AddExtrasUserControl.xaml
    /// </summary>
    public partial class AddExtrasUserControl : UserControl
    {
        DataClassesDataContext dc = new DataClassesDataContext();

        private int added_recipe_id;

        public AddExtrasUserControl()
        {
            InitializeComponent();
            this.added_recipe_id = Session.RECIPE_ID;
        }

        private void ingredient_add_btn_Click(object sender, RoutedEventArgs e)
        {
            string name = ingredient_name_box.Text;
            string description = ingredient_description_box.Text;
            string quantity = ingredient_quantity_box.Text;

            Ingredient ingredient = new Ingredient()
            {
                Ingredient_Name = name,
                Ingredient_Description = description,
                Ingredient_Quantity = quantity,
                Ingredient_Recipe_Id = added_recipe_id
            };

            dc.Ingredients.InsertOnSubmit(ingredient);
            //dc.SubmitChanges();

            MessageBox.Show("Ingredient Added");
        }

        private void instruction_add_btn_Click(object sender, RoutedEventArgs e)
        {
            string number = instruction_number_box.Text;
            string description = instruction_description_box.Text;


            Instruction instruction = new Instruction()
            {
                Instruction_Number = int.Parse(number),
                Instruction_Description = description,
                Instruction_Recipe_Id = added_recipe_id
            };


            dc.Instructions.InsertOnSubmit(instruction);
            //dc.SubmitChanges();

            MessageBox.Show("Instruction Added");

        }

        private void tags_add_btn_Click(object sender, RoutedEventArgs e)
        {
            string name = tags_name_box.Text;

            Tag tag = new Tag()
            {
                Tag_Name = name,
                Tag_Recipe_Id = added_recipe_id
            };


            dc.Tags.InsertOnSubmit(tag);
            //dc.SubmitChanges();

            MessageBox.Show("Tag Added");
        }

        private void utensils_add_btn_Click(object sender, RoutedEventArgs e)
        {
            string name = utensils_name_box.Text;

            Utensil utensil = new Utensil()
            {
                Utensil_Name = name,
                Utensil_Recipe_Id = added_recipe_id
            };


            dc.Utensils.InsertOnSubmit(utensil);
            //dc.SubmitChanges();

            MessageBox.Show("Utensil Added");
        }

        private void done_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Recipe Updated Successfully...");

            dc.SubmitChanges();


            StackPanel stackPanel = (StackPanel)this.Parent;
            stackPanel.Children.Clear();        }

        private void cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            dc.Dispose();

            StackPanel stackPanel = (StackPanel)this.Parent;
            stackPanel.Children.Clear();
        }
    }
}
