using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class Member
    {
        public long IdUser { get; set; }
        public long IdProject { get; set; }
        public DateTime Date { get; set; }

        public virtual Project IdProjectNavigation { get; set; }
        public virtual CUser IdUserNavigation { get; set; }
    }
}
