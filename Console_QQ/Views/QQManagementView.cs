using Console_QQ.Services;
using System;

namespace Console_QQ.Views
{
    public class QQManagementView
    {
        private readonly QQUserService qQUserService = new QQUserService();
        private readonly BaseInforService baseInforService = new BaseInforService();

        // 登陆页面
        private bool LoginPage()
        {
            Console.WriteLine("请输入账号：");
            var qqid = long.Parse(Console.ReadLine());
            Console.WriteLine("请输入密码：");
            var pwd = Console.ReadLine();
            try
            {
                return qQUserService.LoginUser(qqid, pwd);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        // 显示用户信息页面
        private void ShowQQInfoPage()
        {
            Console.WriteLine("请输入账号：");
            var qqid = long.Parse(Console.ReadLine());
            try
            {
                var baseinfo = baseInforService.GetBaseInfoByQQId(qqid);
                Console.WriteLine($"账号：{baseinfo.QQId}\r\n昵称：{baseinfo.NickName}\r\n性别：{baseinfo.Sex}\r\n省份：{baseinfo.Priovince}\r\n城市：{baseinfo.City}\r\n地址：{baseinfo.Address}\r\n联系方式：{baseinfo.Phone}\r\n等级：{baseinfo.QQUser.Level}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // 更新在线天数
        private void UpdateDayTimePage()
        {
            Console.WriteLine("请输入账号：");
            var qqid = long.Parse(Console.ReadLine());
            Console.WriteLine("请输入新增天数：");
            var day = int.Parse(Console.ReadLine());
            try
            {
                qQUserService.UpdateQQUserOnlineTime(qqid, day);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // 更新用户密码
        private void UpdatePasswordPage()
        {
            Console.WriteLine("请输入账号：");
            var qqid = long.Parse(Console.ReadLine());
            Console.WriteLine("请输入原密码：");
            var oldPwd = Console.ReadLine();
            Console.WriteLine("请输入新密码：");
            var newPwd = Console.ReadLine();
            try
            {
                qQUserService.UpdateQQUserPwd(qqid, oldPwd, newPwd);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void StartPage()
        {
            while (true)
            {
                Console.WriteLine("欢迎使用XX用户管理系统");
                Console.WriteLine("1.登录");
                Console.WriteLine("2.推出");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        if (LoginPage())
                        {
                            Console.WriteLine("进入主页面");
                            MainPage();
                        }
                        break;
                    case 2:
                        Console.WriteLine("谢谢使用");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("输入有误，请重新输入");
                        break;
                }
            }
        }

        private void MainPage()
        {
            while (true)
            {
                Console.WriteLine("1.添加用户");
                Console.WriteLine("2.查看指定用户");
                Console.WriteLine("3.修改密码");
                Console.WriteLine("4.修改时长");
                Console.WriteLine("5.删除用户");
                Console.WriteLine("6.注销");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        break;
                    case 2:
                        ShowQQInfoPage();
                        break;
                    case 3:
                        UpdatePasswordPage();
                        break;
                    case 4:
                        UpdateDayTimePage();
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("输入有误，请重新输入");
                        break;
                }
            }
        }
    }
}
