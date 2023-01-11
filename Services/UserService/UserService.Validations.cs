using Dapper;
using Sign_up_Form.Models;
using System.Data;

namespace Sign_up_Form.Services.UserService
{
    public partial class UserService
    {
        public static void ValidateUserNullable(User user)
        {
            if (user is null)
                throw new NullReferenceException("User is null");
        }

        public static async Task ValidateUserOnCreateAsync(IDbConnection connection, User user)
        {
            ValidateUserNullable(user);

            var isUserExist = (await connection.QueryAsync("dbo.ValidateUserOnCreate",
                new { user.EmailAddress },
                commandType: CommandType.StoredProcedure)).Any();

            if (isUserExist)
                throw new DuplicateNameException($"User With EmailAddress: " +
                $"{user.EmailAddress} Is Already Existed.");
        }
    }
}
