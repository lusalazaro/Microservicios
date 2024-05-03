namespace Users.Api.Models
{
    public class Profile
    {
        public Guid Id { get; set; } = new Guid();
        public string? Name { get; set; }

        public ICollection<User>? Users { get; set; }

        public Profile() { }
        public Profile(string? name)
        {
            Name = name;
        }
    }
}
