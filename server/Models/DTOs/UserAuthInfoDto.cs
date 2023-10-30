namespace server.Models.DTOs;

public record UserAuthInfoDto
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
