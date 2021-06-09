using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class CUser
    {
        public CUser()
        {
            Data = new HashSet<Datum>();
            Members = new HashSet<Member>();
            Projects = new HashSet<Project>();
        }

        public string IdUser { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }

        public virtual ICollection<Datum> Data { get; set; }
        public virtual ICollection<Member> Members { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
