using System.Threading;
using System.Threading.Tasks;
using CqrsWithMediatR.Commands;
using CqrsWithMediatR.Repositories;
using MediatR;

namespace CqrsWithMediatR.Handlers
{
    public class CreateTickerHandler : IRequestHandler<CreateTickerCommand, Ticker>
    {
        private readonly ITickersRepository _tickersRepository;
        
        public CreateTickerHandler(ITickersRepository tickersRepository)
        {
            _tickersRepository = tickersRepository;
        }
        
        public async Task<Ticker> Handle(CreateTickerCommand request, CancellationToken cancellationToken)
        {
            return await _tickersRepository.CreateTickerAsync(request.Symbol, request.Sector);
        }
    }
}