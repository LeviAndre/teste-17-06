using Tickets.Application.Common.Interfaces.Authentication;
using Tickets.Application.Common.Interfaces.Persistence;
using Tickets.Contracts.Authentication.Common;
using Tickets.Domain.Entities;

namespace Tickets.Application.Services.Authentication.Queries;

public class AuthenticationQueryService : IAuthenticationQueryService 
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository) 
    {
        _jwtTokenGenerator = jwtTokenGenerator;

        _userRepository = userRepository;
    }

    public AuthenticationResult Login(string email, string password)
    {
        //CHECK IF USER EXISTS
        if(_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("Usuário não encontrado. ");
        }

        //CHECK IF USER INFORMATION MATCHES WITH OUR DB
        if (user.Password != password) 
        {
            throw new Exception("Senha incorreta. ");
        };

        //GENERATE JWT TOKEN
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user, 
            token
        );
    }
}