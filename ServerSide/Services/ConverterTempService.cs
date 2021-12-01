using ServerSide.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSide.Services
{
    public class ConverterTempService : BaseService, IConverterTempService
    {
        public decimal CelsiusToFahrenheit(int celsius)
        {
            return Convert.ToDecimal((celsius * 1.8) + 32);
        }

        public decimal CelsiusToKelvin(int celsius)
        {
            return Convert.ToDecimal(celsius + 273.15);
        }

        public decimal FahrenheitToCelsius(int fahrenheit)
        {
            return Convert.ToDecimal((fahrenheit - 32) / 1.8);
        }

        public decimal KelvinToCelsius(int kelvin)
        {
            return Convert.ToDecimal(kelvin - 273.15);
        }
    }
}
