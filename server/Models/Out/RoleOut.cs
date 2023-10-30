namespace server.Models.Out;
public record RoleIn {
    public string Id { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;

    public RoleIn(string id, string name) {
        Id = id;
        Name = name;
    }
}
