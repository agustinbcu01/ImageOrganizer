using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.DB.Dbo
{
    public class FolderEntry: TrackData
    {
               
        public string Name { get; set; }
        public string Path { get; set; }
        
        public virtual string Crc { get; set; }
        public DateTime EntryCreateAt { get; set; }
        public DateTime EntryModifiedAt { get; set; }

    }
}
