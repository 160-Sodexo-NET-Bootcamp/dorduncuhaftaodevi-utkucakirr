using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccess.Generic
{
    public class GenericRepository<T>:IGenericRepository<T> where T:class
    {
        private readonly ILogger _logger;
        protected Homework4DbContext _context;
        internal DbSet<T> dbSet;

        public GenericRepository(Homework4DbContext context, ILogger logger)
        {
            _logger = logger;
            _context = context;

            dbSet = _context.Set<T>();
        }

        public async void Add(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
    }
}
