using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DataModel;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class Homework4DbContext:DbContext,IHomework4DbContext
    {
        public Homework4DbContext(DbContextOptions<Homework4DbContext> options):base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
       
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
