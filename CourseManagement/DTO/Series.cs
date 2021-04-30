namespace CourseManagement.DTO
{
    public class Series
    {
        public string SeriesName { get; set; }
        public int CurrentValue { get; set; }
        public GrowingState IsGrowing { get; set; }
        public int ChangeRate { get; set; }
    }

    public enum GrowingState
    {
        Increase,
        Decrease,
        Unchange
    }
}
