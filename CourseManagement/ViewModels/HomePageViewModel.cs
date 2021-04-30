using CourseManagement.DTO;
using CourseManagement.Models;
using CourseManagement.Services;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;

namespace CourseManagement.ViewModels
{
    public class HomePageViewModel : ObservableObject
    {
        public ObservableCollection<CourseSerise> CourseSeriseList { get; set; }

        // 动态的处理 一行显示最大个数
        private int _itemCount;
        public int ItemCount
        {
            get { return _itemCount; }
            set { _itemCount = value; OnPropertyChanged(); }
        }


        public HomePageViewModel()
        {
            #region 初始化数据测试
            //this.CourseSeriseList = new ObservableCollection<CourseSerise>()
            //{
            //    new CourseSerise
            //    {
            //        CourseName = "XXXX课程辅导案例1",
            //        PieSeriesList = new SeriesCollection
            //                            {
            //                                new PieSeries { Title = "云课堂",
            //                                                DataLabels = false,
            //                                                Values = new ChartValues<ObservableValue>{ new ObservableValue(9) } },
            //                                new PieSeries { Title = "微博",
            //                                                DataLabels = false,
            //                                                Values = new ChartValues<ObservableValue>{ new ObservableValue(13) } },
            //                                new PieSeries { Title = "短视频",
            //                                                DataLabels = false,
            //                                                Values = new ChartValues<ObservableValue>{ new ObservableValue(20) } },
            //                                new PieSeries { Title = "自媒体",
            //                                                DataLabels = false,
            //                                                Values = new ChartValues<ObservableValue>{ new ObservableValue(5) } },
            //                            },
            //        SeriesList = new ObservableCollection<Models.Series>
            //                            {
            //                                new Models.Series{ SeriesName = "云课堂", CurrentValue = 200, IsGrowing = GrowingState.Increase, ChangeRate = 30},
            //                                new Models.Series{ SeriesName = "微博", CurrentValue = 100, IsGrowing = GrowingState.Decrease, ChangeRate = -5},
            //                                new Models.Series{ SeriesName = "短视频", CurrentValue = 280, IsGrowing = GrowingState.Unchange, ChangeRate = -10},
            //                                new Models.Series{ SeriesName = "自媒体", CurrentValue = 90, IsGrowing = GrowingState.Increase, ChangeRate = 70},
            //                            },
            //    },
            //    new CourseSerise
            //    {
            //        CourseName = "XXXX课程辅导案例2",
            //        PieSeriesList = new SeriesCollection
            //                            {
            //                                new PieSeries { Title = "云课堂",
            //                                                DataLabels = false,
            //                                                Values = new ChartValues<ObservableValue>{ new ObservableValue(9) } },
            //                                new PieSeries { Title = "微博",
            //                                                DataLabels = false,
            //                                                Values = new ChartValues<ObservableValue>{ new ObservableValue(13) } },
            //                                new PieSeries { Title = "短视频",
            //                                                DataLabels = false,
            //                                                Values = new ChartValues<ObservableValue>{ new ObservableValue(20) } },
            //                                new PieSeries { Title = "自媒体",
            //                                                DataLabels = false,
            //                                                Values = new ChartValues<ObservableValue>{ new ObservableValue(5) } },
            //                            },
            //        SeriesList = new ObservableCollection<Models.Series>
            //                            {
            //                                new Models.Series{ SeriesName = "云课堂", CurrentValue = 200, IsGrowing = GrowingState.Increase, ChangeRate = 30},
            //                                new Models.Series{ SeriesName = "微博", CurrentValue = 100, IsGrowing = GrowingState.Decrease, ChangeRate = -5},
            //                                new Models.Series{ SeriesName = "短视频", CurrentValue = 280, IsGrowing = GrowingState.Unchange, ChangeRate = -10},
            //                                new Models.Series{ SeriesName = "自媒体", CurrentValue = 90, IsGrowing = GrowingState.Increase, ChangeRate = 70},
            //                            },
            //    },
            //    new CourseSerise
            //    {
            //        CourseName = "XXXX课程辅导案例3",
            //        PieSeriesList = new SeriesCollection
            //                            {
            //                                new PieSeries { Title = "云课堂",
            //                                                DataLabels = false,
            //                                                Values = new ChartValues<ObservableValue>{ new ObservableValue(9) } },
            //                                new PieSeries { Title = "微博",
            //                                                DataLabels = false,
            //                                                Values = new ChartValues<ObservableValue>{ new ObservableValue(13) } },
            //                                new PieSeries { Title = "短视频",
            //                                                DataLabels = false,
            //                                                Values = new ChartValues<ObservableValue>{ new ObservableValue(20) } },
            //                                new PieSeries { Title = "自媒体",
            //                                                DataLabels = false,
            //                                                Values = new ChartValues<ObservableValue>{ new ObservableValue(5) } },
            //                            },
            //        SeriesList = new ObservableCollection<Models.Series>
            //                            {
            //                                new Models.Series{ SeriesName = "云课堂", CurrentValue = 200, IsGrowing = GrowingState.Increase, ChangeRate = 30},
            //                                new Models.Series{ SeriesName = "微博", CurrentValue = 100, IsGrowing = GrowingState.Decrease, ChangeRate = -5},
            //                                new Models.Series{ SeriesName = "短视频", CurrentValue = 280, IsGrowing = GrowingState.Unchange, ChangeRate = -10},
            //                                new Models.Series{ SeriesName = "自媒体", CurrentValue = 90, IsGrowing = GrowingState.Increase, ChangeRate = 70},
            //                            },
            //    },
            //};
            #endregion

            ICourseService cSvc = new CourseService();
            this.CourseSeriseList = new ObservableCollection<CourseSerise>(cSvc.GetCourseSerise());
            // 通过Linq取最大值
            this.ItemCount = cSvc.GetCourseSerise().Max(c => c.SeriesList.Count);
        }
    }
}
