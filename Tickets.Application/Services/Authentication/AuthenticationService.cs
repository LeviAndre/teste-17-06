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

    public async Task<AuthenticationResult> Login(string email, string password)
    {
        //CHECK IF USER EXISTS
        User user = await _userRepository.GetUserByEmail(email);

        if(user is not User)
        {
            throw new Exception("User not found. ");
        }

        //CHECK IF USER INFORMATION MATCHES WITH OUR DB
        if (user.Password != password) 
        {
            throw new Exception("Incorrect password. ");
        };

        //GENERATE JWT TOKEN
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user, 
            token
        );
    }

    public async Task<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        //CHECK USER EXISTENCE
        if (await _userRepository.GetUserByEmail(email) is not null)
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

        await _userRepository.Add(user);

        //GENERATE JWT TOKEN
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user, 
            token
        );
    }
}