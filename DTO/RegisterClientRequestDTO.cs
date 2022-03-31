using System.ComponentModel.DataAnnotations;

namespace ClientApi.DTO
{
    public class RegisterClientRequestDTO
    {

        [Required]
        public string Email { get; set; }
        
        [Required]
        [MinLength(10)]
        [MaxLength(25)]
        public string Secret { get; set; }
        
    }
}