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

    public class AntColorsController : ControllerBase
    {
        private readonly ILogger<AntsController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AntColorsController(ILogger<AntsController> logger, IMapper mapper, IMediator mediator)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AntColorViewModel>>> GetAllAntColorsAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Getting all ant colors");
            try
            {
                var request = new GetAllBaseRequest<AntColorDto>();
                var response = await _mediator.Send(request, cancellationToken);
                var result = _mapper.Map<IEnumerable<AntColorViewModel>>(response.Data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all ant colors");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("{antColorId:guid}")]
        public async Task<ActionResult<AntColorViewModel>> GetAntColorByIdAsync(Guid antColorId, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Getting ant color for id {AntColorId}", antColorId);
            try
            {
                var request = new GetBaseRequest<AntColorDto> { Id = antColorId };
                var response = await _mediator.Send(request, cancellationToken);
                if (response.Data == null)
                {
                    _logger.LogWarning("Ant color with id {AntColorId} not found", antColorId);
                    return BadRequest($"Ant color with id {antColorId} not found.");
                }

                var result = _mapper.Map<AntColorViewModel>(response.Data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting ant color for id {AntColorId}", antColorId);
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpPost]
        public async Task<ActionResult<AntColorViewModel>> CreateAntColorAsync([FromBody] AntColorViewModel antColorViewModel, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creating new ant color {AntColorViewModel}", antColorViewModel);
            try
            {
                var dto = _mapper.Map<AntColorDto>(antColorViewModel);
                var request = new SaveBaseRequest<AntColorDto> { Data = dto };
                var response = await _mediator.Send(request, cancellationToken);
                if (response.Data == null)
                {
                    _logger.LogWarning("Failed to create ant color {AntColorViewModel}", antColorViewModel);
                    return BadRequest("Failed to create ant color.");
                }
                var result = _mapper.Map<AntColorViewModel>(response.Data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating ant color {AntColorViewModel}", antColorViewModel);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
