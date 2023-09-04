using Microsoft.AspNetCore.Mvc;

[Route("v1/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<List<User>> Get() =>
        await _userService.Get();

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetOne(int id)
    {
        var user = await _userService.GetOne(id);
        if (user is null) return NotFound();
        return user;
    }

    [HttpPost]
    public async Task Insert(User user) =>
        await _userService.Insert(user);

    [HttpPatch("{id}")]
    public async Task Update(int id, User user) =>
        await _userService.Update(id, user);

    [HttpDelete("{id}")]
    public async Task Delete(int id) =>
        await _userService.Delete(id);
}