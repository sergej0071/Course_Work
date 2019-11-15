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
    /// Логика взаимодействия для Window5.xaml
    /// </summary>
    public partial class Window12 : Window
    {
        bool[] Check_Arr = new bool[5];
        int CheckButton;
        int Course, Sp;


        public Window12(int Course,int Sp)
        {
            InitializeComponent();

            ListView12.Items.Add("            5");
            ListView12.Items.Add("            4");
            ListView12.Items.Add("            3");
            ListView12.Items.Add("            2");
            ListView12.Items.Add("            1");
            this.Course = Course;
            this.Sp = Sp;

            for (int i = 0; i < 5; i++)
            Check_Arr[i] = false;
            CheckButton = -1;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {       

            ExpectedSchedule expectedSchedule = new ExpectedSchedule();
            Dictionary<int, int> important = new Dictionary<int, int>(5);
            important.Add(ChangeTextBlock(TextBlock1.Text),Convert.ToInt32(slider1.Value));
            important.Add(ChangeTextBlock(TextBlock2.Text), Convert.ToInt32(slider2.Value));
            important.Add(ChangeTextBlock(TextBlock3.Text), Convert.ToInt32(slider3.Value));
            important.Add(ChangeTextBlock(TextBlock4.Text), Convert.ToInt32(slider4.Value));
            important.Add(ChangeTextBlock(TextBlock5.Text), Convert.ToInt32(slider5.Value));
            expectedSchedule.Set(Course, Sp, important);

        }

        private int ChangeTextBlock(string name)
        {
            if (name == "Пнд")
            {
                return 1;
            }
            if (name == "Вт")
            {
                return 2;
            }
            if (name == "Ср")
            {
                return 3;
            }
            if (name == "Чт")
            {
                return 4;
            }
            if (name == "Пнт")
            {
                return 5;
            }

            return 0;
            
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {


            if (slider1.Value == 1)
            {
                this.Resources["MyFillBrush"] = new SolidColorBrush(Color.FromRgb(73, 255, 106));
            }

            if (slider1.Value == 2)
            {
                this.Resources["MyFillBrush"] = new SolidColorBrush(Color.FromRgb(12, 253, 23));
            }

            if (slider1.Value == 3)
            {
                this.Resources["MyFillBrush"] = new SolidColorBrush(Color.FromRgb(207, 243, 41));

            }
            if (slider1.Value == 4)
            {
                this.Resources["MyFillBrush"] = new SolidColorBrush(Color.FromRgb(236, 116, 60));

            }
            if (slider1.Value == 5)
            {
                this.Resources["MyFillBrush"] = new SolidColorBrush(Color.FromRgb(230, 62, 62));
            }
        }

        private void Slider2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (slider2.Value == 1)
            {
                this.Resources["MyFillBrush1"] = new SolidColorBrush(Color.FromRgb(73, 255, 106));
            }

            if (slider2.Value == 2)
            {
                this.Resources["MyFillBrush1"] = new SolidColorBrush(Color.FromRgb(12, 253, 23));
            }

            if (slider2.Value == 3)
            {
                this.Resources["MyFillBrush1"] = new SolidColorBrush(Color.FromRgb(207, 243, 41));

            }
            if (slider2.Value == 4)
            {
                this.Resources["MyFillBrush1"] = new SolidColorBrush(Color.FromRgb(236, 116, 60));

            }
            if (slider2.Value == 5)
            {
                this.Resources["MyFillBrush1"] = new SolidColorBrush(Color.FromRgb(230, 62, 62));
            }
        }

        private void Slider3_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (slider3.Value == 1)
            {
                this.Resources["MyFillBrush2"] = new SolidColorBrush(Color.FromRgb(73, 255, 106));
            }

            if (slider3.Value == 2)
            {
                this.Resources["MyFillBrush2"] = new SolidColorBrush(Color.FromRgb(12, 253, 23));
            }

            if (slider3.Value == 3)
            {
                this.Resources["MyFillBrush2"] = new SolidColorBrush(Color.FromRgb(207, 243, 41));

            }
            if (slider3.Value == 4)
            {
                this.Resources["MyFillBrush2"] = new SolidColorBrush(Color.FromRgb(236, 116, 60));

            }
            if (slider3.Value == 5)
            {
                this.Resources["MyFillBrush2"] = new SolidColorBrush(Color.FromRgb(230, 62, 62));
            }
        }

        private void Slider4_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (slider4.Value == 1)
            {
                this.Resources["MyFillBrush3"] = new SolidColorBrush(Color.FromRgb(73, 255, 106));
            }

            if (slider4.Value == 2)
            {
                this.Resources["MyFillBrush3"] = new SolidColorBrush(Color.FromRgb(12, 253, 23));
            }

            if (slider4.Value == 3)
            {
                this.Resources["MyFillBrush3"] = new SolidColorBrush(Color.FromRgb(207, 243, 41));

            }
            if (slider4.Value == 4)
            {
                this.Resources["MyFillBrush3"] = new SolidColorBrush(Color.FromRgb(236, 116, 60));

            }
            if (slider4.Value == 5)
            {
                this.Resources["MyFillBrush3"] = new SolidColorBrush(Color.FromRgb(230, 62, 62));
            }
        }

        private void Slider5_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (slider5.Value == 1)
            {
                this.Resources["MyFillBrush4"] = new SolidColorBrush(Color.FromRgb(73, 255, 106));
            }

            if (slider5.Value == 2)
            {
                this.Resources["MyFillBrush4"] = new SolidColorBrush(Color.FromRgb(12, 253, 23));
            }

            if (slider5.Value == 3)
            {
                this.Resources["MyFillBrush4"] = new SolidColorBrush(Color.FromRgb(207, 243, 41));

            }
            if (slider5.Value == 4)
            {
                this.Resources["MyFillBrush4"] = new SolidColorBrush(Color.FromRgb(236, 116, 60));

            }
            if (slider5.Value == 5)
            {
                this.Resources["MyFillBrush4"] = new SolidColorBrush(Color.FromRgb(230, 62, 62));
            }
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    GradientStopCollection gsc = new GradientStopCollection();
        //    gsc.Add(new GradientStop()
        //    {
        //        Color = Colors.Red,
        //        Offset = 0.0
        //    });
        //    gsc.Add(new GradientStop()
        //    {
        //        Color = Colors.Black,
        //        Offset = 0.5
        //    });
        //    button1.Background = new LinearGradientBrush(gsc, 0)
        //    {
        //        StartPoint = new Point(0.5, 0),
        //        EndPoint = new Point(0.5, 1)
        //    };

        //}



        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            SolidColorBrush a = new SolidColorBrush(Color.FromArgb(230, 62, 62, 1));
            string StrText;

            if (Check_Arr[0] == false)
            {
                button2.Background = new SolidColorBrush(Color.FromRgb(230, 62, 62));
                button3.Background = new SolidColorBrush(Color.FromRgb(230, 62, 62));
                button4.Background = new SolidColorBrush(Color.FromRgb(230, 62, 62));
                button5.Background = new SolidColorBrush(Color.FromRgb(230, 62, 62));

                Check_Arr[1] = true;
                Check_Arr[2] = true;
                Check_Arr[3] = true;
                Check_Arr[4] = true;

                CheckButton = 1;
            }


            if (Check_Arr[0] == true)
            {
                button1.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
                button3.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
                button4.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
                button5.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
                button2.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));

                Check_Arr[0] = false;
                Check_Arr[1] = false;
                Check_Arr[2] = false;
                Check_Arr[3] = false;
                Check_Arr[4] = false;

                if (CheckButton == 2)
                {
                    StrText = TextBlock1.Text;
                    TextBlock1.Text = TextBlock2.Text;
                    TextBlock2.Text = StrText;
                }
                if (CheckButton == 3)
                {
                    StrText = TextBlock1.Text;
                    TextBlock1.Text = TextBlock3.Text;
                    TextBlock3.Text = StrText;
                }
                if (CheckButton == 4)
                {
                    StrText = TextBlock1.Text;
                    TextBlock1.Text = TextBlock4.Text;
                    TextBlock4.Text = StrText;
                }
                if (CheckButton == 5)
                {
                    StrText = TextBlock1.Text;
                    TextBlock1.Text = TextBlock5.Text;
                    TextBlock5.Text = StrText;
                }

            }

        }



        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            SolidColorBrush a = new SolidColorBrush(Color.FromArgb(230, 62, 62, 1));
            string StrText;

            if (Check_Arr[1] == false)
            {
                button1.Background = new SolidColorBrush(Color.FromArgb(230, 62, 62, 1));
                button3.Background = new SolidColorBrush(Color.FromArgb(230, 62, 62, 1));
                button4.Background = new SolidColorBrush(Color.FromArgb(230, 62, 62, 1));
                button5.Background = new SolidColorBrush(Color.FromArgb(230, 62, 62, 1));

                Check_Arr[0] = true;
                Check_Arr[2] = true;
                Check_Arr[3] = true;
                Check_Arr[4] = true;

                CheckButton = 2;
            }


            if (Check_Arr[1] == true)
            {
                button1.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 1));
                button3.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 1));
                button4.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 1));
                button5.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 1));
                button2.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 1));

                Check_Arr[0] = false;
                Check_Arr[1] = false;
                Check_Arr[2] = false;
                Check_Arr[3] = false;
                Check_Arr[4] = false;

                if (CheckButton == 1)
                {
                    StrText = TextBlock1.Text;
                    TextBlock1.Text = TextBlock2.Text;
                    TextBlock2.Text = StrText;
                }
                if (CheckButton == 3)
                {
                    StrText = TextBlock2.Text;
                    TextBlock2.Text = TextBlock3.Text;
                    TextBlock3.Text = StrText;
                }
                if (CheckButton == 4)
                {
                    StrText = TextBlock2.Text;
                    TextBlock2.Text = TextBlock4.Text;
                    TextBlock4.Text = StrText;
                }
                if (CheckButton == 5)
                {
                    StrText = TextBlock2.Text;
                    TextBlock2.Text = TextBlock5.Text;
                    TextBlock5.Text = StrText;
                }

            }
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            SolidColorBrush a = new SolidColorBrush(Color.FromArgb(230, 62, 62, 1));
            string StrText;

            if (Check_Arr[2] == false)
            {
                button1.Background = new SolidColorBrush(Color.FromArgb(230, 62, 62, 1));
                button2.Background = new SolidColorBrush(Color.FromArgb(230, 62, 62, 1));
                button4.Background = new SolidColorBrush(Color.FromArgb(230, 62, 62, 1));
                button5.Background = new SolidColorBrush(Color.FromArgb(230, 62, 62, 1));

                Check_Arr[0] = true;
                Check_Arr[1] = true;
                Check_Arr[3] = true;
                Check_Arr[4] = true;

                CheckButton = 3;
            }


            if (Check_Arr[2] == true)
            {
                button1.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 1));
                button3.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 1));
                button4.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 1));
                button5.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 1));
                button2.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 1));

                Check_Arr[0] = false;
                Check_Arr[1] = false;
                Check_Arr[2] = false;
                Check_Arr[3] = false;
                Check_Arr[4] = false;

                if (CheckButton == 1)
                {
                    StrText = TextBlock1.Text;
                    TextBlock1.Text = TextBlock3.Text;
                    TextBlock3.Text = StrText;
                }
                if (CheckButton == 2)
                {
                    StrText = TextBlock2.Text;
                    TextBlock2.Text = TextBlock3.Text;
                    TextBlock3.Text = StrText;
                }
                if (CheckButton == 4)
                {
                    StrText = TextBlock3.Text;
                    TextBlock3.Text = TextBlock4.Text;
                    TextBlock4.Text = StrText;
                }
                if (CheckButton == 5)
                {
                    StrText = TextBlock3.Text;
                    TextBlock3.Text = TextBlock5.Text;
                    TextBlock5.Text = StrText;
                }

            }
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            SolidColorBrush a = new SolidColorBrush(Color.FromArgb(230, 62, 62, 1));
            string StrText;

            if (Check_Arr[3] == false)
            {
                button1.Background = new SolidColorBrush(Color.FromArgb(230, 62, 62, 1));
                button3.Background = new SolidColorBrush(Color.FromArgb(230, 62, 62, 1));
                button2.Background = new SolidColorBrush(Color.FromArgb(230, 62, 62, 1));
                button5.Background = new SolidColorBrush(Color.FromArgb(230, 62, 62, 1));

                Check_Arr[0] = true;
                Check_Arr[2] = true;
                Check_Arr[1] = true;
                Check_Arr[4] = true;

                CheckButton = 4;
            }


            if (Check_Arr[3] == true)
            {
                button1.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 1));
                button3.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 1));
                button4.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 1));
                button5.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 1));
                button2.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 1));

                Check_Arr[0] = false;
                Check_Arr[1] = false;
                Check_Arr[2] = false;
                Check_Arr[3] = false;
                Check_Arr[4] = false;

                if (CheckButton == 1)
                {
                    StrText = TextBlock1.Text;
                    TextBlock1.Text = TextBlock4.Text;
                    TextBlock4.Text = StrText;
                }
                if (CheckButton == 2)
                {
                    StrText = TextBlock2.Text;
                    TextBlock2.Text = TextBlock4.Text;
                    TextBlock4.Text = StrText;
                }
                if (CheckButton == 3)
                {
                    StrText = TextBlock3.Text;
                    TextBlock3.Text = TextBlock4.Text;
                    TextBlock4.Text = StrText;
                }
                if (CheckButton == 5)
                {
                    StrText = TextBlock5.Text;
                    TextBlock5.Text = TextBlock4.Text;
                    TextBlock4.Text = StrText;
                }

            }
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            SolidColorBrush a = new SolidColorBrush(Color.FromArgb(230, 62, 62, 1));
            string StrText;

            if (Check_Arr[4] == false)
            {
                button1.Background = new SolidColorBrush(Color.FromArgb(230, 62, 62, 1));
                button3.Background = new SolidColorBrush(Color.FromArgb(230, 62, 62, 1));
                button4.Background = new SolidColorBrush(Color.FromArgb(230, 62, 62, 1));
                button5.Background = new SolidColorBrush(Color.FromArgb(230, 62, 62, 1));
                button2.Background = new SolidColorBrush(Color.FromArgb(230, 62, 62, 1));

                Check_Arr[0] = true;
                Check_Arr[2] = true;
                Check_Arr[3] = true;
                Check_Arr[1] = true;

                CheckButton = 5;
            }


            if (Check_Arr[4] == true)
            {
                button1.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 1));
                button3.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 1));
                button4.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 1));
                button5.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 1));
                button2.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 1));

                Check_Arr[0] = false;
                Check_Arr[1] = false;
                Check_Arr[2] = false;
                Check_Arr[3] = false;
                Check_Arr[4] = false;

                if (CheckButton == 1)
                {
                    StrText = TextBlock1.Text;
                    TextBlock1.Text = TextBlock5.Text;
                    TextBlock5.Text = StrText;
                }
                if (CheckButton == 2)
                {
                    StrText = TextBlock2.Text;
                    TextBlock2.Text = TextBlock5.Text;
                    TextBlock5.Text = StrText;
                }
                if (CheckButton == 3)
                {
                    StrText = TextBlock3.Text;
                    TextBlock3.Text = TextBlock5.Text;
                    TextBlock5.Text = StrText;
                }
                if (CheckButton == 4)
                {
                    StrText = TextBlock4.Text;
                    TextBlock4.Text = TextBlock5.Text;
                    TextBlock5.Text = StrText;
                }

            }
        }
    }
}
