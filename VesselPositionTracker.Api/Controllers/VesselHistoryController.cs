﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoDesignAPI.Application.Services.Product.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VesselPositionTracker.Api.Features.Authorization;
using VesselPositionTracker.Application.Services.VesselHistory.ViewModel;
using VesselPositionTracker.Application.Tasks.Queries;

namespace VesselPositionTracker.Api.Controllers
{
    public class VesselHistoryController : BaseController
    {
        [HttpGet("{Begin}/{End}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Policy = Policies.OnlyThirdParties)]
        public async Task<ActionResult<VesselHistoryListVm>> GetAll(DateTime Begin, DateTime End)
        {
            return await Mediator.Send(new GetDateIntervalQuery
            {
                Begin = Begin,
                End = End
            });
        }
    }

}