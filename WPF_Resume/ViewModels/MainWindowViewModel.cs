using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using WPF_Resume.Models;
using WPF_Resume.Services;

namespace WPF_Resume.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        public MainWindowViewModel()
        {
            this.LoadResume();
        }

        // 绑定ItemsSource时，一般优先考虑使用ObservableCollection<T>代替List<T>
        // 因为ObservableCollection<T>实现了INotifyCollectionChanged和INotifyPropertyChanged接口，
        // 能够把集合的变化立刻通知显示它的列表控件，改变会立刻呈现出来
        private ObservableCollection<SelecItemViewModel> _itemVM;
        public ObservableCollection<SelecItemViewModel> ItemVM
        {
            get { return _itemVM; }
            set { _itemVM = value; }
        }

        private void LoadResume()
        {
            IPresonService ps = new PresonService();
            this.ItemVM = new ObservableCollection<SelecItemViewModel>();
            List<Person> persons = ps.GetAllPreson();
            foreach (var person in persons)
            {
                SelecItemViewModel selecItemView = new SelecItemViewModel
                {
                    Person = person,
                    Experiences = ps.GetAllExperiences(person.Id),
                };
                this.ItemVM.Add(selecItemView);
            }
        }
    }
}
