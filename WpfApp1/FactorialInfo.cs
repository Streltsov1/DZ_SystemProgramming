using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace WpfApp1
{
    public class FactorialInfo : INotifyPropertyChanged
    {
        private int progress;
        private decimal number;
        public decimal result { get; set; }
        public decimal Number 
        {
            get { return number; }
            set
            {
                number = value;
                OnPropertyChanged();
            }
        }
        public int Progress
        {
            get { return progress; }
            set
            {
                progress = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
