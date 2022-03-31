using ClientApi.DTO.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ClientApi.DTO
{
    public class RegisterUserRequestDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(25)]
        public string Password { get; set; }

        [NonEmptyGuidAttribute]
        public Guid ClientId { get; set; }
    }
}
