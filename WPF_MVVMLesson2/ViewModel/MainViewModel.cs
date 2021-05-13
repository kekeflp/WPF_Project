using System.Collections.Generic;
using WPF_MVVMLesson2.Model;
using WPF_MVVMLesson2.View;

namespace WPF_MVVMLesson2.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            CtrModules = new List<CtrModule>()
            {
                new CtrModule{Name= "功能1"},
                new CtrModule{Name= "功能2"},
                new CtrModule{Name= "功能3"}
            };

            OpenCommand = new RelayCommand<string>(t => OpenPage(t));

            //嵌套取子集的属性
            CtrModule = new CtrModule() { Name = "CtrModule类的\r子集的Name" };
        }

        private CtrModule ctrmodule;

        public CtrModule CtrModule
        {
            get { return ctrmodule; }
            set { ctrmodule = value; RaisePropertyChanged(() => CtrModule); }
        }

        private List<CtrModule> ctrmodules;

        public List<CtrModule> CtrModules
        {
            get { return ctrmodules; }
            set { ctrmodules = value; RaisePropertyChanged(() => CtrModules); }
        }

        private object page;

        public object Page
        {
            get { return page; }
            set { page = value; RaisePropertyChanged(() => Page); }
        }

        private string testName;

        public string TestName
        {
            get { return testName; }
            set { testName = value; RaisePropertyChanged(() => TestName); }
        }

        public RelayCommand<string> OpenCommand { get; set; }

        private void OpenPage(string name)
        {
            //
            this.TestName = name;

            //页面导航（切换）
            switch (name)
            {
                case "功能1":
                    Page = new Page1();
                    break;

                case "功能2":
                    Page = new Page2();
                    break;

                case "功能3":
                    Page = new Page3();
                    break;
            }
        }
    }
}