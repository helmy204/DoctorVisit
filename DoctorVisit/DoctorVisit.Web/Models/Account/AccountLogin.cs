using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorVisit.Web.Models.Account
{
    public partial class AccountLogin
    {
        [Required]
        public string UsernameOrEmail { get; set; }

        [Required]
        public string Password { get; set; }
    }
}