using Microsoft.Toolkit.Mvvm.ComponentModel;
using WPF_CrazyElephant.Models;

namespace WPF_CrazyElephant.ViewModel
{
    /// <summary>
    /// 用来显示菜品是否可以被选中的viewmodel
    /// </summary>
    public class DishMenuItemViewModel : ObservableObject
    {
        public Dish Dish { get; set; }

        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; OnPropertyChanged(); }
        }
    }
}
