using System.ComponentModel.DataAnnotations;
namespace OcelotApiGw.Model
{
    public class AuthUser
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
