using System;
using System.Threading.Tasks;
using CqrsWithMediatR.Models;
using CqrsWithMediatR.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CqrsWithMediatR.Controllers
{
    [ApiController]
    [Route("ticker")]
    public class TickerController : Controller
    {
        private readonly ITickersRepository _tickersRepository;
        
        public TickerController(ITickersRepository tickersRepository)
        {
            _tickersRepository = tickersRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetTickers()
        {
            var tickers = await _tickersRepository.GetTickersAsync();
            return Ok(tickers);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicker(Guid id)
        {
            var tickers = await _tickersRepository.GetTickerAsync(id);
            return Ok(tickers);
        }
        
        [HttpPost("")]
        public async Task<IActionResult> CreateTicker([FromBody]CreateTickerRequest request)
        {
            var tickers = await _tickersRepository.CreateTickerAsync(request.Symbol, request.Sector);
            return Ok(tickers);
        }
    }
}