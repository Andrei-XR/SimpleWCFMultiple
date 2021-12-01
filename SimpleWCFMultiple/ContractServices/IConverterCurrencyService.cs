using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWCFMultiple.ContractServices
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
