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
using Schedule;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();

            ComboBoxCourse.Items.Add(1);
            ComboBoxCourse.Items.Add(2);
            ComboBoxCourse.Items.Add(3);
            ComboBoxCourse.Items.Add(4);
                        
            ComboBoxSpeciality.Items.Add(121);
            ComboBoxSpeciality.Items.Add(122);
                      
            ComboBoxTable.Items.Add("Aудиторії");
            ComboBoxTable.Items.Add("Групи");
            ComboBoxTable.Items.Add("Професори");
            ComboBoxTable.Items.Add("Додати курс");
            
            ComboBoxCourse.Visibility = System.Windows.Visibility.Hidden;
            ComboBoxSpeciality.Visibility = System.Windows.Visibility.Hidden;
            ComboBoxGroup.Visibility = System.Windows.Visibility.Hidden;
            ComboBoxCourse.Visibility = System.Windows.Visibility.Hidden;
            LabelSpaciality.Visibility = System.Windows.Visibility.Hidden;
            LabelCourse.Visibility = System.Windows.Visibility.Hidden;
            LableGroup.Visibility = System.Windows.Visibility.Hidden;
        }

        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var fileDialog = new System.Windows.Forms.SaveFileDialog();

            var result = fileDialog.ShowDialog();

            switch (result)
            {


                case System.Windows.Forms.DialogResult.OK:
                    var file = fileDialog.FileName;

                  

                    TxtFile.Text = file + ".xlsx";
                    TxtFile.ToolTip = file + ".xlsx";
                    break;
                case System.Windows.Forms.DialogResult.Cancel:

                default:
                    TxtFile.Text = null;
                    TxtFile.ToolTip = null;
                    break;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ExportFile DataFileExport = new ExportFile();


            if (ComboBoxTable.Text != "")
            {

                if (ComboBoxTable.SelectedItem.ToString() == "Aудиторії")
                {
                    DataFileExport.ExportExcelFile(TxtFile.Text,"Auditorium");
                }

                if (ComboBoxTable.SelectedItem.ToString() == "Додати курс")
                {
                    //DataFileExport.ExportExcelFile();
                }

                if (ComboBoxTable.SelectedItem.ToString() == "Групи")
                {
                    DataFileExport.ExportExcelFile(TxtFile.Text,"Groups");
                }

                if (ComboBoxTable.SelectedItem.ToString() == "Професори")
                {
                    DataFileExport.ExportExcelFile(TxtFile.Text,"Professors");
                }

            }


        }

        private void ComboBoxTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxTable.SelectedItem.ToString() == "Aудиторії")
            {
               
                ComboBoxCourse.Visibility = System.Windows.Visibility.Hidden;
                ComboBoxSpeciality.Visibility = System.Windows.Visibility.Hidden;
                ComboBoxGroup.Visibility = System.Windows.Visibility.Hidden;
                ComboBoxCourse.Visibility = System.Windows.Visibility.Hidden;
                LabelSpaciality.Visibility = System.Windows.Visibility.Hidden;
                LabelCourse.Visibility = System.Windows.Visibility.Hidden;
                LableGroup.Visibility = System.Windows.Visibility.Hidden;
            }             
            if (ComboBoxTable.SelectedItem.ToString() == "Групи")
            {
                ComboBoxCourse.Visibility = System.Windows.Visibility.Hidden;
                ComboBoxSpeciality.Visibility = System.Windows.Visibility.Hidden;
                ComboBoxGroup.Visibility = System.Windows.Visibility.Hidden;
                ComboBoxCourse.Visibility = System.Windows.Visibility.Hidden;
                LabelSpaciality.Visibility = System.Windows.Visibility.Hidden;
                LabelCourse.Visibility = System.Windows.Visibility.Hidden;
                LableGroup.Visibility = System.Windows.Visibility.Hidden;
            }
           

            if (ComboBoxTable.SelectedItem.ToString() == "Професори")
            {
                ComboBoxCourse.Visibility = System.Windows.Visibility.Hidden;
                ComboBoxSpeciality.Visibility = System.Windows.Visibility.Hidden;
                ComboBoxGroup.Visibility = System.Windows.Visibility.Hidden;
                ComboBoxCourse.Visibility = System.Windows.Visibility.Hidden;
                LabelSpaciality.Visibility = System.Windows.Visibility.Hidden;
                LabelCourse.Visibility = System.Windows.Visibility.Hidden;
                LableGroup.Visibility = System.Windows.Visibility.Hidden;
            }
            if (ComboBoxTable.SelectedItem.ToString() == "Додати курс")
            {
                ComboBoxCourse.Visibility = System.Windows.Visibility.Visible;
                ComboBoxSpeciality.Visibility = System.Windows.Visibility.Visible;
                ComboBoxGroup.Visibility = System.Windows.Visibility.Visible;
                ComboBoxCourse.Visibility = System.Windows.Visibility.Visible;
                LabelSpaciality.Visibility = System.Windows.Visibility.Visible;
                LabelCourse.Visibility = System.Windows.Visibility.Visible;
                LableGroup.Visibility = System.Windows.Visibility.Visible;
            }
        }
    }
}
