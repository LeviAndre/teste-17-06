using Tickets.Application.Common.Interfaces.Authentication;
using Tickets.Application.Common.Interfaces.Persistence;
using Tickets.Contracts.Authentication.Common;
using Tickets.Domain.Entities;

namespace Tickets.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService 
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository) 
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

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //CHECK USER EXISTENCE
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("Email já cadastrado. ");
        }

        //CREATE USER
        var user = new User{
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        //GENERATE JWT TOKEN
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user, 
            token
        );
    }
}