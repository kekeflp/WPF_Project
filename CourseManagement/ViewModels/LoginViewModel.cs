using CourseManagement.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Windows;
using System;
using CourseManagement.Services;
using CourseManagement.Common;

namespace CourseManagement.ViewModels
{
    public class LoginViewModel : ObservableObject
    {
        private User _login;
        public User Login
        {
            get { return _login; }
            set { _login = value; OnPropertyChanged(); }
        }

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(); }
        }


        //接受登陆窗体对象
        private object _thisWindow { get; set; }

        public IRelayCommand<object> CloseWindowsCommand { get; private set; }
        public IRelayCommand<object> LoginCommand { get; private set; }
        public LoginViewModel()
        {
            // 传过来的参数是window对象
            CloseWindowsCommand = new RelayCommand<object>(o => CloseWindowsCmd(o));
            LoginCommand = new RelayCommand<object>(o => DoLogin(o));
            this.Login = new User
            {
                UserName = "user001",
                Password = "123456789"
            };
        }

        private void DoLogin(object o)
        {
            Validation();
            try
            {
                var loginSvc = new LoginService();
                var result = loginSvc.LoginIn(this.Login.UserName, this.Login.Password);
                if (!result) throw new Exception("登陆失败，用户名或密码错误！");

                // 关系转对象DTO, 交给全局属性
                GlobalValues.UserInfo = loginSvc.GetUserInfo(this.Login.UserName);

                // 关闭登陆窗口
                Application.Current.Dispatcher.Invoke(new Action(() => { (o as Window).DialogResult = true; }));

                // 打开主窗口, 不要写到这，写到这不灵活, 判断写到app.xaml
                //new MainWindow().Show();
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
            }
            //finally
            //{
            //本来有个进度条，实际没加上去
            //Application.Current.Dispatcher.Invoke(new Action(() =>
            //{
            //    this.ShowPorgress = Visibility.Collapsed;
            //}));
            //}
        }

        private void Validation()
        {
            this.ErrorMessage = "";
            if (string.IsNullOrEmpty(Login.UserName))
            {
                this.ErrorMessage = "请输入用户名!";
                return;
            }
            if (string.IsNullOrEmpty(Login.Password))
            {
                this.ErrorMessage = "请输入密码!";
                return;
            }
            if (string.IsNullOrEmpty(Login.ValidationCode))
            {
                this.ErrorMessage = "请输入验证码!";
                return;
            }
        }

        private void CloseWindowsCmd(object o)
        {
            var window = o as Window;
            window.Close();
        }

        #region Action<Object> 另一种写法
        //public LoginViewModel()
        //{
        //    CloseWindowsCommand = new RelayCommand<object>((o) =>
        //    {
        //        var window = o as Window;
        //        window.Close();
        //    });
        //}
        #endregion
    }
}
