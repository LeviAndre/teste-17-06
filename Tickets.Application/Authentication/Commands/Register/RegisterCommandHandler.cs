using MediatR;
using Tickets.Application.Authentication.Common;
using Tickets.Application.Common.Interfaces.Authentication;
using Tickets.Application.Common.Interfaces.Persistence;
using Tickets.Domain.Entities;

namespace Tickets.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository) 
    {
        _jwtTokenGenerator = jwtTokenGenerator;

        _userRepository = userRepository;
    }

    public async Task<AuthenticationResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        //CHECK USER EXISTENCE
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            throw new Exception("Email já cadastrado. ");
        }

        //CREATE USER
        var user = new User{
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
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