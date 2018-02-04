using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ComicBookGalleryModel.Models;
using System.Diagnostics;

namespace ComicBookGalleryModel
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                context.Database.Log = (message) => Debug.WriteLine(message);

                //var comicBooksQuery = from cb in context.ComicBooks select cb;
                //var comicBooks = comicBooksQuery
                //    .Include(cb => cb.Series)
                //    //.Where(cb => cb.IssueNumber == 1 && cb.Series.Title.EndsWith("Man"))
                //    .OrderByDescending(cb => cb.IssueNumber)
                //    .ThenByDescending(cb => cb.PublishedOn)
                //    .ToList();

                //var comicBooksQuery = context.ComicBooks
                //    .Include(cb => cb.Series)
                //    .OrderBy(cb => cb.Series.Title);
                //var comicBooks = comicBooksQuery
                //    .Where(cb => cb.AverageRating < 7).ToList();

                var comicBookId = 1;
                //var comicBook1 = context.ComicBooks.Find(comicBookId);
                //var comicBook2 = context.ComicBooks.Find(comicBookId); // no second query is executed
                // Find() will return newly created entities (DbSet.Add()) that have not been persisted

                // DbSet queries
                var comicBook1 = context.ComicBooks
                //    //.Include(cb => cb.Artists.Select(a => a.Artist))
                //    //.Include(cb => cb.Artists.Select(a => a.Role))
                    .SingleOrDefault(cb => cb.Id.Equals(comicBookId));
                var comicBook2 = context.ComicBooks
                    .SingleOrDefault(cb => cb.Id == comicBookId); // second query is executed
                // DbSet queries can be used with Eager loading

                //var comicBooks = context.ComicBooks
                //    //.Include(cb => cb.Series) // Eager loading: (+)fewer queries (-)may load more data than needed
                //    //.Include(cb => cb.Artists.Select(a => a.Artist))
                //    //.Include(cb => cb.Artists.Select(a => a.Role))
                //    .ToList();

                //foreach (var comicBook in comicBooks)
                //{
                //    // Explicit loading of the Series navigation property: (+)exact control over the loading process, load just part of a collection (-)requires thought and planning
                //    if (comicBook.Series == null) 
                //    {
                //        context.Entry(comicBook).Reference(cb => cb.Series).Load();
                //    }

                //    // Lazy loading of Artists: (+)easy to use, only load needed data (-)can result in a lot of queries
                //    var artistRoleNames = comicBook.Artists.Select(a => $"{a.Artist.Name} ({a.Role.Name})").Where(n => n.Length > 1).ToArray();
                //    var artists = string.Join(", ", artistRoleNames);
                //    Console.WriteLine("{0} {1:dd.MM.yyyy}; Artists: {2}", comicBook.DisplayText, comicBook.PublishedOn, artists);
                //}

                Console.ReadLine();
                
            }
        }
    }
}
