using CourseManagement.DTO;
using CourseManagement.Models;
using CourseManagement.Services;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CourseManagement.ViewModels
{
    public class CoursePageViewModel : ObservableObject
    {
        public ObservableCollection<CategoryItem> CategoryCourseList { get; set; }
        public ObservableCollection<CategoryItem> CategoryskillList { get; set; }
        public ObservableCollection<CategoryItem> CategoryTeacherList { get; set; }
        public ObservableCollection<Course> CourseInfoList { get; set; } = new ObservableCollection<Course>();

        private List<Course> courseAll = new List<Course>();
        public IRelayCommand<object> TeacherFilter { get; private set; }
        public CoursePageViewModel()
        {
            this.CategoryCourseList = new ObservableCollection<CategoryItem>
            {
                new CategoryItem( "全部" , true),
                new CategoryItem( "课程1" , false),
                new CategoryItem( "课程2" , false),
                new CategoryItem( "课程3" , false),
                new CategoryItem( "课程4" , false),
            };
            this.CategoryskillList = new ObservableCollection<CategoryItem>
            {
                new CategoryItem( "全部" , true),
                new CategoryItem( "技术1" , false),
                new CategoryItem( "技术2" , false),
                new CategoryItem( "技术3" , false),
                new CategoryItem( "技术4" , false),
            };

            // 取出所有的老师名称
            IUserSevice userSvc = new UserSevice();
            this.CategoryTeacherList = new ObservableCollection<CategoryItem>();
            CategoryTeacherList.Add(new CategoryItem("全部", true));
            foreach (var name in userSvc.GetTeacher())
                CategoryTeacherList.Add(new CategoryItem(name, false));

            InitCourseList();

            this.TeacherFilter = new RelayCommand<object>(o => DoTeacherFilterCmd(o));

        }

        private void DoTeacherFilterCmd(object o)
        {
            string name = o.ToString();
            List<Course> tempList = this.courseAll;
            if (name != "全部")
            {
                tempList = this.courseAll.Where(t => t.Teacher.Exists(u => u.RealName == name)).ToList();
            }

            CourseInfoList.Clear();
            foreach (var item in tempList)
            {
                this.CourseInfoList.Add(item);
            }
        }

        private void InitCourseList()
        {
            #region 本地数据库时使用,数据加载一般不会有延时
            //// 获取所有课程列表
            //ICourseService cSvc = new CourseService();
            //this.courseAll = cSvc.GetCourseTeacherInfo();
            //this.CourseInfoList = new ObservableCollection<Course>(courseAll);
            #endregion

            #region 远端数据库时使用
            ICourseService cSvc = new CourseService();
            Task.Run(new System.Action(async () =>
            {
                courseAll = cSvc.GetCourseTeacherInfo();
                // 延迟4s显示
                await Task.Delay(4000);

                // 加入主线程序列
                Application.Current.Dispatcher.Invoke(new System.Action(() =>
                {
                    foreach (var item in courseAll)
                    {
                        CourseInfoList.Add(item);
                    }
                }));
            }));
            #endregion
        }
    }
}
