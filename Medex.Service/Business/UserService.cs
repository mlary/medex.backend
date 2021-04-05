using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medex.Abstractions.Business;
using Medex.Abstractions.Common;
using Medex.Abstractions.Persistence;
using Medex.Data.Dto;
using Medex.Data.Dto.Filtering;
using Medex.Data.Exception;
using Medex.Data.Infrastructure;
using Medex.Data.Primitives;
using Medex.Domains.Models;
using Medex.Service.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Medex.Service.Business
{
    public class UserService : BasePageableService<User, UserDto, UserFilter>, IUserService
    {
        private readonly AuthConfiguration _config;
        public UserService(
            IApplicationDbContext dbContext,
            IMapper mapper,
            IOptions<AuthConfiguration> config,
            IPageQueryProvider<User, UserFilter> queryProvider) : base(dbContext, mapper, queryProvider)
        {
            _config = config.Value;
        }

        public async Task<UserTokenDto> Authenticate(UserAuthDto userAuth)
        {
            var userLogin = userAuth.Login;
            if (!string.IsNullOrEmpty(userLogin))
            {
                userLogin = userLogin.Trim().ToUpper();

                var existedUser = await GetUserByLoginAsync(userLogin);

                if (existedUser != null)
                {
                    if (GetPasswordHash(userAuth.Password) == existedUser.Password)
                    {
                        return new UserTokenDto { Token = GenerateJSONWebToken(existedUser) };
                    }
                }
            }
            throw new IncorrectAuthenticationDataException("Неверные аутентификационные данные");
        }

        private string GetPasswordHash(string password)
        {
            var alg = SHA256.Create();
            return Encoding.UTF8.GetString(
                 alg.ComputeHash(
                     Encoding.UTF8.GetBytes(password)));
        }

        private string GetUserRole(byte role)
        {
            switch ((EnumRoleCodes)role)
            {
                case EnumRoleCodes.Administrator:
                    return UserRole.Administrator;
                case EnumRoleCodes.Client:
                    return UserRole.Client;
                case EnumRoleCodes.Marketer:
                    return UserRole.Marketer;
                default:
                    return UserRole.Guest;
            }
        }

        private string GenerateJSONWebToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config.Issuer,
                _config.Issuer,
                new[] { new Claim(ClaimTypes.Name, user.Login), new Claim(ClaimTypes.Role, GetUserRole(user.UserRole)) },
                expires: DateTime.Now.AddDays(7),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<UserDto> GetByLoginAsync(string login)
        {
            return await _dbContext.Users.AsQueryable().ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                 .FirstOrDefaultAsync(x => x.Login == login);
        }
        private async Task<User> GetUserByLoginAsync(string userLogin)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Login == userLogin);
        }

        public async Task<UserTokenDto> SignupAsync(UserRegistrationDto dto)
        {
            var user = new User()
            {
                Email = dto.Email.ToUpper(),
                Login = dto.Email.ToUpper(),
                Password = dto.Password,
                Phone = dto.Phone,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                MiddleName = dto.MiddleName,
                IsConfirmed = false,
                IsEmailSent = false,
                CreatedOn = DateTime.Now,
                UserRole = (byte)EnumRoleCodes.Client,
            };

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return new UserTokenDto()
            {
                Token = GenerateJSONWebToken(user)
            };
        }

        public async Task<UserDto> ChangeUserRoleAsync(ChangeUserRoleDto dto)
        {
            User user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == dto.Id);
            user.UserRole = dto.UserRole;
            await _dbContext.SaveChangesAsync();
            return await GetDtoByIdAsync(dto.Id);
        }
    }
}
