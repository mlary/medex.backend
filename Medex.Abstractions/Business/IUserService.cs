using Medex.Abstractions.Common;
using Medex.Data.Dto;
using Medex.Data.Dto.Filtering;
using Medex.Domains.Models;
using System.Threading.Tasks;

namespace Medex.Abstractions.Business
{
    public interface IUserService : IReadService<User, UserDto, UserFilter>,
        IUpdateService<User, UserDto>,
        ICreateService<User, UserDto>,
        IDeleteService, IPaginationService<UserDto, UserFilter>
    {
        Task<UserTokenDto> Authenticate(UserAuthDto userAuth);

        Task<UserDto> GetByLoginAsync(string login);

        Task<UserTokenDto> SignupAsync(UserRegistrationDto dto);

        Task<UserDto> ChangeUserRoleAsync(ChangeUserRoleDto dto);
    }
}
