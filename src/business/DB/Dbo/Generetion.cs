using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DB.Dbo
{
    public enum EGenerationStatus { Discovering, Calculated, Done, Fail}
    public class Generetion : TrackData, IEntity<int>
    {
        public int Id { get;  set; }
        public DateTime StartAt { get; set; }
        public EGenerationStatus Status { get; set; }
        public IEnumerable<Archive> Archives { get; set; }
        public int ImagesCount { get; set; } 
        public int VideosCount { get; set; }
        public IEnumerable<Folder> Folders { get; set; }
    }
}
