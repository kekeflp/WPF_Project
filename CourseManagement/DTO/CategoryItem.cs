namespace CourseManagement.DTO
{
    public class CategoryItem
    {
        public bool IsChecked { get; set; }
        public string CategoryName { get; set; }

        public CategoryItem(string name, bool state)
        {
            this.CategoryName = name;
            this.IsChecked = state;
        }
    }
}
