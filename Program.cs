var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DefaultConnectionSettings>(builder.Configuration.GetSection("DataSource"));
builder.Services.AddSingleton<BaseConnection<DefaultConnectionSettings>>();
builder.Services.AddSingleton<BaseRepository<User, DefaultConnectionSettings>>();
builder.Services.AddSingleton<UserService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapControllers();

app.Run();



// using Dapper;
// using Npgsql;

// var builder = WebApplication.CreateBuilder(args);

// var app = builder.Build();
// var connection = new NpgsqlConnection("Server=127.0.0.1;Port=32768;Database=sqlapp;User Id=postgres;Password=postgres;");
// connection.Open();

// var users = app.MapGroup("users");

// users.MapGet("/", async () =>
// {
//     return (await connection.QueryAsync<User>("SELECT * FROM users;")).ToList();
// });

// users.MapGet("/{id}", async (int id) =>
// {
//     return await connection.QuerySingleAsync<User>("SELECT * FROM users WHERE id = @Id", new { Id = id });
// });

// users.MapPost("/", async (User user) =>
// {
//     var affected = await connection.ExecuteAsync("INSERT INTO users (name, surname, username) VALUES (@Name, @Surname, @UserName);", user);
//     return Results.Created("Created", affected);
// });

// users.MapPatch("/{id}", async (int id, User user) =>
// {
//     var affected = await connection.ExecuteAsync("UPDATE users SET name = @Name, surname = @Surname, username = @UserName WHERE id = @Id;", new { Id = id, Name = user.Name, Surname = user.Surname, UserName = user.UserName });
//     return Results.Accepted("Updated", affected);
// });

// users.MapDelete("/{id}", async (int id) =>
// {
//     var affected = await connection.ExecuteAsync("DELETE FROM users WHERE id = @Id;", new { Id = id });
//     return Results.Ok("Deleted");
// });

// app.Run();
