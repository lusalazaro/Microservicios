namespace Users.Api.DTO
{
    public record UserDTO(Guid Id, string UserName, string Name, string Email);
    public record CreateUserRequest(string UserName, string Name, string? LastName, string Email, Guid ProfileId);
}
