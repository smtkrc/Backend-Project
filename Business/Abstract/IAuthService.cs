using Entities.DTOs;
using GeneralClass.Entities.Concrete;
using GeneralClass.Utilities.Results;
using GeneralClass.Utilities.Security.JeasonWebToken;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
