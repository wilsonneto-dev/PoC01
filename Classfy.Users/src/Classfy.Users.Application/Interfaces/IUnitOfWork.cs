namespace Classfy.Users.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
