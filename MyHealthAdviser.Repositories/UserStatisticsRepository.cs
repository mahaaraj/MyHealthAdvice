using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHealthAdviser.Entities;
using MyHealthAdviser.Infrastructure;
using MyHealthAdviser.DataContext;

namespace MyHealthAdviser.Repositories
{
    public sealed class UserStatisticsRepository : BaseRepository<InformationEntity>

    {
        public UserStatisticsRepository(IUnitOfWork work) : base(work)
        {
        }
    }
}
