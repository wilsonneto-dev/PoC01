using Classfy.Users.Application.Interfaces;
using Classfy.Users.Domain.Exceptions;
using Classfy.Users.Domain.User;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Classfy.Users.Application.UseCases.CreateUser;

public class CreateUserUseCase: ICreateUserUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unityOfWork;

    public CreateUserUseCase(ILogger<CreateUserUseCase> logger, IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _unityOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(userRepository));
    }

    public async Task<CreateUserOutput> Handle(CreateUserInput request, CancellationToken cancellationToken)
    {
        User? userWithSameEmailRegistered = await _userRepository.FindByEmail(request.Email);
        if (userWithSameEmailRegistered != null)
            throw new ConflictException($"E-mail already registered: {request.Email}");

        User user = new User(request.Name, new Email(request.Email), request.Password);
        
        await _userRepository.Add(user);
        await _unityOfWork.Commit();

        return new CreateUserOutput()
        {
            Id = user.Id,
            Email = user.Email.ToString()
        };
    }
}