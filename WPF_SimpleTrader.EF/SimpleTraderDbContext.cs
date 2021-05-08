using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WPF_SimpleTrader.Domain.Models;

namespace WPF_SimpleTrader.EF
{
    public class SimpleTraderDbContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SimpleTrader;Trusted_Connection=True;");
        //    base.OnConfiguring(optionsBuilder);
        //}

        public SimpleTraderDbContext(DbContextOptions Options) : base(Options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1:1 关系
            // EF 会根据其检测外键属性的能力，选择其中一个实体作为依赖项。 如果选择了错误的实体作为依赖项，则可以使用熟知的 API 来更正此问题。
            /* 从属实体类型
             * 所有实体类型永远不会通过约定 EF Core 在模型中。 您可以使用 OwnsOne 中的方法 OnModelCreating 或使用批注该类型 OwnedAttribute, 
             * 以将类型配置为拥有类型。在此示例中， Stock 是一个无标识（没有主键/Id）属性的类型。
             * OwnedAttribute从另一个实体类型引用时，可以使用将其视为拥有的实体.
             * 在数据库中的表现就是，相当于把 Stock表 的所有字段嵌入到 AssetTransaction表中。
             */
            modelBuilder.Entity<AssetTransaction>().OwnsOne(m => m.Asset);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AssetTransaction> AssetTransactions { get; set; }
    }
}
