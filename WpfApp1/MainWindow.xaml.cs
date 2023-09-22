using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<FactorialInfo> operations;
        public MainWindow()
        {
            InitializeComponent();
            operations = new ObservableCollection<FactorialInfo>();
            // даємо можливість "біндиться" до параметрів операції копіювання
            operationsList.ItemsSource = operations;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FactorialInfo factorial = new FactorialInfo();
            if (decimal.Parse(numberTB.Text) >= 27)
                factorial.Number = 27;
            else
                factorial.Number = decimal.Parse(numberTB.Text);
            operations.Add(factorial);
            ThreadPool.QueueUserWorkItem(Facrotial, factorial);
        }
        private void Facrotial(object data)
        {
            if (!(data is FactorialInfo info)) return;
            decimal Number = info.Number;
            decimal result = 1;
            for (int i = 1; i <= Number; i++)
            {
                result *= i;
                info.result = result;
                info.Progress = i;
                Thread.Sleep(50);
            }
        }
    }
}
