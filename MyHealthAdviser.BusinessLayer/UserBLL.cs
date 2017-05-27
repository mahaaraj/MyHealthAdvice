using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHealthAdviser.Entities;
using MyHealthAdviser.DataContext;
using MyHealthAdviser.Repositories;
using MyHealthAdviser.Infrastructure;
namespace MyHealthAdviser.BusinessLayer
{
    public sealed class UserBLL : BaseBLL
    {
        public void Insert(UserEntity entity)
        {
            using (IUnitOfWork unitofwork = new AdviserUnit())
            {
                IRepository<UserEntity> rep = new UserRepository(unitofwork);
                rep.Insert(entity);
            }
        }

        public void InsertInfo(InformationEntity entity)
        {
            using (IUnitOfWork unitofwork = new AdviserUnit())
            {
                IRepository<InformationEntity> rep = new UserStatisticsRepository(unitofwork);
                rep.Insert(entity);
            }

        }

    }
}
