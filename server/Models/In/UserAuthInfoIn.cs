namespace server.Models.In;

public record UserAuthInfoIn {
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
