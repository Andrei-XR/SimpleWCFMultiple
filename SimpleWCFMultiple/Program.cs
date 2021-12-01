using ServerSide;
using SimpleWCFMultiple.ContractServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWCFMultiple
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.Start();

            var result = Service<IConverterTempService>.Call(s => s.CelsiusToFahrenheit(25));
            Console.WriteLine($"Temperatura em °F: {result}");

            var value = Service<IConverterCurrencyService>.Call(s => s.DollarToReal(29));
            Console.WriteLine($"29 dolares equivalem a {value} reais");

            Console.ReadKey();
        }
    }

    public class Service<T>
    {
        public static void Call(Action<T> action)
        {
            Call(s =>
            {
                action(s);
                return default(object);
            });
        }

        public static TResult Call<TResult>(Func<T, TResult> func)
        {
            TResult result = default;

            using(var channel = GetChannelFactory())
            {
                var service = channel.CreateChannel();
                result = func(service);
            }

            return result;
        }

        public static ChannelFactory<T> GetChannelFactory()
        {
            Uri tcpUri = new Uri($"net.tcp://127.0.0.1:12345/SimpleWCFMultiple/{typeof(T).Name.Remove(0, 1)}");
            EndpointAddress remoteAddress = new EndpointAddress(tcpUri);
            NetTcpBinding binding = new NetTcpBinding();
            ChannelFactory<T> factory = new ChannelFactory<T>(binding, remoteAddress);
            return factory;
        }
    }
}
