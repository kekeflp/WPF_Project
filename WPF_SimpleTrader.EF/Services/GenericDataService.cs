using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_SimpleTrader.Domain.Services;

namespace WPF_SimpleTrader.EF.Services
{
    public class GenericDataService<T> : IDataService<T> where T : class
    {
        private readonly SimpleTraderDbContextFactory _contextFactory;

        public GenericDataService(SimpleTraderDbContextFactory simpleTraderDbContextFactory)
        {
            _contextFactory = simpleTraderDbContextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using SimpleTraderDbContext context = _contextFactory.CreateDbContext();
            var createdEntity = await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return createdEntity.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Update(int id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
