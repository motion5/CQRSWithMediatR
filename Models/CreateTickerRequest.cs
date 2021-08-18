namespace CqrsWithMediatR.Controllers
{
    public class CreateTickerRequest
    {
        public string Symbol { get; set; }
        public string Sector { get; set; }
    }
}