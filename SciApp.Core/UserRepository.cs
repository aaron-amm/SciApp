namespace SciApp.Core
{
    public interface IUserRepository
    {
        User GetUser(int id);
        void Add(User user);
    }
}