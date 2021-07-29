using Microsoft.EntityFrameworkCore;
using PaymentServices.DataAccess.DomainRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PaymentServices.DataAccess.DomainRepository.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected readonly DbContext _cotext;
        internal DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _cotext = context;
            this._dbSet = context.Set<T>();
        }

        public async void Add(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async void AddMany(List<T> entity)
        {
            await _dbSet.AddRangeAsync(entity);
        }

        public async Task<T> Get(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null, int recordCount = 0)
        {
            IQueryable<T> query = _dbSet;

            //Comma separated string
            if (includeProperties != null)
            {

                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (recordCount > 0)
            {
                query = query.Take(recordCount);
            }

            return await query.ToListAsync();

        }

        public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter = null,
            string includeProperties = null)
        {
            IQueryable<T> query = _dbSet;

            //Comma separated string
            if (includeProperties != null)
            {

                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.FirstOrDefaultAsync();
        }

        public Task<List<T>> GetTransilated(int id, int languageId)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            T entityToRemove = _dbSet.Find(id);
            Remove(entityToRemove);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
