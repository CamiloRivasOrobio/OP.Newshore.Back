// ***********************************************************************
// Assembly         : OP.Newshore.WebAPI
// Author           : Camilo Rivas
// Created          : 15-01-2023
//
// Last Modified By : Camilo Rivas
// Last Modified On : Camilo Rivas
// ***********************************************************************
// <copyright file="FlightController.cs" company="OP.Newshore.WebAPI">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using OP.Newshore.Application.Features.Fligth.Queries.GetTravelRouteQuery;

namespace OP.Newshore.WebAPI.Controllers.v1
{
    /// <summary>
    /// Class FlightController.
    /// Implements the <see cref="BaseApiController" />
    /// </summary>
    /// <seealso cref="BaseApiController" />
    [ApiVersion("1.0")]
    public class FligthController : BaseApiController
    {
        /// GET api/<controller>
        /// <summary>
        /// Obtains the information related to Documento, under a set of filters defined in the request
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        /// <response code="200">Return code 200, when process are correct, with the list of records that comply with the application of all request filters</response>
        /// <response code="204">Return code 204, when The request resource could not be found results in the service</response>
        /// <response code="400">Return code 400, when the registry are wrong in any field, and the server don't process the request</response>
        /// <response code="500">Return code 500, when produce a internal error during process the request into the service, the response contains description about error</response>
        /// <remarks>Sample request:
        /// GET
        /// {
        /// "id": 5
        /// }</remarks>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetTravelRouteParameters filter)
        {
            return Ok(await Mediator.Send(new GetTravelRouteQuery
            {
                Origin = filter.Origin,
                Destination = filter.Destination
            }));
        }
    }
}