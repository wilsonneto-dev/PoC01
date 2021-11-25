using MediatR;

namespace Classfy.Users.Application.UseCases.CreateUser;

public interface ICreateUserUseCase: IRequestHandler<CreateUserInput, CreateUserOutput>
{
    
}