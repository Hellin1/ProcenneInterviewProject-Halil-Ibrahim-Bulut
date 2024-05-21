
using Application.Enums;

namespace Application.Dto;
public class UserDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public bool IsExist { get; set; }
    public SignInResultType SignInResult { get; set; }
}
