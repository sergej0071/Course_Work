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
    /// Логика взаимодействия для Window11.xaml
    /// </summary>
    public partial class Window11 : Window
    {
        public Window11()
        {
            InitializeComponent();
        

        this.ListViewTimeable1.Items.Add(new MyItem { Id = 1, Name = "          Іноземна мова", Name1 = "          ІМ", Name2 = "          0.5", Name3 = "          1", Name4 = "          лабораторна" });
            this.ListViewTimeable1.Items.Add(new MyItem { Id = 1, Name = "          Історія", Name1 = "          Флсф", Name2 = "          1", Name3 = "          2", Name4 = "          лабораторна" });
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
