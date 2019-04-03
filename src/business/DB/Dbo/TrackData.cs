using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DB.Dbo
{
    public class TrackData
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
