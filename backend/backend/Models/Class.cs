using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class Class
    {
        public Class()
        {
            Data = new HashSet<Datum>();
        }

        public long IdClass { get; set; }
        public string Name { get; set; }
        public long IdProject { get; set; }

        public virtual Project IdProjectNavigation { get; set; }
        public virtual ICollection<Datum> Data { get; set; }
    }
}
