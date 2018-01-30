using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel.Models
{
    // use [Table("Talent")] to specify different table name
    public class Artist
    {
        public Artist()
        {
            ComicBooks = new List<ComicBookArtist>();
        }
        public int Id { get; set; }
        [Required, StringLength(100)] // use Column("FullName") to specify different column name
        public string Name { get; set; }
        public ICollection<ComicBookArtist> ComicBooks { get; set; }
    }
}
