using System.Threading.Tasks;

namespace NamDashAspNetCoreServer.Interfaces
{
    public interface IQuotesRepository
    {
        Task<string> GetRandomQuote();
    }
}