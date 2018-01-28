using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel
{
    public class Context : DbContext
    {
        public Context()
        {
            //Database.SetInitializer(new CreateDatabaseIfNotExists<Context>()); // default behaviour
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
            Database.SetInitializer(new DropCreateDatabaseAlways<Context>());
        } 
        //public Context() : base("ComicBookGallery") { } // provide database name or connection string or add connection string with the context class name in the config file
        //public Context() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ComicBookGallery3;Integrated Security=True;MultipleActiveResultSets=True") { }
        public DbSet<ComicBook> ComicBooks { get; set; }
    }
}
