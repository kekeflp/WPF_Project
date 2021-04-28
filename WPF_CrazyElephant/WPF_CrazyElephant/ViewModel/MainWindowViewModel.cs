using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_CrazyElephant.Models;
using WPF_CrazyElephant.Services;

namespace WPF_CrazyElephant.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {
        private Restaurant restaurant;
        /// <summary>
        /// 餐厅基本属性
        /// </summary>
        public Restaurant Restaurant
        {
            get { return restaurant; }
            set { restaurant = value; OnPropertyChanged(); }
        }

        private List<DishMenuItemViewModel> dishMenu;
        /// <summary>
        /// 每一列都是一个对象, 包含dish和是否选中属性
        /// </summary>
        public List<DishMenuItemViewModel> DishMenuVM
        {
            get { return dishMenu; }
            set { dishMenu = value; OnPropertyChanged(); }
        }

        private int count;
        /// <summary>
        /// 选中的个数
        /// </summary>
        public int Count
        {
            get { return count; }
            set { count = value; OnPropertyChanged(); }
        }

        // 命令属性
        public RelayCommand SelectMenuItemCommand { get; set; }
        public RelayCommand PlaceOrderCommand { get; set; }

        // 构造函数
        public MainWindowViewModel()
        {
            this.LoadRestaurant();
            this.LoadDishMenu();
            SelectMenuItemCommand = new RelayCommand(SelectMenuItemExecute);
            PlaceOrderCommand = new RelayCommand(PlaceOrderCommandExecute);
        }

        private void LoadRestaurant()
        {
            this.Restaurant = new Restaurant
            {
                Name = "Crazy大象",
                Address = "北京市海定区万泉河路紫金庄园1号楼1层113室(亲们: 这地儿特难找!)",
                Phone = "13800001111 or 010-88886666",
            };
        }

        private void LoadDishMenu()
        {
            // 取到所有菜品
            XmlDataService xds = new XmlDataService();
            List<Dish> dishes = xds.GetAllDishes();

            // 转换到新的集合类
            this.DishMenuVM = new List<DishMenuItemViewModel>();
            foreach (var item in dishes)
            {
                DishMenuItemViewModel dmivm = new DishMenuItemViewModel
                {
                    Dish = item,
                };
                this.DishMenuVM.Add(dmivm);
            }
        }

        private void SelectMenuItemExecute()
        {
            // 计数  Count(判断条件) 返回满足条件的个数
            this.Count = this.DishMenuVM.Count(i => i.IsSelected == true);
        }

        private void PlaceOrderCommandExecute()
        {
            // 过滤
            // 先找出已选择的项, 再在其中找出所有菜单名称
            var selectDishes = this.DishMenuVM.Where(i => i.IsSelected == true).Select(i => i.Dish.Name).ToList();
            IOrderService orderService = new MockOrderService();
            orderService.PlaceOrder(selectDishes);
            MessageBox.Show("预定成功");

            // 打印对象多字段
            //var selectDishes = this.DishMenuVM.Where(i => i.IsSelected == true).Select(i => i.Dish).ToList();
            //IOrderService orderService = new MockOrderService();
            //orderService.PlaceOrderDish(selectDishes);
            //MessageBox.Show("预定成功");
        }
    }
}
