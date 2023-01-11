using Dapper;
using Sign_up_Form.Models;
using System.Data;
using System.Data.SqlClient;

namespace Sign_up_Form.Services.UserService
{
    public partial class UserService : IUserService
    {
        private readonly string? connectionString;

        public UserService(string connectionString) =>
            this.connectionString = connectionString;

        public async ValueTask<IDbConnection> CreateConnectionAsync()
        {
            var con = new SqlConnection(connectionString);
            await con.OpenAsync();

            return con;
        }

        public async ValueTask<int> AddUserAsync(User user)
        {
            try
            {
                using var con = await CreateConnectionAsync();

                await ValidateUserOnCreateAsync(con, user);

                var result = await con.ExecuteAsync("dbo.AddUser", user,
                commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async ValueTask<IEnumerable<UserDto>> RetrieveUsersAsync()
        {
            try
            {
                using var con = await CreateConnectionAsync();

                var result = await con.QueryAsync<UserDto>("dbo.RetrieveUsers", null,
                    commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}