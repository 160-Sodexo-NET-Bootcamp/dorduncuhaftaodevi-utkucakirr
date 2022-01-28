using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Context;
using DataAccess.Generic;
using Entities.DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DataAccess.Uow
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private readonly Homework4DbContext _context;


        public IGenericRepository<User> UserRepository { get; private set; }

        public UnitOfWork(Homework4DbContext context,ILoggerFactory loggerFactory, IConfiguration configuration)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("patikaHW4");

            UserRepository = new GenericRepository<User>(_context, _logger);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
