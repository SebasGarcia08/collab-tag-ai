using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class Model
    {
        public long IdModel { get; set; }
        public byte[] File { get; set; }
        public float? Accuracy { get; set; }
        public DateTime Date { get; set; }
        public long IdProject { get; set; }

        public virtual Project IdProjectNavigation { get; set; }
    }
}
