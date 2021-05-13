using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WPF_SimpleTrader.EF
{
    /// <summary>
    /// 从设计时工厂创建
    /// </summary>
    /* 你还可以通过实现接口来告诉工具如何创建 DbContext Microsoft.EntityFrameworkCore.Design.IDesignTimeDbContextFactory<TContext> ：
     * 如果实现此接口的类在与派生的项目相同的项目中 DbContext 或在应用程序的启动项目中找到，则这些工具将绕过创建 DbContext 的其他方法，并改用设计时工厂。
    */
    public class SimpleTraderDbContextFactory
    {
        readonly string _connectionString;
        public SimpleTraderDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SimpleTraderDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<SimpleTraderDbContext>();
            optionsBuilder.UseSqlServer(_connectionString);
            //optionsBuilder.UseSqlite(_connectionString);
            return new SimpleTraderDbContext(optionsBuilder.Options);
        }
    }
}
