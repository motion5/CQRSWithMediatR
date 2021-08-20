using CqrsWithMediatR.Repositories;
using MediatR;

namespace CqrsWithMediatR.Commands
{
    public class CreateTickerCommand : IRequest<Ticker>
    {
        public string Symbol { get; }
        public string Sector { get; }
        
        public CreateTickerCommand(string requestSymbol, string requestSector)
        {
            Symbol = requestSymbol;
            Sector = requestSector;
        }
    }
}