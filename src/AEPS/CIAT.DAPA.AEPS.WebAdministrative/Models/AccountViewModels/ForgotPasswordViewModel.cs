using CIAT.DAPA.AEPS.WebAdministrative.Resources.Views.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CIAT.DAPA.AEPS.WebAdministrative.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(ForgotPassword))]
        public string Email { get; set; }
    }
}
