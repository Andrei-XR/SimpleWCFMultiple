using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ServerSide.Contracts
{
    [ServiceContract]
    public interface IConverterCurrency
    {
        [OperationContract]
        decimal RealToDollar(int real);

        [OperationContract]
        decimal DollarToReal(int dollar);
    }
}
