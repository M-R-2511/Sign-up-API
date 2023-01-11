using Sign_up_Form.Controllers;
using Sign_up_Form.Services.UserService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(o =>
    new UserService(builder.Configuration.GetConnectionString("DB") ?? ""));

var app = builder.Build();

// Endpoints Definitions
app.DefineEndpoints();

if (app.Environment.IsDevelopment())
    app.UseSwagger().UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
