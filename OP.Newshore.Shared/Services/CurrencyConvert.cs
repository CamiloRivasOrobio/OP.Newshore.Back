using Microsoft.Extensions.Configuration;
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
        private string ApiKeyValue { get; set; }
        public CurrencyConvert(IGenericClientHttp genericlient, IConfiguration configuration)
        {
            ApiKeyValue = configuration.GetConnectionString("ApiKey");
            this._genericlient = genericlient;
        }
        public async Task<double> ChangeCurrency(string currency, double amount, CancellationTokenSource cancellationToken, string jwtToken)
        {
            string url = $"https://api.apilayer.com/currency_data/convert?to={currency}&from=USD&amount={amount}";
            CurrencyConvertDto response = await _genericlient.GetRequestAsync<CurrencyConvertDto>(url, cancellationToken, jwtToken,
                this.ApiKeyValue, "ApiKey");

            return response.result;
        }
    }
}