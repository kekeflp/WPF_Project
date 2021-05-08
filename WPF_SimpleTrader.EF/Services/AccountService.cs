using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WPF_SimpleTrader.Domain.Models;
using WPF_SimpleTrader.Domain.Services;

namespace WPF_SimpleTrader.EF.Services
{
    public class AccountService : IAccountService
    {
        private readonly SimpleTraderDbContextFactory _contextFactory;

        public AccountService(SimpleTraderDbContextFactory simpleTraderDbContextFactory)
        {
            _contextFactory = simpleTraderDbContextFactory;
        }

        public async Task<Account> Create(Account entity)
        {
            using SimpleTraderDbContext context = _contextFactory.CreateDbContext();
            EntityEntry<Account> createdResult = await context.Set<Account>().AddAsync(entity);
            await context.SaveChangesAsync();
            return createdResult.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            using SimpleTraderDbContext context = _contextFactory.CreateDbContext();
            Account entity = await context.Set<Account>().FirstOrDefaultAsync((e) => e.Id == id);
            context.Set<Account>().Remove(entity);
            return true;
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            using SimpleTraderDbContext context = _contextFactory.CreateDbContext();
            return await context.Set<Account>()
                                .Include(a => a.AccountHolder)
                                .Include(a => a.AssetTransactions)
                                .ToListAsync();
        }

        public async Task<Account> GetOne(int id)
        {
            using SimpleTraderDbContext context = _contextFactory.CreateDbContext();
            return await context.Set<Account>()
                                .Include(a => a.AccountHolder)
                                .Include(a => a.AssetTransactions)
                                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Account> Update(int id, Account entity)
        {
            using SimpleTraderDbContext context = _contextFactory.CreateDbContext();
            entity.Id = id;
            context.Set<Account>().Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }



        public async Task<Account> GetByEmail(string email)
        {
            using SimpleTraderDbContext context = _contextFactory.CreateDbContext();
            return await context.Set<Account>()
                                .Include(a => a.AccountHolder)
                                .Include(a => a.AssetTransactions)
                                .FirstOrDefaultAsync(a => a.AccountHolder.Email == email);
        }

        public async Task<Account> GetByUsername(string username)
        {
            using SimpleTraderDbContext context = _contextFactory.CreateDbContext();
            return await context.Set<Account>()
                                .Include(a => a.AccountHolder)
                                .Include(a => a.AssetTransactions)
                                .FirstOrDefaultAsync(a => a.AccountHolder.Username == username);
        }
    }
}
