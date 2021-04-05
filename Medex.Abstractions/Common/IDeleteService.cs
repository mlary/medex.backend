using System.Collections.Generic;
using System.Threading.Tasks;


namespace Medex.Abstractions.Common
{
    public interface IDeleteService
    {
        Task<bool> DeleteByIdAsync(long id);

        Task DeleteByIdsAsync(IEnumerable<long> ids);
    }
}
