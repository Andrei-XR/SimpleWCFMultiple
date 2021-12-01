using ServerSide.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ServerSide
{
    public class Server
    {
        private string _serverBaseAddress = "net.tcp://127.0.0.1:12345/SimpleWCFMultiple/";

        private NetTcpBinding _binding = new NetTcpBinding();

        public List<ServiceHost> ServiceHostList { get; private set; } = new List<ServiceHost>();

        public void Start()
        {
            foreach(var service in GetServiceList())
            {
                CreateServicesByType(service);
            }
        }

        public void CreateServicesByType(Type service)
        {
            var serviceAddress = new Uri(_serverBaseAddress + service.Name);
            var serviceHost = new ServiceHost(service, serviceAddress);
            serviceHost.Description.Behaviors.Find<ServiceDebugBehavior>().IncludeExceptionDetailInFaults = true;

            serviceHost.AddServiceEndpoint(service.GetInterface("I" + service.Name), _binding, serviceAddress);
            serviceHost.OpenTimeout = TimeSpan.FromSeconds(20);
            serviceHost.Open();

            ServiceHostList.Add(serviceHost);
        }

        public List<Type> GetServiceList()
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.Namespace == "ServerSide.Services")
                .Where(t => t.Name.EndsWith("Service"))
                .Where(t => !t.IsAbstract)
                .ToList();
        }
    }
}
