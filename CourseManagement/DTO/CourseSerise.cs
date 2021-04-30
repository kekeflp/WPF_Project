using LiveCharts;
using System.Collections.ObjectModel;

namespace CourseManagement.DTO
{
    public class CourseSerise
    {
        public string CourseName { get; set; }
        public SeriesCollection PieSeriesList { get; set; }
        public ObservableCollection<Series> SeriesList { get; set; }
    }
}
