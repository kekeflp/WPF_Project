using WPF_MVVMLesson3.Model;

namespace WPF_MVVMLesson3.ViewModel
{
    public class EditStudentViewModel : ViewModelBase
    {
        public EditStudentViewModel(Student stu)
        {
            stuModel = stu;
        }

        private Student stuModel;

        public Student Student
        {
            get { return stuModel; }
            set { stuModel = value; RaisePropertyChanged(() => Student); }
        }
    }
}