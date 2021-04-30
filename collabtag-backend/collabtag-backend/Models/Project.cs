using System;
using System.Collections.Generic;

#nullable disable

namespace collabtag_backend.Models
{
    public partial class Project
    {
        public Project()
        {
            Classes = new HashSet<Class>();
            Models = new HashSet<Model>();
        }

        public long IdProject { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public long IdUser { get; set; }

        public virtual CUser IdUserNavigation { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Model> Models { get; set; }
    }
}
