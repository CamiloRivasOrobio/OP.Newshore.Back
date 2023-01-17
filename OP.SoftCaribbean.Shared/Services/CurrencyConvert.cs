using OP.Newshore.Application.DTOs;
using OP.Newshore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Newshore.Shared.Services
{
    public class CurrencyConvert : ICurrencyConvert
    {
        private readonly IGenericClientHttp _genericlient;
        public CurrencyConvert(IGenericClientHttp genericlient)
        {
            this._genericlient = genericlient;
        }
        public async Task<double> ChangeCurrency(string currency, double amount, CancellationTokenSource cancellationToken, string jwtToken)
        {
            string url = $"https://api.apilayer.com/currency_data/convert?to={currency}&from=USD&amount={amount}";
            CurrencyConvertDto response = await _genericlient.GetRequestAsync<CurrencyConvertDto>(url, cancellationToken, jwtToken,
                "IIYhXBPD6ZqTuIffYS4FTdhpUSmZBrl2", "ApiKey");

            return response.result;
        }
    }
}