using Microsoft.Win32;
using RMSSA.Utils;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AddRecipeUserControl.xaml
    /// </summary>
    public partial class AddRecipeUserControl : UserControl
    {
        DataClassesDataContext dc = new DataClassesDataContext();

        private string profileImageUrl = null;
        private byte[] profileImageBytes = null;

        public AddRecipeUserControl()
        {
            InitializeComponent();
        }

        
        private void next_btn_Click(object sender, RoutedEventArgs e)
        {
            string name = recipe_name_box.Text;
            string subtitle = recipe_subtitle_box.Text;
            string description = description_box.Text;
            string preparation_time = recipe_preparation_box.Text;
            string difficulty = recipe_difficulty_box.Text;

            Regex regexNumber = new Regex(@"\d+");
            Match pMatch = regexNumber.Match(preparation_time);
            Match dMatch = regexNumber.Match(difficulty);



            if (pMatch.Success && dMatch.Success)
            {
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(subtitle) || string.IsNullOrWhiteSpace(description))
                {
                    dialog_host.IsOpen = true;
                    dialog_textblock.Text = "One or more fields are Empty!!";
                    dialog_icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.AlertCircle;
                }
                else
                {

                    //Getting Binary of Image from profileImageBytes
                    Binary binaryImage = new Binary(profileImageBytes);


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

                    dialog_host.IsOpen = true;
                    dialog_textblock.Text = "Record Added Successfully.";
                    dialog_icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Information;

                 
                    StackPanel stackPanel = (StackPanel)this.Parent;
                    stackPanel.Children.Clear();
                    AddExtrasUserControl userControl = new AddExtrasUserControl();
                    stackPanel.Children.Add(userControl);

                }

            }
            else
            {
                dialog_host.IsOpen = true;
                dialog_textblock.Text = "Enter valid Preparation Time and Difficuly. Only numbers allowed";
                dialog_icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.AlertCircle;


            }



        }

       
        private void image_select_btn_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.png; *.jpeg)|*.png;*.jpeg|All file (*.*)|*.*";
            dialog.InitialDirectory = @"D:\";
            if (dialog.ShowDialog() == true)
            {
                profileImageUrl = dialog.FileName;
                profileImageBytes = System.IO.File.ReadAllBytes(dialog.FileName);
            }


            if (profileImageUrl != null)
            {
                recipe_image.Source = new BitmapImage(new Uri(profileImageUrl));

            }
            else
            {
                recipe_image.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/default_profile.png"));
            }
        }
    }
}
