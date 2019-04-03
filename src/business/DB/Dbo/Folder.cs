using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.DB.Dbo
{

    public enum FolderStatus { Discovering, Discovered, Processing, Done, Dirty}
    public class Folder : FolderEntry, IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public EFolderStatus Status { get; set; }
        public EFolderType FolderType { get; set; }
        public virtual IEnumerable<Archive> Archives { get; set; }
        public virtual IEnumerable<Folder> Folders { get; set; }
    }
}
