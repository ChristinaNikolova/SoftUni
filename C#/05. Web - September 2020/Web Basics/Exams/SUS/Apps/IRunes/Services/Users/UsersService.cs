using IRunes.Data;
using IRunes.Models;
using IRunes.ViewModels.Home;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace IRunes.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateUser(string username, string email, string password)
        {
            var user = new User
            {
                Email = email,
                Username = username,
                Password = ComputeHash(password),
            };

            db.Users.Add(user);
            db.SaveChanges();
        }

        public string GetUserId(string username, string password)
        {
            var passwordHash = ComputeHash(password);

            var user = db.Users
                .FirstOrDefault(x => x.Username == username && x.Password == passwordHash);

            if (user == null)
            {
                user = db.Users
               .FirstOrDefault(x => x.Email == username && x.Password == passwordHash);
            }

            return user?.Id;
        }

        public bool IsEmailAvailable(string email)
        {
            return !db.Users.Any(x => x.Email == email);
        }

        public bool IsUsernameAvailable(string username)
        {
            return !db.Users.Any(x => x.Username == username);
        }

        private static string ComputeHash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);

            using var hash = SHA512.Create();
            var hashedInputBytes = hash.ComputeHash(bytes);

            var hashedInputStringBuilder = new StringBuilder(128);

            foreach (var b in hashedInputBytes)
                hashedInputStringBuilder.Append(b.ToString("X2"));

            return hashedInputStringBuilder.ToString();
        }

        public HomeViewModel GetUsername(string userId)
        {
            var homeViewModel = this.db
                .Users
                .Where(u => u.Id == userId)
                .Select(u => new HomeViewModel()
                {
                    Username = u.Username,
                })
                .FirstOrDefault();

            return homeViewModel;
        }
    }
}
