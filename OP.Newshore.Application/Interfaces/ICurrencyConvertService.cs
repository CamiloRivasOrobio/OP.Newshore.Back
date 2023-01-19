﻿namespace OP.Newshore.Application.Interfaces
{
    public interface ICurrencyConvertService
    {
        Task<double> ChangeCurrency(string currency, double amount, CancellationToken cancellationToken, string jwtToken);
    }
}
