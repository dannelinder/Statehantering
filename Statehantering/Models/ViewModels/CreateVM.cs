using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Statehantering.Models.ViewModels
{
    public class CreateVM
    {
        [Required]
        [EmailAddress]
        [Display(Name="Support E-mail")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        public string Name { get; set; }

    }
}
