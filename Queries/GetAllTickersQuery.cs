using System.Collections.Generic;
using CqrsWithMediatR.Repositories;
using MediatR;

namespace CqrsWithMediatR.Queries
{
    public class GetAllTickersQuery : IRequest<List<Ticker>>
    {
        
    }
}