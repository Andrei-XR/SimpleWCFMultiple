using ClientSide.ContractServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClientSide
{
    public class Client
    {
        private const string _serviceAddress = "net.tcp://127.0.0.1:12345/SimpleWCFMultiple/";
        private string _serviceName = "ConverterTempService";
        public IConverterTempService Service { get; private set; }

        public Client()
        {
            Uri tcpUri = new Uri(_serviceAddress + _serviceName);
            EndpointAddress address = new EndpointAddress(tcpUri);
            NetTcpBinding clientBinding = new NetTcpBinding();
            ChannelFactory<IConverterTempService> factory = new ChannelFactory<IConverterTempService>(clientBinding, address);
            this.Service = factory.CreateChannel();
        }
    }
}
