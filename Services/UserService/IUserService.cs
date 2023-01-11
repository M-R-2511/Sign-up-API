using Sign_up_Form.Models;

namespace Sign_up_Form.Services.UserService
{
    public interface IUserService
    {
        static string? ConnectionString { get; set; }
        ValueTask<int> AddUserAsync(User user);
        ValueTask<IEnumerable<UserDto>> RetrieveUsersAsync();
    }
}
