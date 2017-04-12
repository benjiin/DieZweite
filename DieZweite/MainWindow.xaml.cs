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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DieZweite
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    ///     public delegate string SmallerHandler(string input, char pivot);
    public delegate string SmallerHandler(string input, char pivot);
    public delegate string BiggerHandler(string input, char pivot);
    public delegate string QuicksortHandler(string input);
    public partial class MainWindow : Window
    {
        static SmallerHandler smaller;
        static BiggerHandler bigger;
        static QuicksortHandler quicksort;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string a = textBox1.Text;

            smaller = (input, pivot) => input == "" ? "" : input[0] <= pivot ? input[0] + smaller(input.Substring(1), pivot) : smaller(input.Substring(1), pivot);
            bigger = (input, pivot) => input == "" ? "" : input[0] > pivot ? input[0] + bigger(input.Substring(1), pivot) : bigger(input.Substring(1), pivot);
            quicksort = input => input == "" ? "" : quicksort(smaller(input.Substring(1), input[0])) + input[0] + quicksort(bigger(input.Substring(1), input[0]));

            label.Content = quicksort(a);



        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}
