using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel.Models
{
    //[Table("ComicBooks")] // use to specify table name
    public class ComicBook
    {
        public ComicBook()
        {
            Artists = new List<ComicBookArtist>();
        }

        //[Key] // use to specify PK column if name does not match the default patterns
        //[Column(Order = 1)] // use for composite keys to specify ordering
        public int Id { get; set; } // EF will assume the following names are also PK columns: ID, ComicBookId, ComicBookID
        public int SeriesId { get; set; } // EF will assume this is an FK -> navigation property name + "Id"
        //[Required] // use to specify required property /column value
        public int IssueNumber { get; set; }
        public string Description { get; set; }
        //[Index] // (EF6.1+) use to specify an index column; By default, the index will be named IX_<property name>
        public DateTime PublishedOn { get; set; }
        public decimal? AverageRating { get; set; }

        public Series Series { get; set; }
        public ICollection<ComicBookArtist> Artists { get; set; } // Lazy loading for this is property is turned off by making it non-virtual

        public string DisplayText
        {
            get
            {
                return $"{Series?.Title} #{IssueNumber}";
            }
        }

        public void AddArtist(Artist artist, Role role)
        {
            Artists.Add(new ComicBookArtist()
            {
                Artist = artist,
                Role = role
            });
        }
    }
}
