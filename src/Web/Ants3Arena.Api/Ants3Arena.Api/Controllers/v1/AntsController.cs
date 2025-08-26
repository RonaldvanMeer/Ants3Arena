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
        public async Task<ActionResult<AntViewModel>> GetAntForColorAsync([FromQuery]Guid antColorId, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Getting ant for color {AntColorViewModel}", antColorId);
            return Ok(new AntViewModel
            {
                Id = Guid.NewGuid(),
                Name = "Test Ant",
                Color = new AntColorViewModel { Id = antColorId, Name = "Red", Description = "The color Red."  },
                Direction = new DirectionViewModel { Id = Guid.NewGuid(), Description= "Move to left up", Name = "LeftUp" },
                HorizontalVelocity = 1,
                VerticalVelocity = 1
            });
        }
    }
}
