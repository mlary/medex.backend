using Medex.Abstractions.Common;
using Medex.Data.Dto;
using Medex.Data.Dto.Filtering;
using Medex.Domains.Models;
namespace Medex.Abstractions.Business
{
    public interface IGroupNameService : IReadService<GroupName, GroupNameDto, NameFilter>,
        IUpdateService<GroupName, GroupNameDto>,
        ICreateService<GroupName, GroupNameDto>,
        IDeleteService
    {
    }
}
