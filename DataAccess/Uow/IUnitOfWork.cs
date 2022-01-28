using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Generic;
using Entities.DataModel;

namespace DataAccess.Uow
{
    public interface IUnitOfWork
    {
        IGenericRepository<User> UserRepository { get; }

        int Complete();
    }
}
