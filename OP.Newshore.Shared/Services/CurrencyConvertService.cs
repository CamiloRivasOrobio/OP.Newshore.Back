using Microsoft.Extensions.Configuration;
using OP.Newshore.Application.DTOs;
using OP.Newshore.Application.Interfaces;

namespace OP.Newshore.Shared.Services
{
    public class CurrencyConvertService : ICurrencyConvertService
    {
        private readonly IGenericClientHttpService _genericlient;
        public IConfiguration _configuration { get; set; }
        public CurrencyConvertService(IGenericClientHttpService genericlient, IConfiguration configuration)
        {
            this._configuration = configuration;
            this._genericlient = genericlient;
        }
        public async Task<double> ChangeCurrency(string currency, double amount, CancellationToken cancellationToken, string jwtToken)
        {
            string url = $"{this._configuration["ServiceUrls:ApiLayer"]}?to={currency}&from=USD&amount={amount}";
            CurrencyConvertDto response = await _genericlient.GetRequestAsync<CurrencyConvertDto>(url, cancellationToken, jwtToken,
                this._configuration["ApiLayerSetting:Key"], this._configuration["ApiLayerSetting:Name"]);

            return response.result;
        }
    }
}