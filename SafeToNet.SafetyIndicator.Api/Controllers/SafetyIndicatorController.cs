using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SafeToNet.Commons.Validations;
using SafeToNet.SafetyIndicator.Core.Models.Entities;
using SafeToNet.SafetyIndicator.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafeToNet.SafetyIndicator.Api.Controllers
{
    [Route("v1/safetyIndicator")]
    [ApiController]
    public class SafetyIndicatorController : ControllerBase
    {
        public ISafetyIndicatorService _safetyIndicatorService;
        private readonly ILogger<SafetyIndicatorController> _logger;

        public SafetyIndicatorController(ISafetyIndicatorService safetyIndicatorService, ILogger<SafetyIndicatorController> logger)
        {
            _safetyIndicatorService = safetyIndicatorService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult("Get SafetyIndicator");
        }

        [HttpPost]
        [ModelValidation]
        [Authenticate]        
        [Route("create")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateInsights([FromBody]IEnumerable<Core.Models.Entities.SafetyIndicator> insights)
        {
            _logger.LogDebug("New create insights request: {@Insights}", insights);
            if (insights == null)
                return BadRequest();

            await _safetyIndicatorService.CreateInsights(insights);

            return Ok();
        }

        [HttpGet]
        [Authenticate]
        [Route("{deviceId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetInsightsBetweenTimes([NotEmptyGuid][FromRoute] Guid deviceId)
        {
            if (deviceId == Guid.Empty)
                return BadRequest();

            var result = await _safetyIndicatorService.GetLastOneDayAndDeviceIdBy(deviceId);

            return new OkObjectResult(result);
        }

        [HttpPost]
        [Route("GetInsightBy")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<Core.Models.Entities.SafetyIndicator>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetInsightsBy([NotEmptyGuid][FromBody] InsightsByRequest insightsByRequest)
        {
            if (insightsByRequest == null)
                return BadRequest();

            var result = await _safetyIndicatorService.GetParentAlertInsights(insightsByRequest.DeviceId, insightsByRequest.Hours, insightsByRequest.Minutes);

            return new OkObjectResult(result);
        }
    }
}