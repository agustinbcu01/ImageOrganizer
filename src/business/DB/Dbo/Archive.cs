using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.DB.Dbo
{
    public enum EArchiveStatus { Processced, Calculated, Dirty, Done, Duplicated}
    public class Archive : FolderEntry, IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public EArchiveStatus ArchiveStatus  { get;set;}
        public Enums Mediatype { get; set; }
        public string MetaDada { get; set; }
    }
}
