using System.Threading.Tasks;

namespace Medex.Abstractions.Common
{
    public interface IPriceLoaderService
    {
        Task LoadPriceAsync(long priceId);
    }
}
