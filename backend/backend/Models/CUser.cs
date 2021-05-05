using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace backend.Models
{
    public partial class CUser
    {
        public CUser()
        {
            Data = new HashSet<Datum>();
            Projects = new HashSet<Project>();
        }

        public long IdUser { get; set; }
        
        [Required]
        public string Username { get; set; }
       
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        public string Name { get; set; }
        public string Lastname { get; set; }

        public virtual ICollection<Datum> Data { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
