using CourseManagement.Models;
using CourseManagement.Views;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Reflection;
using System.Windows;

namespace CourseManagement.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        // 用户信息
        public User UserInfo { get; set; }

        // 搜索文本
        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; OnPropertyChanged(); }
        }

        // Tab页
        private FrameworkElement _currentContent;
        public FrameworkElement CurrentContent
        {
            get { return _currentContent; }
            set { _currentContent = value; OnPropertyChanged(); }
        }

        // Tab页切换
        public IRelayCommand<string> TabSwitchCommand { get; private set; }
        // 呼出右侧边栏
        public IRelayCommand SiderbarShowCommand { get; private set; }

        public MainViewModel()
        {
            this.UserInfo = new User();
            TabSwitchCommand = new RelayCommand<string>((text) => TabSwitchCmd(text));
            SiderbarShowCommand = new RelayCommand(SiderbarShowCmd);
            // 程序加载时, 直接载入首页
            TabSwitchCmd("HomePageView");
        }

        private void TabSwitchCmd(string text)
        {
            // 传统方式
            //switch (text)
            //{
            //    case "HomePageView":
            //        HomePageView homeView = new HomePageView();
            //        // UserControl 本身就是继承 FrameworkElement
            //        CurrentContent = homeView;
            //        break;
            //    case "CoursePageView":
            //        CoursePageView courseView = new CoursePageView();
            //        CurrentContent = courseView;
            //        break;
            //    case "诚聘英才":
            //        break;
            //    case "AboutUs":
            //        AboutUsPageView aboutUsView = new AboutUsPageView();
            //        CurrentContent = aboutUsView;
            //        break;
            //}

            //通过反射的方式, 获取 view视图
            // 获取类
            Type type = Type.GetType("CourseManagement.Views." + text.ToString());
            // 获取类的构造函数信息
            ConstructorInfo cstinfo = type.GetConstructor(Type.EmptyTypes);
            // 类似实例化类的构造函数
            this.CurrentContent = (FrameworkElement)cstinfo.Invoke(null);
        }
        private void SiderbarShowCmd()
        {
            SidebarView sidebar = new SidebarView();
          
        }

    }
}
