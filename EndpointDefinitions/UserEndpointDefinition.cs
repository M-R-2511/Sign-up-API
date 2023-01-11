using Microsoft.AspNetCore.Mvc;
using Sign_up_Form.Models;
using Sign_up_Form.Services.UserService;

namespace Sign_up_Form.Controllers
{
    public static class UserEndpointDefinition
    {
        public static WebApplication DefineEndpoints(this WebApplication app)
        {
            app.MapGet("api/User/GetUsers",
                async ([FromServices] UserService userService) =>
                await userService.RetrieveUsersAsync());

            app.MapPost("api/User/AddUser",
                async ([FromServices] UserService userService, User user) =>
            {
                await userService.AddUserAsync(user);

                string Message = $"{user.FirstName} {user.LastName} has been added successfully.";

                return Results.Ok(Message);
            });

            return app;
        }
    }
}
