using LessonWPF_19.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LessonWPF_19.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string PropertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        private double number1;
        public double Number1
        {
            get => number1;
            set
            {
                number1 = value;
                OnPropertyChanged();
            }
        }
        private double number2;
        public double Number2
        {
            get => number2;
            set
            {
                number2 = value;
                OnPropertyChanged();
            }
        }
        public ICommand LengthCommand { get; }
        private void OnLengthCommandExecute (object p)
        {
            Number2 = Math.Round(Ariph.Length(Number1),2);
        }
        private bool CanLengthCommandExecuted (object p)
        {
            if (Number1 != 0)
                return true;
            else
                return false;
        }
        public MainWindowViewModel()
        {
            LengthCommand = new RelayCommand(OnLengthCommandExecute, CanLengthCommandExecuted);
        }
            
    }


}
