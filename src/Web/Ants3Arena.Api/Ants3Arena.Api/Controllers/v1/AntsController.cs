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
    public class AntsController : ControllerBase
    {
        private readonly ILogger<AntsController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AntsController(ILogger<AntsController> logger, IMapper mapper, IMediator mediator)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AntViewModel>>> GetAllAntsAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Getting all ants");
            try
            {
                var request = new GetAllBaseRequest<AntDto>();
                var response = await _mediator.Send(request, cancellationToken);
                var result = _mapper.Map<IEnumerable<AntViewModel>>(response.Data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all ants");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("{antId:guid}")]
        public async Task<ActionResult<AntViewModel>> GetAntByIdAsync([FromRoute] Guid antId, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Getting ant by id {AntId}", antId);
            try
            {
                var request = new GetBaseRequest<AntDto> { Id = antId };
                var response = await _mediator.Send(request, cancellationToken);
                if(response.Data == null)
                {
                    _logger.LogWarning("Ant not found with id {AntId}", antId);
                    return NotFound();
                }
                var result = _mapper.Map<AntViewModel>(response.Data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting ant by id {AntId}", antId);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<AntViewModel>> CreateAntAsync([FromBody]CreateAntViewModel createAntViewModel, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creating a new ant {Ant}", createAntViewModel);
            try
            {
                var dto = _mapper.Map<AntDto>(createAntViewModel);
                var request = new SaveBaseRequest<AntDto> { Data = dto };
                var response = await _mediator.Send(request, cancellationToken);
                if(response.Data == null)
                {
                    _logger.LogWarning("Failed to create a new ant {Ant}", createAntViewModel);
                    return BadRequest("Failed to create a new ant");
                }
                var result = _mapper.Map<AntViewModel>(response.Data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating a new ant");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
