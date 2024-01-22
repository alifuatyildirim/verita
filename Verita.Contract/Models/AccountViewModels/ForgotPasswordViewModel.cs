using System.ComponentModel.DataAnnotations;

namespace Verita.Contract.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
