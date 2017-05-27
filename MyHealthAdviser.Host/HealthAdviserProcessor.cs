using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHealthAdviser.Dto;
using MyHealthAdviser.BusinessLayer;
using MyHealthAdviser.Entities;
namespace MyHealthAdviser.Contracts
{
    class HealthAdviserProcessor : IHealthAdviserService
    {


        public bool InsertPersonal(UserPesronal obj)
        {
            try
            {
                using (UserBLL bll = new UserBLL())
                {
                    bll.Insert(new UserEntity() { Email = obj.email, Locality = obj.Locality });
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public void Submit(UserDetail info)
        {
            using (UserBLL bll = new UserBLL())
            {
                bll.InsertInfo(new InformationEntity() { BP = info.BP, Glucose = info.Glucose, HeartBeat = info.HB });
            }
        }
    }
}
