using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dash.Models
{
    public class User
    {
        public int Id { get; set; }

        [RegularExpression("^[a-zA-Z]{2,30}$", ErrorMessage = "Too Short or long name")]
        public String FirstName { get; set; }

        [RegularExpression("^[a-zA-Z]{2,30}$", ErrorMessage = "Too Short or long name")]
        public String LastName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public String UserID { get; set; }

        [RegularExpression("^[0-9]{4}$", ErrorMessage = "Invalid Password")]
        public String Password { get; set; }

        [Display(Name = "Confirm Password", Prompt = "Re-enter Password")]
        [Compare("Password", ErrorMessage = "Password donot match!")]
        public String ConfirmPassword { get; set; }

    }

}