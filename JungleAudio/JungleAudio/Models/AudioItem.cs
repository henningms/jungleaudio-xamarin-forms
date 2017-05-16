using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JungleAudio.Models
{
    public class AudioItem
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string AuthorProfileUrl { get; set; }
        public string Category { get; set; }
        public string CategoryUrl { get; set; }
        public string PreviewUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Description { get; set; }
        public string DetailUrl { get; set; }
    }
}
