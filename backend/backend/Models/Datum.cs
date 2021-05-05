using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class Datum
    {
        public long IdData { get; set; }
        public byte[] Image { get; set; }
        public DateTime Date { get; set; }
        public long IdUser { get; set; }
        public long IdClass { get; set; }
        public long IdProject { get; set; }

        public virtual Class IdClassNavigation { get; set; }
        public virtual Project IdProjectNavigation { get; set; }
        public virtual CUser IdUserNavigation { get; set; }
    }
}
