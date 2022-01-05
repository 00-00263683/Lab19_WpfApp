using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Lab19_WpfApp.Models;

namespace Lab19_WpfApp.ViewModels
{
    internal class MainWindowViewModels : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private double radius;
        public double Radius
        {
            get { return radius; }
            set
            {
                radius = value;
                OnPropertyChanged(nameof(Radius));
            }
        }

        private double result;
        public double Result
        {
            get { return result; }
            set
            {
                result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        public ICommand СircleLength { get; }

        public void OnСircleLengthExecute(object p)
        {
            Result = Arith.Res(Radius);
        }
        public bool CanСircleLengthExecute(object p)
        {
            if (Radius > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public MainWindowViewModels()
        {
            СircleLength = new RelayCommand(OnСircleLengthExecute, CanСircleLengthExecute);
        }
    }
}
