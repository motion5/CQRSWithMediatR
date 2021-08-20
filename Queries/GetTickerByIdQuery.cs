using System;
using CqrsWithMediatR.Repositories;
using MediatR;

namespace CqrsWithMediatR.Queries
{
    public class GetTickerByIdQuery : IRequest<Ticker>
    {
        public Guid Id { get; }

        public GetTickerByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}