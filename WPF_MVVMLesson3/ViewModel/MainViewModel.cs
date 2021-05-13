using System;
using System.Collections.Generic;
using System.Linq;
using WPF_MVVMLesson3.Model;

namespace WPF_MVVMLesson3.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Init();
            QueryStudentByName = new RelayCommand<string>(Search => GetStudentByName(Search));
            ResetCommand = new RelayCommand(() =>
            {
                Search = string.Empty;
                GetStudentALL();
            });
            EditCommand = new RelayCommand<int>(t => Edit(t));
            DelCommand = new RelayCommand<int>(t => Del(t));
        }

        private Student student;

        public Student Student
        {
            get { return student; }
            set { student = value; RaisePropertyChanged(() => Student); }
        }

        private List<Student> studentList;

        public List<Student> StudentList
        {
            get { return studentList; }
            set { studentList = value; RaisePropertyChanged(() => StudentList); }
        }

        private string search = string.Empty;

        public string Search
        {
            get { return search; }
            set { search = value; RaisePropertyChanged(() => Search); }
        }

        /// <summary>
        /// ��������
        /// </summary>
        private void Init()
        {
            StudentList = new List<Student>() { };
            for (int i = 0; i < 5; i++)
            {
                Student = new Student()
                {
                    Id = i,
                    UserName = $"Name{i}",
                    Age = 10 + i,
                    Gender = $"��{i}"
                };
                StudentList.Add(Student);
            }
        }

        #region ����

        public RelayCommand<string> QueryStudentByName { get; set; }
        public RelayCommand ResetCommand { get; set; }
        public RelayCommand<int> EditCommand { get; set; }
        public RelayCommand<int> DelCommand { get; set; }

        #endregion ����

        /// <summary>
        /// ���ѧ��
        /// </summary>
        /// <param name="stu">ѧ����</param>
        private void Add(Student stu)
        {
            StudentList.Add(stu);
        }

        /// <summary>
        /// ����ѧ����IDɾ��ѧ��
        /// </summary>
        /// <param name="id">ѧ��ID</param>
        private void DelStudentById(int id)
        {
            var model = StudentList.FirstOrDefault(s => s.Id == id);
            if (model != null)
            {
                StudentList.Remove(model);
            }
        }

        /// <summary>
        /// ����ѧ��������ģ����ѯ
        /// </summary>
        /// <param name="str">����</param>
        /// <returns>ѧ������</returns>
        private void GetStudentByName(string str)
        {
            var models = StudentList.Where(s => s.UserName.Contains(str)).ToList();
            if (models != null)
            {
                StudentList = models;
            }
        }

        /// <summary>
        /// ��ѯ����ѧ��
        /// </summary>
        /// <param name="str">����</param>
        /// <returns>ѧ������</returns>
        private void GetStudentALL()
        {
            Init();
        }

        private void Del(int t)
        {
            throw new NotImplementedException();
        }

        private void Edit(int t)
        {
            //var model = StudentList.FirstOrDefault(s => s.Id == t);
            //if (model != null)
            //{
            //    var esvm = new EditStudentViewModel(Student);

            //}
        }

        #region ��������

        ///// <summary>
        ///// ��ʼ����ѯ
        ///// </summary>
        //void Query()
        //{
        //    var models = GetStudentByName(Search);
        //    if (models != null)
        //    {
        //        models.ForEach(s =>
        //        {
        //            StudentList.Add(s);
        //        });
        //    }
        //}

        ///// <summary>
        ///// ��ѯ����ѧ��
        ///// </summary>
        ///// <param name="str"></param>
        ///// <returns></returns>
        //List<Student> QueryStudent(string str)
        //{
        //    return StudentList;
        //}

        ///// <summary>
        ///// ����ѧ��������ģ����ѯ
        ///// </summary>
        ///// <param name="str">����</param>
        ///// <returns>ѧ������</returns>
        //List<Student> GetStudentByName(string str)
        //{
        //    return StudentList.Where(s => s.UserName.Contains(str)).ToList();
        //}

        #endregion ��������
    }
}