﻿using System;
using System.Collections.Generic;

#nullable disable

namespace collabtag_backend.Models
{
    public partial class CUser
    {
        public CUser()
        {
            Data = new HashSet<Datum>();
            Projects = new HashSet<Project>();
        }

        public long IdUser { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }

        public virtual ICollection<Datum> Data { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
