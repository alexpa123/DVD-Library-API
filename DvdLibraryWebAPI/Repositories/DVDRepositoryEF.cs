using DvdLibraryWebAPI.Data;
using DvdLibraryWebAPI.Interfaces;
using DvdLibraryWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DvdLibraryWebAPI.Repositories
{
    public class DVDRepositoryEF : IRepository
    {
        private DVDIndexDbContext db = new DVDIndexDbContext();


        public List<DVD> GetAll()
        {
            var repository = new DVDIndexDbContext();

            var DVD = from movie in repository.DVDS
                      select new DVD
                      {
                          DvdId = movie.DvdId,
                          Rating = movie.Rating.Rating,
                          DirectorName = movie.Director.DirectorName,
                          Title = movie.Title,
                          ReleaseYear = movie.ReleaseYear,
                          Notes = movie.Notes
                      };
            return DVD.ToList();
        }

        public DVD GetById(int id)
        {
            var repository = new DVDIndexDbContext();

            var findDvd = repository.DVDS.Find(id);
            DVD dvd = new DVD();
            if (findDvd != null)
            {
                dvd.DvdId = findDvd.DvdId;
                dvd.Rating = findDvd.Rating.Rating;
                dvd.DirectorName = findDvd.Director.DirectorName;
                dvd.Title = findDvd.Title;
                dvd.ReleaseYear = findDvd.ReleaseYear;
                dvd.Notes = findDvd.Notes;
                return dvd;
            }
            else
            {
                dvd.Title = "Not Found";
                return dvd;
            }
        }

        public DVD GetByTitle(string title)
        {
            var repository = new DVDIndexDbContext();

            var findDvd = repository.DVDS.Where(d => d.Title.Contains(title)).FirstOrDefault();
            DVD dvd = new DVD();
            if (findDvd != null)
            {
                dvd.DvdId = findDvd.DvdId;
                dvd.Rating = findDvd.Rating.Rating;
                dvd.DirectorName = findDvd.Director.DirectorName;
                dvd.Title = findDvd.Title;
                dvd.ReleaseYear = findDvd.ReleaseYear;
                dvd.Notes = findDvd.Notes;
                return dvd;
            }
            else
            {
                dvd.Title = "Not Found";
                return dvd;
            }
        }

        public List<DVD> GetByYear(int year)
        {
            var repository = new DVDIndexDbContext();

            var DVD = from movie in repository.DVDS
                      where movie.ReleaseYear == year
                      select new DVD
                      {
                          DvdId = movie.DvdId,
                          Rating = movie.Rating.Rating,
                          DirectorName = movie.Director.DirectorName,
                          Title = movie.Title,
                          ReleaseYear = movie.ReleaseYear,
                          Notes = movie.Notes
                      };
            return DVD.ToList();
        }

        public List<DVD> GetByDirector(string director)
        {
            var repository = new DVDIndexDbContext();

            var DVD = from movie in repository.DVDS
                      where movie.Director.DirectorName == director
                      select new DVD
                      {
                          DvdId = movie.DvdId,
                          Rating = movie.Rating.Rating,
                          DirectorName = movie.Director.DirectorName,
                          Title = movie.Title,
                          ReleaseYear = movie.ReleaseYear,
                          Notes = movie.Notes
                      };
            return DVD.ToList();
        }

        public List<DVD> GetByRating(string rating)
        {
            var repository = new DVDIndexDbContext();

            var DVD = from movie in repository.DVDS
                      where movie.Rating.Rating == rating
                      select new DVD
                      {
                          DvdId = movie.DvdId,
                          Rating = movie.Rating.Rating,
                          DirectorName = movie.Director.DirectorName,
                          Title = movie.Title,
                          ReleaseYear = movie.ReleaseYear,
                          Notes = movie.Notes
                      };
            return DVD.ToList();
        }

        public List<DVD> AddDVD(DVD dvd)
        {
            var repository = new DVDIndexDbContext();
            var director = repository.Directors.FirstOrDefault(d => d.DirectorName == dvd.DirectorName);
            if (director == null)
            {
                director = repository.Directors.Add(new Director { DirectorName = dvd.DirectorName });
            }
            var rating = repository.Ratings.FirstOrDefault(r => r.Rating == dvd.Rating);
            if (rating == null)
            {
                rating = repository.Ratings.Add(new RatingClass { Rating = dvd.Rating });
            }
            var update = repository.DVDS.Add(
                new DVDEF
                {
                    RatingId = rating.RatingId,
                    DirectorId = director.DirectorId,
                    Title = dvd.Title,
                    ReleaseYear = dvd.ReleaseYear,
                    Notes = dvd.Notes
                    
                });
            repository.SaveChanges();

            return GetAll();
        }

        public List<DVD> EditDVD(DVD original, DVD updated)
        {
            var repository = new DVDIndexDbContext();
            var director = repository.Directors.FirstOrDefault(d => d.DirectorName == updated.DirectorName);
            if (director == null)
            {
                director = repository.Directors.Add(new Director { DirectorName = updated.DirectorName });
            }
            var rating = repository.Ratings.FirstOrDefault(r => r.Rating == updated.Rating);
            if (rating == null)
            {
                rating = repository.Ratings.Add(new RatingClass { Rating = updated.Rating });
            }
            var update =
                new DVDEF
                {
                    DvdId = original.DvdId,
                    RatingId = rating.RatingId,
                    DirectorId = director.DirectorId,
                    Title = updated.Title,
                    ReleaseYear = updated.ReleaseYear,
                    Notes = updated.Notes

                };
            repository.Entry(update).State = EntityState.Modified;
            repository.SaveChanges();

            return GetAll();
        }

        public List<DVD> DeleteDVD(int id)
        {
            var repository = new DVDIndexDbContext();
            var dvd = repository.DVDS.Find(id);
            repository.DVDS.Remove(dvd);
            repository.SaveChanges();
            return GetAll();
        }
    }
}