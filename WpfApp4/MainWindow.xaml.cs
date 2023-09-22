using IOExtensions;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;


namespace WpfApp4
{
    public partial class MainWindow : Window
    {
        ObservableCollection<CopyFileInfo> operations;
        public MainWindow()
        {
            InitializeComponent();

            operations = new ObservableCollection<CopyFileInfo>();
            operationsList.ItemsSource = operations;
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            int num = int.Parse(TBNum.Text);
            CopyFileInfo[] info = new CopyFileInfo[num];
            for (int i = 0; i < num; i++)
            {
                info[i] = new CopyFileInfo();
                info[i].SourceFile = filePathTB.Text;
                info[i].DestFolder = folderPathTB.Text;
                operations.Add(info[i]);
            };
            await CopyFile(info, num);
        }

        int c = 1;
        private Task CopyFile(CopyFileInfo[] info, int num)
        {
            return Task.Run(() =>
            {
                for (int i = 0; i < num; i++)
                {
                    string copyFileName = $"{Path.GetFileNameWithoutExtension(info[i].SourceFile)}_copy_{c++}{Path.GetExtension(info[i].SourceFile)}";
                    string destFile = Path.Combine(info[i].DestFolder, copyFileName);
                    FileTransferManager.CopyWithProgressAsync(info[i].SourceFile, destFile, (obj) =>
                    {
                        if (obj.Percentage >= 1)
                            info[i].Progress = (int)obj.Percentage;
                    }, false);
                    Thread.Sleep(100);
                }
            });
        }
        
    }
}
