namespace DvdLibraryWebAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DvdLibraryWebAPI.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<DvdLibraryWebAPI.Data.DVDIndexDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DvdLibraryWebAPI.Data.DVDIndexDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Ratings.AddOrUpdate(
                    r => r.Rating,
                    new RatingClass { Rating = "G" },
                    new RatingClass { Rating = "PG" },
                    new RatingClass { Rating = "PG-13" },
                    new RatingClass { Rating = "R" }
                );

            context.Directors.AddOrUpdate(
                    d => d.DirectorName,
                    new Director { DirectorName = "Test1" },
                    new Director { DirectorName = "Test2" },
                    new Director { DirectorName = "Test3" },
                    new Director { DirectorName = "Test4" }
                );
            //must create foreign key data first to avoid constraint violation
            context.SaveChanges();

            context.DVDS.AddOrUpdate(
                    d => d.Title,
                    new DVDEF
                    {
                        Title = "The Goonies",
                        RatingId = context.Ratings.First(r => r.Rating == "PG").RatingId,
                        DirectorId = context.Directors.First(d => d.DirectorName == "Test1").DirectorId,
                        ReleaseYear = 1985,
                        Notes = "A great movie"
                    },
                    new DVDEF
                    {
                        Title = "GhostBusters",
                        RatingId = context.Ratings.First(r => r.Rating == "PG-13").RatingId,
                        DirectorId = context.Directors.First(d => d.DirectorName == "Test2").DirectorId,
                        ReleaseYear = 1984,
                        Notes = "A great movie"
                    }

                );
        }
    }
}
