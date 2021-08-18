using System;

namespace CqrsWithMediatR.Repositories
{
    public class Ticker
    {
        public Guid Id { get; set; }
        public string Symbol { get; set; }
        public string Sector { get; set; }
    }
}