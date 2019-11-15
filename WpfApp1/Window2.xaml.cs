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
using System.Windows.Forms;
using System.Diagnostics;
using Schedule;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
     
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();

            ComboBoxKyrs.Items.Add(1);
            ComboBoxKyrs.Items.Add(2);
            ComboBoxKyrs.Items.Add(3);
            ComboBoxKyrs.Items.Add(4);

            ComboBoxTable.Items.Add(121);
            ComboBoxTable.Items.Add(122);

            ComboBoxKyrs_Copy.Items.Add("Aудиторії");
            ComboBoxKyrs_Copy.Items.Add("Групи");
            ComboBoxKyrs_Copy.Items.Add("Професори");
            ComboBoxKyrs_Copy.Items.Add("Додати курс");


            ComboBoxTable.Visibility = System.Windows.Visibility.Hidden;
            BlockSpeciality.Visibility = System.Windows.Visibility.Hidden;
            ComboBoxKyrs.Visibility = System.Windows.Visibility.Hidden;
            BoxKurs.Visibility = System.Windows.Visibility.Hidden;
            Option.Visibility = System.Windows.Visibility.Hidden;

           




        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new System.Windows.Forms.OpenFileDialog();
                                  
            fileDialog.Filter = "Excel Worksheets|*.xls;*.xlsx;";
            var result = fileDialog.ShowDialog();
            
            switch (result)
            {

                
                case System.Windows.Forms.DialogResult.OK:
                    var file = fileDialog.FileName;
                    TxtFile.Text = file;
                    TxtFile.ToolTip = file;
                    break;
                case System.Windows.Forms.DialogResult.Cancel:

                default:
                    TxtFile.Text = null;
                    TxtFile.ToolTip = null;
                    break;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            

            if (ComboBoxKyrs_Copy.Text != "")
            {

                if (ComboBoxKyrs_Copy.SelectedItem.ToString() == "Aудиторії")
                {

                    Window7 windows11 = new Window7();
                    windows11.ShowDialog();
                }
                if (ComboBoxKyrs_Copy.SelectedItem.ToString() == "Додати курс")
                {
                    Window11 windows11 = new Window11();
                    windows11.ShowDialog();
                }
                if (ComboBoxKyrs_Copy.SelectedItem.ToString() == "Групи")
                {
                    Window9 windows11 = new Window9();
                    windows11.ShowDialog();
                }
                if (ComboBoxKyrs_Copy.SelectedItem.ToString() == "Професори")
                {
                    Window10 windows11 = new Window10();
                    windows11.ShowDialog();
                }
            }

          


        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            LoadFiles DataBase1 = new LoadFiles();
            string nameCurriculum = "Sp_"+ ComboBoxTable.Text + "_course_"+ ComboBoxKyrs.Text;


            if (ComboBoxKyrs_Copy.Text != "")
            {
                

                if (ComboBoxKyrs_Copy.SelectedItem.ToString() == "Aудиторії")
                {
                    DataBase1.LoadExcelFileForAuditorium(TxtFile.Text);
                }

                if (ComboBoxKyrs_Copy.SelectedItem.ToString() == "Додати курс")
                {
                    DataBase1.LoadExcelFileForCurriculum(TxtFile.Text, nameCurriculum);
                }

                if (ComboBoxKyrs_Copy.SelectedItem.ToString() == "Групи")
                {
                    DataBase1.LoadExcelFileForGroup(TxtFile.Text);
                }

                if (ComboBoxKyrs_Copy.SelectedItem.ToString() == "Професори")
                {
                    DataBase1.LoadExcelFileForProfessors(TxtFile.Text);
                }
               
            }
        }

        private void ComboBoxKyrs_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            if (ComboBoxKyrs_Copy.SelectedItem.ToString() == "Aудиторії")
            {
                ComboBoxTable.Visibility = System.Windows.Visibility.Hidden;
                BlockSpeciality.Visibility = System.Windows.Visibility.Hidden;
                ComboBoxKyrs.Visibility = System.Windows.Visibility.Hidden;
                BoxKurs.Visibility = System.Windows.Visibility.Hidden;
                Option.Visibility = System.Windows.Visibility.Hidden;
            }

            if (ComboBoxKyrs_Copy.SelectedItem.ToString() == "Навчальний план")
            {
                ComboBoxTable.Visibility = System.Windows.Visibility.Visible;
                BlockSpeciality.Visibility = System.Windows.Visibility.Visible;
                ComboBoxKyrs.Visibility = System.Windows.Visibility.Visible;
                BoxKurs.Visibility = System.Windows.Visibility.Visible;
                Option.Visibility = System.Windows.Visibility.Hidden;
            }

            if (ComboBoxKyrs_Copy.SelectedItem.ToString() == "Групи")
            {
                ComboBoxTable.Visibility = System.Windows.Visibility.Hidden;
                BlockSpeciality.Visibility = System.Windows.Visibility.Hidden;
                ComboBoxKyrs.Visibility = System.Windows.Visibility.Hidden;
                BoxKurs.Visibility = System.Windows.Visibility.Hidden;
                Option.Visibility = System.Windows.Visibility.Hidden;
            }

            if (ComboBoxKyrs_Copy.SelectedItem.ToString() == "Професори")
            {
                ComboBoxTable.Visibility = System.Windows.Visibility.Hidden;
                BlockSpeciality.Visibility = System.Windows.Visibility.Hidden;
                ComboBoxKyrs.Visibility  = System.Windows.Visibility.Hidden;
                BoxKurs.Visibility = System.Windows.Visibility.Hidden;
                Option.Visibility = System.Windows.Visibility.Hidden;
            }
            if (ComboBoxKyrs_Copy.SelectedItem.ToString() == "Додати курс")
            {
                ComboBoxTable.Visibility = System.Windows.Visibility.Visible;
                BlockSpeciality.Visibility = System.Windows.Visibility.Visible;
                ComboBoxKyrs.Visibility = System.Windows.Visibility.Visible;
                BoxKurs.Visibility = System.Windows.Visibility.Visible;
                Option.Visibility = System.Windows.Visibility.Visible;
            }

        }

        private void ComboBoxKyrs_Copy_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {
           
        }

        private void ComboBoxKyrs_Copy_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
           
        }

        private void ComboBoxKyrs_Copy_DataContextChanged_1(object sender, DependencyPropertyChangedEventArgs e)
        {
          
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (ComboBoxKyrs.Text != "" && ComboBoxTable.Text != "")
            {
                Window12 asd1 = new Window12(Convert.ToInt32(ComboBoxKyrs.Text), Convert.ToInt32(ComboBoxTable.Text));
                asd1.ShowDialog();

            }
        }
    }
}
