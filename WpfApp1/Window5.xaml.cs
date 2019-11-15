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
    /// Логика взаимодействия для Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {
        bool[]  Check_Arr= new bool[5];
        int CheckButton;

        public Window5()
        {

            InitializeComponent();

            ListView12.Items.Add("            5");
            ListView12.Items.Add("            4");
            ListView12.Items.Add("            3");
            ListView12.Items.Add("            2");
            ListView12.Items.Add("            1");
            for (int i = 0; i < 5; i++)
                Check_Arr[i] = false;
            CheckButton = -1;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
           
                   
            if (slider1.Value == 0)
            {                       
               this.Resources["MyFillBrush"] = new SolidColorBrush(Color.FromRgb(197, 197, 197));
            }
           
            if (slider1.Value == 1)
            {
                this.Resources["MyFillBrush"] = new SolidColorBrush(Color.FromRgb(197, 197, 197));
            }

            if (slider1.Value == 2)
            {
               

                this.Resources["MyFillBrush"] = new SolidColorBrush(Color.FromRgb(197, 197, 197));

            }
            if (slider1.Value == 3) 
            {
                this.Resources["MyFillBrush"] = new SolidColorBrush(Color.FromRgb(236, 116, 60));

            }
            if (slider1.Value == 4)
            {
                this.Resources["MyFillBrush"] = new SolidColorBrush(Color.FromRgb(230, 62, 62));
            }
        }

        private void Slider2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (slider2.Value == 0)
            {
                this.Resources["MyFillBrush1"] = new SolidColorBrush(Color.FromArgb(73, 255, 106, 1));
            }

            if (slider2.Value == 1)
            {
                this.Resources["MyFillBrush1"] = new SolidColorBrush(Color.FromArgb(12, 253, 23, 1));
            }

            if (slider2.Value == 2)
            {
                this.Resources["MyFillBrush1"] = new SolidColorBrush(Color.FromArgb(207, 243, 41, 1));

            }
            if (slider2.Value == 3)
            {
                this.Resources["MyFillBrush1"] = new SolidColorBrush(Color.FromArgb(236, 116, 60, 1));

            }
            if (slider2.Value == 4)
            {
                this.Resources["MyFillBrush1"] = new SolidColorBrush(Color.FromArgb(230, 62, 62, 1));
            }
        }

        private void Slider3_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (slider3.Value == 0)
            {
                this.Resources["MyFillBrush2"] = new SolidColorBrush(Color.FromArgb(73, 255, 106, 1));
            }

            if (slider3.Value == 1)
            {
                this.Resources["MyFillBrush2"] = new SolidColorBrush(Color.FromArgb(12, 253, 23, 1));
            }

            if (slider3.Value == 2)
            {
                this.Resources["MyFillBrush2"] = new SolidColorBrush(Color.FromArgb(207, 243, 41, 1));

            }
            if (slider3.Value == 3)
            {
                this.Resources["MyFillBrush2"] = new SolidColorBrush(Color.FromArgb(236, 116, 60, 1));

            }
            if (slider3.Value == 4)
            {
                this.Resources["MyFillBrush2"] = new SolidColorBrush(Color.FromArgb(230, 62, 62, 1));
            }
        }

        private void Slider4_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (slider4.Value == 0)
            {
                this.Resources["MyFillBrush3"] = new SolidColorBrush(Color.FromArgb(73, 255, 106, 1));
            }

            if (slider4.Value == 1)
            {
                this.Resources["MyFillBrush3"] = new SolidColorBrush(Color.FromArgb(12, 253, 23, 1));
            }

            if (slider4.Value == 2)
            {
                this.Resources["MyFillBrush3"] = new SolidColorBrush(Color.FromArgb(207, 243, 41, 1));

            }
            if (slider4.Value == 3)
            {
                this.Resources["MyFillBrush3"] = new SolidColorBrush(Color.FromArgb(236, 116, 60, 1));

            }
            if (slider4.Value == 4)
            {
                this.Resources["MyFillBrush3"] = new SolidColorBrush(Color.FromArgb(230, 62, 62, 1));
            }
        }

        private void Slider5_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (slider5.Value == 0)
            {
                this.Resources["MyFillBrush4"] = new SolidColorBrush(Color.FromArgb(73, 255, 106, 1));
            }

            if (slider5.Value == 1)
            {
                this.Resources["MyFillBrush4"] = new SolidColorBrush(Color.FromArgb(12, 253, 23, 1));
            }

            if (slider5.Value == 2)
            {
                this.Resources["MyFillBrush4"] = new SolidColorBrush(Color.FromArgb(207, 243, 41, 1));

            }
            if (slider5.Value == 3)
            {
                this.Resources["MyFillBrush4"] = new SolidColorBrush(Color.FromArgb(236, 116, 60, 1));

            }
            if (slider5.Value == 4)
            {
                this.Resources["MyFillBrush4"] = new SolidColorBrush(Color.FromArgb(230, 62, 62, 1));
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
                button2.Background = new SolidColorBrush(Color.FromArgb(230, 62, 62, 1));
                button3.Background = new SolidColorBrush(Color.FromArgb(230, 62, 62, 1));
                button4.Background = new SolidColorBrush(Color.FromArgb(230, 62, 62, 1));
                button5.Background = new SolidColorBrush(Color.FromArgb(230, 62, 62, 1));

                Check_Arr[1] = true;
                Check_Arr[2] = true;
                Check_Arr[3] = true;
                Check_Arr[4] = true;

                CheckButton = 1;
            }
           
                       
            if (Check_Arr[0] == true)
            {
                button1.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 1));
                button3.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 1));
                button4.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 1));
                button5.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 1));
                button2.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 1));


                if (CheckButton == 2 )
                {
                    StrText = textBlock_week2.Text;
                    textBlock_week1.Text = textBlock_week2.Text;
                    textBlock_week2.Text = StrText;
                }
                if (CheckButton == 3)
                {
                    StrText = textBlock_week1.Text;
                    textBlock_week1.Text = textBlock_week3.Text;
                    textBlock_week3.Text = StrText;
                }
                if (CheckButton == 4)
                {
                    StrText = textBlock_week1.Text;
                    textBlock_week1.Text = textBlock_week4.Text;
                    textBlock_week4.Text = StrText;
                }
                if (CheckButton == 5)
                {
                    StrText = textBlock_week1.Text;
                    textBlock_week1.Text = textBlock_week5.Text;
                    textBlock_week5.Text = StrText;
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


                if (CheckButton == 1)
                {
                    StrText = textBlock_week2.Text;
                    textBlock_week1.Text = textBlock_week2.Text;
                    textBlock_week2.Text = StrText;
                }
                if (CheckButton == 3)
                {
                    StrText = textBlock_week2.Text;
                    textBlock_week2.Text = textBlock_week3.Text;
                    textBlock_week3.Text = StrText;
                }
                if (CheckButton == 4)
                {
                    StrText = textBlock_week2.Text;
                    textBlock_week2.Text = textBlock_week4.Text;
                    textBlock_week4.Text = StrText;
                }
                if (CheckButton == 5)
                {
                    StrText = textBlock_week2.Text;
                    textBlock_week2.Text = textBlock_week5.Text;
                    textBlock_week5.Text = StrText;
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


                if (CheckButton == 1)
                {
                    StrText = textBlock_week3.Text;
                    textBlock_week1.Text = textBlock_week3.Text;
                    textBlock_week3.Text = StrText;
                }
                if (CheckButton == 2)
                {
                    StrText = textBlock_week2.Text;
                    textBlock_week2.Text = textBlock_week3.Text;
                    textBlock_week3.Text = StrText;
                }
                if (CheckButton == 4)
                {
                    StrText = textBlock_week3.Text;
                    textBlock_week3.Text = textBlock_week4.Text;
                    textBlock_week4.Text = StrText;
                }
                if (CheckButton == 5)
                {
                    StrText = textBlock_week3.Text;
                    textBlock_week3.Text = textBlock_week5.Text;
                    textBlock_week5.Text = StrText;
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


                if (CheckButton == 1)
                {
                    StrText = textBlock_week2.Text;
                    textBlock_week1.Text = textBlock_week2.Text;
                    textBlock_week2.Text = StrText;
                }
                if (CheckButton == 2)
                {
                    StrText = textBlock_week1.Text;
                    textBlock_week1.Text = textBlock_week3.Text;
                    textBlock_week3.Text = StrText;
                }
                if (CheckButton == 2)
                {
                    StrText = textBlock_week1.Text;
                    textBlock_week1.Text = textBlock_week4.Text;
                    textBlock_week4.Text = StrText;
                }
                if (CheckButton == 5)
                {
                    StrText = textBlock_week1.Text;
                    textBlock_week1.Text = textBlock_week5.Text;
                    textBlock_week5.Text = StrText;
                }

            }
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            SolidColorBrush a = new SolidColorBrush(Color.FromArgb(230, 62, 62, 1));
            string StrText;

            if (Check_Arr[4] == false)
            {
                button1.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 1));
                button3.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 1));
                button4.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 1));
                button5.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 1));
                button2.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 1));

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


                if (CheckButton == 1)
                {
                    StrText = textBlock_week2.Text;
                    textBlock_week1.Text = textBlock_week2.Text;
                    textBlock_week2.Text = StrText;
                }
                if (CheckButton == 3)
                {
                    StrText = textBlock_week1.Text;
                    textBlock_week1.Text = textBlock_week3.Text;
                    textBlock_week3.Text = StrText;
                }
                if (CheckButton == 4)
                {
                    StrText = textBlock_week1.Text;
                    textBlock_week1.Text = textBlock_week4.Text;
                    textBlock_week4.Text = StrText;
                }
                if (CheckButton == 5)
                {
                    StrText = textBlock_week1.Text;
                    textBlock_week1.Text = textBlock_week5.Text;
                    textBlock_week5.Text = StrText;
                }

            }
        }
    }
}
