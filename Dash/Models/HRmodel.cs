using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Dash.Models
{
    public class HRmodel : DbContext
    {
        public HRmodel():base ("name=ConDB")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<ProjectFiles> projectfiles { get; set; }
        public DbSet<FileUpload> fileupload { get; set; }
    }
}