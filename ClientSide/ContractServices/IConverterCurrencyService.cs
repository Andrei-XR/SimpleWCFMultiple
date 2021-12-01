using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ClientSide.ContractServices
{
    [ServiceContract]
    public interface IConverterCurrencyService
    {
        [OperationContract]
        decimal RealToDollar(int real);

        [OperationContract]
        decimal DollarToReal(int dollar);
    }
}
