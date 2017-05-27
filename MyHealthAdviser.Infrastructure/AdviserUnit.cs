using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHealthAdviser.Infrastructure
{
    public sealed class AdviserUnit : IUnitOfWork
    {
        public DbContext Db
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
