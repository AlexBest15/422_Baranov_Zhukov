using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace _422_Zhukov_Baranov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.xTextbox.PreviewTextInput += new TextCompositionEventHandler(textBox_PreviewTextInput1);
            this.iTextbox.PreviewTextInput += new TextCompositionEventHandler(textBox_PreviewTextInput2);
        }

        void textBox_PreviewTextInput1(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            string currentText = textBox.Text;
            string pattern = @"^-?\d*[,]?\d*$";
            string newText = currentText.Insert(textBox.SelectionStart, e.Text);
            if (!Regex.IsMatch(newText, pattern))
            {
                e.Handled = true;
            }
            else if (e.Text == "," && currentText.Contains(","))
            {
                e.Handled = true;
            }
        }
        void textBox_PreviewTextInput2(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            string currentText = textBox.Text;
            string pattern = @"^-?\d*$";
            string newText = currentText.Insert(textBox.SelectionStart, e.Text);
            if (!Regex.IsMatch(newText, pattern))
            {
                e.Handled = true;
            }
        }
        private void Calculate_Button_Click(object sender, RoutedEventArgs e)
        {
            double x = 0;
            int i = 0;
            bool error = false;
            if (xTextbox.Text == "" || iTextbox.Text == "")
            {
                MessageBox.Show("Уважаемый пользователь! Введите значения");
                error = true;
            }
            else
            {
                 x = Convert.ToDouble(xTextbox.Text);
                 i = Convert.ToInt32(iTextbox.Text);
            }
            double epx;
            double funcx = 0;
            
            if (rad_sh.IsChecked == true)
            {
                funcx = Math.Sinh(x);
            }
            else if (rad_x2.IsChecked == true)
            {
                funcx = Math.Pow(x, 2);
            }
            else if (rad_ex.IsChecked == true)
            {
                funcx = Math.Exp(x);
            }
            else
            {
                MessageBox.Show("Уважаемый пользователь! Выберите вариант функции f(x)");
                error = true;
            }
            
            if (error != true)
            {
                if (x > 0 && (i % 2 == 1))
                {
                    epx = i * Math.Sqrt(funcx);
                    TextBox1.Text = Convert.ToString(epx);
                }
                else if (x < 0 && (i % 2 == 0))
                {
                    epx = (i / 2) * (Math.Sqrt(Math.Abs(funcx)));
                    TextBox1.Text = Convert.ToString(epx);
                }
                else
                {
                    epx = Math.Sqrt(Math.Abs(i * funcx));
                    TextBox1.Text = Convert.ToString(epx);
                }
            }
        }
        private void Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            this.xTextbox.Text=null;
            this.iTextbox.Text = null;
            this.TextBox1.Text = null;
            this.rad_ex.IsChecked = false;
            this.rad_x2.IsChecked = false;
            this.rad_sh.IsChecked = false;
        }
    }
}
