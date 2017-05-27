using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHealthAdviser.Infrastructure
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        IUnitOfWork Work;
        internal DbSet<T> dbSet;
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return Work;
            }
        }

        public BaseRepository(IUnitOfWork work)
        {
            this.Work = work;
            this.dbSet = work.Db.Set<T>();
        }
        public int Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            dynamic obj = dbSet.Add(entity);
            this.Work.Db.SaveChanges();
        }

        public T Single(object primaryKey)
        {
            var dbResult = dbSet.Find(primaryKey);
            return dbResult;
        }



        public void Update(T entity)
        {
            dbSet.Attach(entity);
            Work.Db.Entry(entity).State = EntityState.Modified;
            this.Work.Db.SaveChanges();
        }

        public IEnumerable<T> Filter(Func<T, bool> filter)
        {
            return dbSet.Where(filter);
        }
    }
}
