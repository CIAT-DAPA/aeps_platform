using CIAT.DAPA.AEPS.WebAdministrative.Resources.Views.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CIAT.DAPA.AEPS.WebAdministrative.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(Login))]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Login))]
        public string Password { get; set; }

        [Display(Name = "Remember", ResourceType = typeof(Login))]
        public bool RememberMe { get; set; }
    }
}
