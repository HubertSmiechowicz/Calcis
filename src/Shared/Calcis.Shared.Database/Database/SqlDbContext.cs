using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Shared.Database
{
    public abstract class WriteDbContext<TContext> : DbContext
        where TContext : DbContext
    {
        protected WriteDbContext(DbContextOptions<TContext> options)
            : base(options) { }
    }

    public abstract class ReadDbContext<TContext> : DbContext
        where TContext : DbContext
    {
        public ReadDbContext(DbContextOptions<TContext> options) 
            : base(options) { }
    }
}
