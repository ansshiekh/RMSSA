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
        public MainWindow()
        {
            InitializeComponent();
            change_slider_image();
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

        
    }
}
