using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Newshore.Application.Interfaces
{
    public interface ICurrencyConvert
    {
        Task<double> ChangeCurrency(string currency, double amount, CancellationTokenSource cancellationToken, string jwtToken);
    }
}
