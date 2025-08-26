using Ants3Arena.Api.Business.MediatR.Requests;
using Ants3Arena.Api.Models.Dtos;
using Ants3Arena.Api.Models.ViewModels;
using Asp.Versioning;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ants3Arena.Api.Controllers.v1
{
    [ApiVersion(1)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]

    public class DirectionsController : ControllerBase
    {
        private readonly ILogger<AntsController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public DirectionsController(ILogger<AntsController> logger, IMapper mapper, IMediator mediator)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<DirectionViewModel>> GetDirectionByIdAsync([FromQuery]Guid DirectionId, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Getting direction for id {DirectionId}", DirectionId);
            try
            {
                var request = new GetBaseRequest<DirectionDto> { Id = DirectionId };
                var response = await _mediator.Send(request, cancellationToken);
                if (response.Data == null)
                {
                    _logger.LogWarning("Direction with id {DirectionId} not found", DirectionId);
                    return BadRequest($"Direction with id {DirectionId} not found.");
                }

                var result = _mapper.Map<DirectionViewModel>(response.Data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting direction for id {DirectionId}", DirectionId);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<DirectionViewModel>> CreateDirectionAsync([FromBody] DirectionViewModel DirectionViewModel, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creating new direction {DirectionViewModel}", DirectionViewModel);
            try
            {
                var dto = _mapper.Map<DirectionDto>(DirectionViewModel);
                var request = new SaveBaseRequest<DirectionDto> { Data = dto };
                var response = await _mediator.Send(request, cancellationToken);
                if (response.Data == null)
                {
                    _logger.LogWarning("Failed to create direction {DirectionViewModel}", DirectionViewModel);
                    return BadRequest("Failed to create direction.");
                }
                var result = _mapper.Map<DirectionViewModel>(response.Data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating direction {DirectionViewModel}", DirectionViewModel);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
