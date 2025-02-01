using System.ComponentModel.DataAnnotations;

namespace Teste_001.Application.ViewModels
{
    public class LoginRequestModel
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
