using IRunes.ViewModels.Home;

namespace IRunes.Services.Users
{
    public interface IUsersService
    {
        void CreateUser(string username, string email, string password);

        string GetUserId(string username, string password);

        bool IsUsernameAvailable(string username);

        bool IsEmailAvailable(string email);

        HomeViewModel GetUsername(string userId);
    }
}
