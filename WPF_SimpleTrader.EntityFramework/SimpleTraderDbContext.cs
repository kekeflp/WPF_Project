using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_SimpleTrader.Domain.Models;

namespace WPF_SimpleTrader.EntityFramework
{
    public class SimpleTraderDbContext : DbContext
    {
        // 数据库上下文
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.\sqlexpress;database=SimpleTrader;uid=sa;pwd=sa;");
            base.OnConfiguring(optionsBuilder);
        }

        // 数据库关系
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 从属实体类型
            // OwnsOne 的意思 相当于在AssetTransaction 表中有个 Stock 表镜像/映射, 这个镜像的字段与Stock 表中一致;
            modelBuilder.Entity<AssetTransaction>().OwnsOne(a => a.Stock);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AssetTransaction> AssetTransactions { get; set; }
    }
}
