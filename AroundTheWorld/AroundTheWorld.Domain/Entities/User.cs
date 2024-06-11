using System.ComponentModel.DataAnnotations;

namespace AroundTheWorld.Domain.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public float Rating { get; set; }
        public string? AboutMe { get; set; }
        public string Country { get; set; }
    }
}
