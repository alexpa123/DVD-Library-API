using DvdLibraryWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdLibraryWebAPI.Models
{
    public class DVDRepositoryMock : IRepository
    {
        private static List<DVD> _dvds;

        static DVDRepositoryMock()
        {
            _dvds = new List<DVD>()
            {
                new DVD { DvdId = 1, Rating="PG", DirectorName="Test1", Title="The Goonies", ReleaseYear=1988, Notes="Best movie ever" },
                new DVD { DvdId = 2, Rating="PG", DirectorName="Test2", Title="GhostBusters", ReleaseYear=1985, Notes="A great movie." }
            };
        }

        public List<DVD> GetAll()
        {
            return _dvds;
        }

        public DVD GetById(int id)
        {
            return _dvds.Where(d => d.DvdId == id).FirstOrDefault();
        }

        public DVD GetByTitle(string title)
        {
            return _dvds.Where(d => d.Title == title).FirstOrDefault();
        }

        public List<DVD> GetByYear(int year)
        {
            return _dvds.Where(d => d.ReleaseYear == year).ToList();
        }

        public List<DVD> GetByDirector(string director)
        {
            return _dvds.Where(d => d.DirectorName == director).ToList();
        }

        public List<DVD> GetByRating(string rating)
        {
            return _dvds.Where(d => d.Rating == rating).ToList();
        }

        public List<DVD> AddDVD(DVD dvd)
        {
            DVD dvdToAdd = new DVD();
            dvdToAdd.DvdId = _dvds.Max(d => d.DvdId) + 1;
            dvdToAdd.DirectorName = dvd.DirectorName;
            dvdToAdd.Rating = dvd.Rating;
            dvdToAdd.Title = dvd.Title;
            dvdToAdd.ReleaseYear = dvd.ReleaseYear;
            dvdToAdd.Notes = dvd.Notes;
            _dvds.Add(dvdToAdd);
            return _dvds;
        }

        public List<DVD> EditDVD(DVD original, DVD updated)
        {
            updated.DvdId = original.DvdId;
            int i = _dvds.FindIndex(d => d.DvdId == original.DvdId);
            _dvds[i] = updated;
            return _dvds;
        }

        public List<DVD> DeleteDVD(int id)
        {
            int i = _dvds.FindIndex(d => d.DvdId == id);
            _dvds.RemoveAt(i);
            return _dvds;
        }
    }
}