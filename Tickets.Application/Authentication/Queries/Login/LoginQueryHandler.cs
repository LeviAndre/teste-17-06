using MediatR;
using Tickets.Application.Authentication.Common;
using Tickets.Application.Common.Interfaces.Authentication;
using Tickets.Application.Common.Interfaces.Persistence;
using Tickets.Domain.Entities;

namespace Tickets.Application.Authentication.Query.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository) 
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<AuthenticationResult> Handle(LoginQuery command, CancellationToken cancellationToken)
    {
        //CHECK IF USER EXISTS
        if(_userRepository.GetUserByEmail(command.Email) is not User user)
        {
            throw new Exception("Usuário não encontrado. ");
        }

        //CHECK IF USER INFORMATION MATCHES WITH OUR DB
        if (user.Password != command.Password) 
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