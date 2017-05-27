using MyHealthAdviser.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHealthAdviser.DataContext
{
    public sealed class AdviserUnit : IUnitOfWork
    {
        public DbContext Db
        {
            get
            {
                return new EntityContext();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
