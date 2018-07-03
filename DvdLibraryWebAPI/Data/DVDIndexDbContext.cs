using DvdLibraryWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace DvdLibraryWebAPI.Data
{
    public class DVDIndexDbContext :DbContext
    {
        public DVDIndexDbContext() : base("DefaultConnection")
        {

        }

        public DbSet<DVDEF> DVDS { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<RatingClass> Ratings { get; set; }
    }
}