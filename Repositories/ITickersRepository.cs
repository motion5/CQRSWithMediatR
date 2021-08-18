using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CqrsWithMediatR.Repositories
{
    public interface ITickersRepository
    {
        Task<List<Ticker>> GetTickersAsync();
        Task<Ticker> CreateTickerAsync(string symbol, string sector);
        Task<Ticker> GetTickerAsync(Guid tickerId);
    }
}