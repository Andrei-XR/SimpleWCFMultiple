using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServerSide.Contracts
{
    [ServiceContract]
    public interface IConverterTempService
    {
        [OperationContract]
        decimal CelsiusToFahrenheit(int celius);

        [OperationContract]
        decimal FahrenheitToCelsius(int fahrenheit);

        [OperationContract]
        decimal KelvinToCelsius(int kelvin);

        [OperationContract]
        decimal CelsiusToKelvin(int celius);
    }
}
