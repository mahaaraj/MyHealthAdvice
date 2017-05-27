using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHealthAdviser.Dto;

namespace MyHealthAdviser.Contracts
{
    class HealthAdviserProcessor : IHealthAdviserService
    {
        public List<UserDetail> GetAllCustomer()
        {
            throw new NotImplementedException();
        }

        public bool InsertPersonal(UserPesronal obj)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCustomer(UserPesronal obj)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCustomer(int Cid)
        {
            throw new NotImplementedException();
        }

    }
}
