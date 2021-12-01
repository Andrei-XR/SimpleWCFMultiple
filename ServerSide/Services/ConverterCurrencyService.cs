using ServerSide.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSide.Services
{
    public class ConverterCurrencyService : BaseService, IConverterCurrencyService
    {
        public decimal DollarToReal(int dollar)
        {
            return Convert.ToDecimal(dollar * 5.61);
        }

        public decimal RealToDollar(int real)
        {
            return Convert.ToDecimal(real / 5.61);
        }
    }
}
