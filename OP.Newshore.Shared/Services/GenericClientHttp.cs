// ***********************************************************************
// Assembly         : 3.UNP.AVRIL.Documento.Gateway
// Author           : Arq. Elkin Torres
// Created          : 11-11-2022
//
// Last Modified By : Arq. Elkin Torres
// Last Modified On : Arq. Elkin Torres
// ***********************************************************************
// <copyright file="GenericClientHttp.cs" company="3.UNP.AVRIL.Documento.Gateway">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using OP.Newshore.Application.Exceptions;
using OP.Newshore.Application.Interfaces;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace OP.Newshore.Shared.Services
{
    /// <summary>
    /// Class GenericClientHttp.
    /// Implements the <see cref="OP.Newshore.Application.Interfaces.IGenericClientHttp" />
    /// </summary>
    /// <seealso cref="OP.Newshore.Application.Interfaces.IGenericClientHttp" />
    [ExcludeFromCodeCoverage]
    public class GenericClientHttp : IGenericClientHttp
    {
        static HttpClient client = new HttpClient();
        public async Task<TOut> GetRequestAsync<TOut>(string url, CancellationTokenSource cancellationToken,
            string jwtToken, string? keyValue = null, string? keyName = null)
        {
            string responseBody = "";
            client.DefaultRequestHeaders.Clear();
            if (keyValue != null && keyName != null)
                client.DefaultRequestHeaders.Add(keyName, keyValue);
            //client.DefaultRequestHeaders.Add(keyName, keyValue);

            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                responseBody = await response.Content.ReadAsStringAsync();
            }
            return JsonConvert.DeserializeObject<TOut>(responseBody);
        }
    }
}