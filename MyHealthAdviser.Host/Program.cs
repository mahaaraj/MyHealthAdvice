using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
namespace MyHealthAdviser.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceBase[] servicestoRun = new ServiceBase[]
            {

               new MyHealthAdviserService()
            };

            ServiceBase.Run(servicestoRun);


        }
    }
}
