public class UserService
{
    private readonly BaseRepository<User, DefaultConnectionSettings> _userRepository;

    public UserService(BaseRepository<User, DefaultConnectionSettings> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<User>> Get() =>
        await _userRepository.QueryMany("SELECT * FROM users;", null);

    public async Task<User?> GetOne(int id) =>
        await _userRepository.QueryOne("SELECT * FROM users WHERE id = @Id;", new { Id = id });

    public async Task Insert(User user) =>
        await _userRepository.Execute("INSERT INTO users (name, surname, username) VALUES (@Name, @Surname, @UserName);", user);

    public async Task Update(int id, User user) =>
        await _userRepository.Execute("UPDATE users SET name = @Name, surname = @Surname, username = @UserName WHERE id = @Id;", new { Id = id, Name = user.Name, Surname = user.Surname, UserName = user.UserName });

    public async Task Delete(int id) =>
        await _userRepository.Execute("DELETE FROM users WHERE id = @Id", new { Id = id });
}