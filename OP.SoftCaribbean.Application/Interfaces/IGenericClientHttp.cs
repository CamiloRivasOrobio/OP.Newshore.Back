// ***********************************************************************
// Assembly         : OP.Newshore.WebAPI
// Author           : Camilo Rivas
// Created          : 15-01-2023
//
// Last Modified By : Camilo Rivas
// Last Modified On : Camilo Rivas
// ***********************************************************************
// <copyright file="IGenericClientHttp.cs" company="OP.Newshore.Application">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace OP.Newshore.Application.Interfaces
{
    /// <summary>
    /// Interface IGenericClientHttp
    /// </summary>
    public interface IGenericClientHttp
    {
        /// <summary>
        /// Gets the request asynchronous.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="jwtToken">The JWT token.</param>
        /// <returns>Task&lt;TOut&gt;.</returns>
        Task<TOut> GetRequestAsync<TOut>(string url, CancellationTokenSource cancellationToken,
            string jwtToken, string? keyValue = null, string? keyName = null);
        /// <summary>
        /// Posts the request asynchronous.
        /// </summary>
        /// <typeparam name="TIn">The type of the t in.</typeparam>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="content">The content.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="jwtToken">The JWT token.</param>
        /// <returns>Task&lt;TOut&gt;.</returns>
        Task<TOut> PostRequestAsync<TIn, TOut>(string uri, TIn content, CancellationTokenSource cancellationToken, string jwtToken);
        /// <summary>
        /// Deletes the request asynchronous.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="jwtToken">The JWT token.</param>
        /// <returns>Task&lt;TOut&gt;.</returns>
        Task<TOut> DeleteRequestAsync<TOut>(string uri, CancellationTokenSource cancellationToken, string jwtToken);
        /// <summary>
        /// Puts the request asynchronous.
        /// </summary>
        /// <typeparam name="TIn">The type of the t in.</typeparam>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="content">The content.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="jwtToken">The JWT token.</param>
        /// <returns>Task&lt;TOut&gt;.</returns>
        Task<TOut> PutRequestAsync<TIn, TOut>(string uri, TIn content, CancellationTokenSource cancellationToken, string jwtToken);
    }
}