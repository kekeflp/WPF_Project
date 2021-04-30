using CourseManagement.Common;
using CourseManagement.Models;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CourseManagement.DTO;

namespace CourseManagement.Services
{
    public class CourseService : ICourseService
    {
        public Course GetCourseById(string id)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetCoursesAll()
        {
            throw new NotImplementedException();
        }

        public List<CourseSerise> GetCourseSerise()
        {
            // Access的2个以上的left join, 需要使用括号括起来 
            string sql = @"SELECT c.courseid, c.coursename, pr.playcount, pr.isgrowing, pr.growingrate, pf.platformname
                           FROM (courses AS c LEFT JOIN playrecord AS pr ON c.courseid = pr.courseid) 
                                              LEFT JOIN platforms AS pf ON pr.PlatformId = pf.PlatformId
                           ORDER BY c.courseid, pf.platformid; ";
            var dr = AccessDbHelper.SelectForDataReader(sql);
            List<CourseSerise> csList = new List<CourseSerise>();
            CourseSerise cs = null;
            string courseId = "";
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    #region 一个父对象，多个子对象集合
                    string tempId = dr["courseid"].ToString();
                    if (courseId != tempId)  // 当id相等时不就不创建对象1
                    {
                        courseId = tempId;   // 交换变量

                        cs = new CourseSerise();
                        cs.CourseName = dr["coursename"].ToString();
                        csList.Add(cs);      // id相等时，只添加一个对象

                        cs.PieSeriesList = new SeriesCollection();
                        cs.SeriesList = new ObservableCollection<DTO.Series>();

                    }
                    if (cs != null)
                    {
                        cs.PieSeriesList.Add(new PieSeries
                        {
                            Title = dr["platformname"].ToString(),
                            DataLabels = false,
                            Values = new ChartValues<ObservableValue>
                                    { new ObservableValue(Convert.ToInt32(dr["playcount"])) }
                        });
                        cs.SeriesList.Add(new DTO.Series
                        {
                            SeriesName = dr["platformname"].ToString(),
                            CurrentValue = Convert.ToInt32(dr["playcount"]),
                            IsGrowing = (GrowingState)dr["isgrowing"],
                            ChangeRate = Convert.ToInt32(dr["growingrate"]),
                        });
                    }
                    #endregion
                }
            }
            return csList;
        }

        public List<Course> GetCourseTeacherInfo()
        {
            string sql = @"SELECT u.RealName, c.courseid, c.CourseName, c.Description, c.CourseCover 
                           FROM (Course_User uc LEFT JOIN users u ON uc.UserID = u.UserID)
                                                LEFT JOIN courses c ON uc.courseid = c.courseid
                           ORDER BY uc.courseid;";
            var dr = AccessDbHelper.SelectForDataReader(sql);
            List<Course> ctiList = new List<Course>();
            Course cti = null;
            string courseid = "";
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    string temp = dr["courseid"].ToString();
                    if (temp != courseid)
                    {
                        courseid = temp;
                        cti = new Course();
                        cti.CourseName = dr["CourseName"].ToString();
                        cti.Description = dr["Description"].ToString();
                        cti.CourseCover = dr["CourseCover"].ToString();
                        ctiList.Add(cti);
                    }
                    if (cti != null)
                    {

                        cti.Teacher.Add(new User { RealName = dr["RealName"].ToString() });
                    }
                }
            }
            return ctiList;
        }
    }
}
