using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DataModel;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public interface IHomework4DbContext
    {
        DbSet<User> Users { get; set; }

        int SaveChanges();
    }
}
