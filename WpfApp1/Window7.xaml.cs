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
using System.Windows.Controls.Primitives;



namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window7.xaml
    /// </summary>
    public partial class Window7 : Window
    {
        public Window7()
        {
            InitializeComponent();  

            this.ListViewTimeable1.Items.Add(new MyItem { Id = 1, Name = "          549", Name1 = "          а", Name2 = "          32", Name3 = "      лекційна", Name4 = "         Фзк"});
            this.ListViewTimeable1.Items.Add(new MyItem { Id = 1, Name = "          540", Name1 = "", Name2 = "          120", Name3 = "      лекційна", Name4 = "         Фзк" });
            //this.ListViewTimeable1.FontSize = 40;


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

    public class MyItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Name3 { get; set; }
        public string Name4 { get; set; }
        public string Name5 { get; set; }

    }




}
