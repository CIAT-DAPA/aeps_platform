using CIAT.DAPA.AEPS.WebAdministrative.Resources.Views.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CIAT.DAPA.AEPS.WebAdministrative.Models.AccountViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(ResetPassword))]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceName = "PasswordLengthMessage", ErrorMessageResourceType = typeof(Register), MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(ResetPassword))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessageResourceName = "PasswordConfirmMessage", ErrorMessageResourceType = typeof(Register))]
        [Display(Name = "PasswordConfirm", ResourceType = typeof(ResetPassword))]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}
