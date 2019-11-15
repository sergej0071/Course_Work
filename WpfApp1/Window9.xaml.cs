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
    /// Логика взаимодействия для Window9.xaml
    /// </summary>
    public partial class Window9 : Window
    {
        public Window9()
        {
            InitializeComponent();
            
            this.ListViewTimeable1.Items.Add(new MyItem { Id = 1, Name = "          3", Name1 = "          ПЗ", Name2 = "          122", Name3 = "          229", Name4 = "          21" });
            this.ListViewTimeable1.Items.Add(new MyItem { Id = 1, Name = "          4", Name1 = "          ІМ", Name2 = "          122", Name3 = "          219", Name4 = "          20"});
           
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
