using DvdLibraryWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibraryWebAPI.Interfaces
{
    public interface IRepository
    {
        List<DVD> GetAll();
        DVD GetById(int id);
        DVD GetByTitle(string title);
        List<DVD> GetByYear(int year);
        List<DVD> GetByDirector(string director);
        List<DVD> GetByRating(string rating);
        List<DVD> AddDVD(DVD dvd);
        List<DVD> EditDVD(DVD original, DVD updated);
        List<DVD> DeleteDVD(int id);
    }
}
