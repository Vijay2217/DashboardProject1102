using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Dash.Models
{
    public class LoginViewModel
    {
        [Required]
        public String UserID { get; set; }

        [Required]
        public String Password { get; set; }
    }
}