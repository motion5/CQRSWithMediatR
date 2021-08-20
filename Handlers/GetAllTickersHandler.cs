using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CqrsWithMediatR.Queries;
using CqrsWithMediatR.Repositories;
using MediatR;

namespace CqrsWithMediatR.Handlers
{
    public class GetAllTickersHandler : IRequestHandler<GetAllTickersQuery, List<Ticker>>
    {
        private readonly ITickersRepository _tickersRepository;
        
        public GetAllTickersHandler(ITickersRepository tickersRepository)
        {
            _tickersRepository = tickersRepository;
        }
        
        public async Task<List<Ticker>> Handle(GetAllTickersQuery request, CancellationToken cancellationToken)
        {
            return await _tickersRepository.GetTickersAsync();
        }
    }
}