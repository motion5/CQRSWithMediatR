using System.Threading;
using System.Threading.Tasks;
using CqrsWithMediatR.Queries;
using CqrsWithMediatR.Repositories;
using MediatR;

namespace CqrsWithMediatR.Handlers
{
    public class GetTickerByIdHandler : IRequestHandler<GetTickerByIdQuery, Ticker>
    {
        private readonly ITickersRepository _tickersRepository;
        
        public GetTickerByIdHandler(ITickersRepository tickersRepository)
        {
            _tickersRepository = tickersRepository;
        }
        
        public async Task<Ticker> Handle(GetTickerByIdQuery request, CancellationToken cancellationToken)
        {
            return await _tickersRepository.GetTickerAsync(request.Id);
        }
    }
}