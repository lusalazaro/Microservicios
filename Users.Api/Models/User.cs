namespace Users.Api.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserName { get; set; }
        public string Name { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public Guid ProfileId { get; set; }
        public Profile? Profile { get; set; }

        public User() { }
        public User(string username, string name, string? lastName, string email, Guid profileId)
        {
            UserName = username;
            Name = name;
            LastName = lastName;
            Email = email;
            ProfileId = profileId;
        }
    }
}
