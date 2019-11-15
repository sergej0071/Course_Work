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
using Schedule;


namespace WpfApp1
{


    public partial class Window1 : Window
    {
        private Button[] buttons;
        // 4 потока  
        List<Professor> prof = new List<Professor>();
        List<Auditorium> audit = new List<Auditorium>();
        LoadFiles DataBase = new LoadFiles();
        List<Flows> flows = new List<Flows>();
        public Window1()
        {
            InitializeComponent();

            bool Check_spec = false;
            LoadFiles DataBase = new LoadFiles();

            Auditorium.SetAllAuditorium(out audit);

            Professor.SetAllProfessors(out prof);

            List<int> my_mass = new List<int>();

            
            // заполнение
            foreach (String str12 in DataBase.getNamesOfCourses())
            {
                my_mass = Filedivision(str12);
                flows.Add(new Flows(my_mass[0], my_mass[1]));
            }
                                

             //// interface

             ExportFile ExFile = new ExportFile();
            
            foreach (Flows flows1 in flows)
            {

                foreach (string nameSpeciality in ComboForGroups2.Items)
                {
                    if (flows1.Speciality.ToString() == nameSpeciality)
                    {
                        Check_spec = true;
                    }

                }
                if(Check_spec != true)
                ComboForGroups2.Items.Add(Convert.ToString(flows1.Speciality));

                Check_spec = false;

                foreach (int nameSpeciality1 in ComboForGroups1.Items)
                {
                    if (flows1.Course.ToString() == nameSpeciality1.ToString())
                    {
                        Check_spec = true;
                    }

                }
                if (Check_spec != true)
                ComboForGroups1.Items.Add(flows1.Course);

                Check_spec = false;

                foreach (Group group12 in flows1.Groups)
                {                   
                    ComboForGroups3.Items.Add(group12.NumberName);             /*ExFile.outputCheckForDepartmentForComboBox(group12.Departmant) + " " + group12.NumberName);*/
                }
            }

            


            Stackpanel.Visibility = System.Windows.Visibility.Hidden;
            Chiselnik.Visibility = System.Windows.Visibility.Hidden;
            Sign.Visibility = System.Windows.Visibility.Hidden;



            //foreach (int a in flows.Course.get())
            //    ComboForGroups1.Items.Add(a);


            //??? функция возращает все групы
            //foreach(string nameGroup in ??)
            //ComboForGroups3.Items.Add(nameGroup);
            ////

            Console.OutputEncoding = Encoding.Unicode; // для отображения украинских букв в консоле            



            //создать разписание

            //измененение во время загрузки файлов

        }


        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            MainAlgorithm.MakeSchedule(flows, audit, prof);
            Stackpanel.Visibility = System.Windows.Visibility.Hidden;
            Scrollviewer.Visibility = System.Windows.Visibility.Visible;
            Chiselnik.Visibility = System.Windows.Visibility.Hidden;
            Sign.Visibility = System.Windows.Visibility.Hidden;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 Form1 = new Window2();   //List < Flows > flows
            Form1.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window3 Form1 = new Window3();
            Form1.ShowDialog();
        }

        private void Button_Click_2()
        {

        }

        private Button[] CreateButtons(int quantity, int startNumber)
        {
            Button[] buttons = new Button[quantity];
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i] = new Button();
                buttons[i].Width = 40d;
                buttons[i].Margin = new Thickness(1d);
                buttons[i].Content = (i + startNumber).ToString();
                buttons[i].Style = this.FindResource("MyStyleButton") as Style;
                buttons[i].Click += ButtonOnClick;
                buttons[i].TabIndex = i;
            }
            return buttons;
        }

        private void ButtonOnClick(object sender, RoutedEventArgs e)
        {
            Scrollviewer.Visibility = System.Windows.Visibility.Hidden;
            Stackpanel.Visibility = System.Windows.Visibility.Visible;
            Chiselnik.Visibility = System.Windows.Visibility.Visible;
            Sign.Visibility = System.Windows.Visibility.Visible;

            //var bton = (Button)sender;
            //MessageBox.Show("asdasd"+ bton.TabIndex + bton.Content);

        }

        // кнопки
        private void AddToWrapPanel(Button[] buttons)
        {
            for (int i = 0; i < buttons.Length; i++)
                wrapPanel.Children.Add(buttons[i]);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            buttons = CreateButtons(1, wrapPanel.Children.Count + 1);
            AddToWrapPanel(buttons);


            //this.ListViewTimeable.Items.Add(new MyItem { Id = 1, Name = "Cергей", Name1 = "лох", Name2 = "лох", Name3 = "лох", Name4 = "лох", Name5 = "лох" });
            //this.ListViewTimeable.FontSize = 40;
            MainAlgorithm.MakeSchedule(flows, audit, prof);                       
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Window4 Form2 = new Window4();
            Form2.ShowDialog();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            //Window5 Form2 = new Window5();
            //Form2.ShowDialog();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Window6 Form2 = new Window6();
            Form2.ShowDialog();
        }

        private void DataGridRow_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void ListViewTimeable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        //
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

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            foreach (Flows flow in flows)
            {
                foreach (Group group in flow.Groups)
                {
                    if (group.NumberName == Convert.ToInt32(ComboForGroups3.Text)) /// function for lit
                    {
                        // все дни
                        foreach (Day day in group.Week.Days)
                        {
                            
                            // все пары в одном дне
                            foreach (KeyValuePair<int,Lesson> el in day.ScheduleTableNumenator)
                            {
                                if (el.Value.Hours != 0 && el.Value.auditorium.NumOfAuditorium != -1)
                                {
                                    String str = "";
                                    str = el.Value.SubjectName + el.Value.Hours + el.Value.professor.FIO + el.Value.auditorium.NumOfAuditorium;
                                    this.ListViewTimeable.Items.Add(new MyItem { Id = 1, Name = el.Value.SubjectName, Name1 = "", Name2 = el.Value.professor.FIO, Name3 = el.Value.auditorium.NumOfAuditorium.ToString(), Name4 = "", Name5 = "" });
                                }
                                else
                                {

                                    this.ListViewTimeable.Items.Add(new MyItem { Id = 1, Name = "", Name1 = "", Name2 = "", Name3 = "", Name4 = "", Name5 = "" });
                                }

                            }

                            this.ListViewTimeable.Items.Add(new MyItem { Id = 1, Name = "====", Name1 = "====", Name2 = "====", Name3 = "====", Name4 = "" , Name5 = "" });
                        }
                    }


                }

            }

            //flows[0].Groups[0].Week.Days[0].ScheduleTableDenominator[1].Hours;

        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {

        }

        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        public List<int> Filedivision(string spec_course_name)
        {
            List<int> FlowName1 = new List<int>();



            string SpecialityStr = "";
            string CourseStr = "";

            string curric_name = spec_course_name; // для функции FillData
            spec_course_name = spec_course_name.Substring(3); // spec_course_name = ddd _course_ddd

            int i = 0;
            while (spec_course_name[i].ToString() != "_")
            {
                SpecialityStr += spec_course_name[i];
                i++;
            }

            i = spec_course_name.Length - 1;

            while (spec_course_name[i].ToString() != "_")
            {
                CourseStr += spec_course_name[i];
                i--;
            }

            // конвертируем в числовой формат
                       
            FlowName1.Add(Convert.ToInt32(SpecialityStr));
            FlowName1.Add(Convert.ToInt32(CourseStr));
              

            return FlowName1;
        }
              


    }
    
}