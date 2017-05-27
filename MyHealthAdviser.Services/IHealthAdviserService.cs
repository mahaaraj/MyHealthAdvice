using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHealthAdviser.Dto;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace MyHealthAdviser.Contracts
{
    [ServiceContract]
    public interface IHealthAdviserService
    {
        
        [OperationContract]
        bool InsertPersonal(UserPesronal obj);

        [OperationContract]
        List<UserDetail> GetAllCustomer();

        [OperationContract]
        bool DeleteCustomer(int Cid);

        [OperationContract]
        bool UpdateCustomer(UserPesronal obj);

    }
}
