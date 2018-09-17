using System.ComponentModel.DataAnnotations;

namespace AuditoriasCiudadanas.Api.Core.Entities
{
    public class LoginRequestEntity
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}