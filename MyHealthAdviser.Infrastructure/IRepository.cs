using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHealthAdviser.Infrastructure
{
    public interface IRepository<T>
    {

        T Single(object primaryKey);

        IEnumerable<T> Filter(Func<T, bool> filter);


        IEnumerable<T> GetAll();



        void Insert(T entity);


        void Update(T entity);




        int Delete(T entity);

        IUnitOfWork UnitOfWork { get; }
    }
}
