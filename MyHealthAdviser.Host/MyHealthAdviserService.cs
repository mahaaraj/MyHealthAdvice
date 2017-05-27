using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Configuration;

namespace MyHealthAdviser.Host
{
    partial class MyHealthAdviserService : ServiceBase
    {
        private List<ServiceHost> Services = new List<ServiceHost>();
        public MyHealthAdviserService()
        {
            InitializeComponent();
            ServiceModelSectionGroup services = ServiceModelSectionGroup.GetSectionGroup(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None));
            foreach (ServiceElement element in services.Services.Services)
            {
                Services.Add(new ServiceHost(Type.GetType(element.Name, true, true)));
            }
        }


        protected override void OnStart(string[] args)
        {
            base.OnStart(null);

            Services.ForEach(type =>
            {
                var service = new ServiceHost(type);
                service.Open();
            });
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }
    }
}
