using System;
using System.Threading.Tasks;
using CqrsWithMediatR.Commands;
using CqrsWithMediatR.Models;
using CqrsWithMediatR.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsWithMediatR.Controllers
{
    [ApiController]
    [Route("ticker")]
    public class TickerController : Controller
    {
        private readonly IMediator _mediator;
        
        public TickerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetTickers()
        {
            var query = new GetAllTickersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicker(Guid id)
        {
            var query = new GetTickerByIdQuery(id);
            var result = await _mediator.Send(query);
            return result is not null ? Ok(result) : NotFound();
        }
        
        [HttpPost("")]
        public async Task<IActionResult> CreateTicker([FromBody]CreateTickerRequest request)
        {
            var command = new CreateTickerCommand(request.Symbol, request.Sector);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}