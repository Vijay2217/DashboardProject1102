using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Dash.Models
{
    public class ProjectFiles
    {
        public int Id { get; set; }
        public String NameP { get; set; }
        public String Description { get; set; }
        

       [Required(ErrorMessage = "Please select file.")]
        [Display(Name = "Browse File")]
        public HttpPostedFileBase[] files { get; set; }

        
    }
}