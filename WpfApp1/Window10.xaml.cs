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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window10.xaml
    /// </summary>
    public partial class Window10 : Window
    {
        public Window10()
        {
            InitializeComponent();

            this.ListViewTimeable1.Items.Add(new MyItem { Id = 1, Name = "          ПЗ", Name1 = " Онуфрієнко Володимир Михайлович", Name2 = "          професор", Name3 = "          20"});
            this.ListViewTimeable1.Items.Add(new MyItem { Id = 1, Name = "          ІМ", Name1 = " Фасоляк Антон Володимирович", Name2 = "          доцент", Name3 = "          34"});
            //77	8	Онуфрієнко Володимир Михайлович	5	
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
