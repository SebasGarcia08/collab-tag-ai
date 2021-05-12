using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class Project
    {
        public Project()
        {
            Classes = new HashSet<Class>();
            Data = new HashSet<Datum>();
            Members = new HashSet<Member>();
            Models = new HashSet<Model>();
        }

        public long IdProject { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string IdUser { get; set; }

        public virtual CUser IdUserNavigation { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Datum> Data { get; set; }
        public virtual ICollection<Member> Members { get; set; }
        public virtual ICollection<Model> Models { get; set; }
    }
}
