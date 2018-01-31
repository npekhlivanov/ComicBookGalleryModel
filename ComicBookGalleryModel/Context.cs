using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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
            //Database.SetInitializer(new DropCreateDatabaseAlways<Context>());
            Database.SetInitializer(new DatabaseInitializer());

            this.Configuration.LazyLoadingEnabled = false; // Turn off lazy loading for all entities
        } 
        //public Context() : base("ComicBookGallery") { } // provide database name or connection string or add connection string with the context class name in the config file
        //public Context() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ComicBookGallery3;Integrated Security=True;MultipleActiveResultSets=True") { }

        public DbSet<ComicBook> ComicBooks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Conventions.Remove<DecimalPropertyConvention>();
            //modelBuilder.Conventions.Add(new DecimalPropertyConvention(5, 2));
            modelBuilder.Entity<ComicBook>() // use this mechanism to specify individual column properties
                .Property(cb => cb.AverageRating)
                .HasPrecision(5, 2);
        }
    }
}
