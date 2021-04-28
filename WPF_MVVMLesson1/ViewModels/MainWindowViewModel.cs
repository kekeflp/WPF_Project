using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVMLesson1.Commons;

namespace WPF_MVVMLesson1.ViewModels
{
    class MainWindowViewModel : NotificationPropertyChanged
    {
        private double input1;

        public double Input1
        {
            get { return input1; }
            set
            {
                input1 = value;
                RiasePropertyChanged("Input1");
            }
        }

        private double input2;

        public double Input2
        {
            get { return input2; }
            set
            {
                input2 = value;
                RiasePropertyChanged("Input2");
            }
        }

        private double result;

        public double Result
        {
            get { return result; }
            set
            {
                result = value;
                RiasePropertyChanged("Result");
            }
        }

        public RelayCommand AddCommand { get; set; }

        public RelayCommand SaveCommand { get; set; }

        void Add(object parameter)
        {
            Result = Input1 + Input2;
        }

        void Save(object parameter)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
        }

        public MainWindowViewModel()
        {
            AddCommand = new RelayCommand();
            AddCommand.ExecuteAction = new Action<object>(Add);

            SaveCommand = new RelayCommand();
            SaveCommand.ExecuteAction = new Action<object>(Save);
        }


    }
}
