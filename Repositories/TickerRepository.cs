using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CqrsWithMediatR.Repositories
{
    public class TickerRepository : ITickersRepository
    {
        private readonly ILogger<TickerRepository> _logger;
        
        public TickerRepository(ILogger<TickerRepository> logger)
        {
            _logger = logger;
        }
        
        private readonly List<Ticker> _tickers = new()
        {
            new Ticker
            {
                Id = Guid.Parse("0bb7daa5-7f27-4b5f-95df-3d8b3b86d7ed"),
                Symbol = "TSLA",
                Sector = "Automotive"
            }
        };

        public Task<List<Ticker>> GetTickersAsync()
        {
            return Task.FromResult(_tickers);
        }

        public Task<Ticker> CreateTickerAsync(string symbol, string sector)
        {
            var ticker = new Ticker
            {
                Id = Guid.NewGuid(),
                Symbol = symbol,
                Sector = sector
            };

            _tickers.Add(ticker);
            return Task.FromResult(ticker);
        }

        public Task<Ticker> GetTickerAsync(Guid tickerId)
        {
            _logger.LogInformation("Searching for {TickerId}", tickerId);
            return Task.FromResult(_tickers.SingleOrDefault(x => x.Id == tickerId));
        }
    }
}