using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHealthAdviser.Dto;
namespace MyHealthAdviser.Contracts
{
    public interface IHealthAdviserService
    {
        bool Submit(User user);
        
    }
}
