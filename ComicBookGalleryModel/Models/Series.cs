using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel.Models
{
    public class Series
    {
        public Series()
        {
            ComicBooks = new List<ComicBook>();
        }

        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Title { get; set; }
        //[CaseSensitive] // use the attribute, defined in OnModelCreating()
        public string Description { get; set; }

        public ICollection<ComicBook> ComicBooks { get; set; }
    }
}
