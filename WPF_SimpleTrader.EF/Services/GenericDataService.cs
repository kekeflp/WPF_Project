using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading.Tasks;
using WPF_SimpleTrader.Domain.Models;
using WPF_SimpleTrader.Domain.Services;

namespace WPF_SimpleTrader.EF.Services
{
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        private readonly SimpleTraderDbContextFactory _contextFactory;

        public GenericDataService(SimpleTraderDbContextFactory simpleTraderDbContextFactory)
        {
            _contextFactory = simpleTraderDbContextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using SimpleTraderDbContext context = _contextFactory.CreateDbContext();
            EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return createdResult.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            using SimpleTraderDbContext context = _contextFactory.CreateDbContext();
            T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
            context.Set<T>().Remove(entity);
            return true;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using SimpleTraderDbContext context = _contextFactory.CreateDbContext();
            IEnumerable<T> entities = await context.Set<T>().ToListAsync();
            return entities;
        }

        public async Task<T> GetOne(int id)
        {
            using SimpleTraderDbContext context = _contextFactory.CreateDbContext();
            T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
            return entity;
        }

        public async Task<T> Update(int id, T entity)
        {
            using SimpleTraderDbContext context = _contextFactory.CreateDbContext();
            entity.Id = id;
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
