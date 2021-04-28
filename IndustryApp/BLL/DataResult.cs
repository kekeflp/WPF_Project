namespace IndustryApp.BLL
{
    public class DataResult<T>
    {
        public bool State { get; set; } = false;
        public string Message { get; set; }

        /// <summary>
        /// 返回的数据类型未知，使用T表示
        /// </summary>
        public T Data { get; set; }
    }

    /// <summary>
    /// 设置一个默认返回为string类型的Data
    /// </summary>
    public class DataResult : DataResult<string>
    {

    }
}
