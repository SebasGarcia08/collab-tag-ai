using System;

namespace backend.Models
{
    public class Photo
    {
        //public long IdData { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
        public long IdProject { get; set; }
        public string IdUser { get; set; }
        
        //public long IdClass { get; set; }

        
    }
}