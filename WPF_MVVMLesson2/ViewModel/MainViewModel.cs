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
                new CtrModule{Name= "����1"},
                new CtrModule{Name= "����2"},
                new CtrModule{Name= "����3"}
            };

            OpenCommand = new RelayCommand<string>(t => OpenPage(t));

            //Ƕ��ȡ�Ӽ�������
            CtrModule = new CtrModule() { Name = "CtrModule���\r�Ӽ���Name" };
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

            //ҳ�浼�����л���
            switch (name)
            {
                case "����1":
                    Page = new Page1();
                    break;

                case "����2":
                    Page = new Page2();
                    break;

                case "����3":
                    Page = new Page3();
                    break;
            }
        }
    }
}