using LiveCharts;
using System.Collections.ObjectModel;

namespace CourseManagement.Models
{
    public class CourseSerise
    {
        public string CourseName { get; set; }
        public SeriesCollection PieSeriesList { get; set; }
        public ObservableCollection<Series> SeriesList { get; set; }
    }
}
