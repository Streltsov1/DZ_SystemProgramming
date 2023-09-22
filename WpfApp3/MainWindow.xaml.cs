using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            int num = int.Parse(TB.Text);
            double result = await FactorialAsync(num);

            listBox.Items.Add(result);
        }

        private Task<double> FactorialAsync(int number)
        {
            return Task.Run(() =>
            {
                int num = number;
                double result = 1;
                for (double i = 1; i <= num; i++)
                {
                    result *= i;
                }
                Thread.Sleep(2000);
                return result;
            });
        }
    }
}
