namespace Users.Api.DTO
{
    public record ProfileDTO(Guid Id, string? Name);
    public record ProfileRequest(string? Name);
}
