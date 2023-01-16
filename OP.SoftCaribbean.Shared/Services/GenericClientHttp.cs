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
        public async Task<TOut> DeleteRequestAsync<TOut>(string url, CancellationTokenSource cancellationToken, string jwtToken)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            using HttpResponseMessage response = await client.DeleteAsync(url, cancellationToken.Token);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TOut>(responseBody);
        }

        public async Task<TOut> GetRequestAsync<TOut>(string url, CancellationTokenSource cancellationToken,
            string jwtToken, string? keyValue = null, string? keyName = null)
        {
            string responseBody = "";
            if (keyValue != null && keyName != null)
                client.DefaultRequestHeaders.Add(keyName, keyValue);

            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                responseBody = await response.Content.ReadAsStringAsync();
            }
            return JsonConvert.DeserializeObject<TOut>(responseBody);
        }

        public async Task<TOut> PostRequestAsync<TIn, TOut>(string url, TIn content, CancellationTokenSource cancellationToken, string jwtToken)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            var serialized = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");

            using HttpResponseMessage response = await client.PostAsync(url, serialized, cancellationToken.Token);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TOut>(responseBody);
        }

        public async Task<TOut> PutRequestAsync<TIn, TOut>(string url, TIn content, CancellationTokenSource cancellationToken, string jwtToken)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            var serialized = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");

            using HttpResponseMessage response = await client.PutAsync(url, serialized, cancellationToken.Token);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TOut>(responseBody);
        }
    }
}