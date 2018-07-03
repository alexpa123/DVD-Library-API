using DvdLibraryWebAPI.Factories;
using DvdLibraryWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DvdLibraryWebAPI.Models.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DVDController : ApiController
    {
        IRepository _repository = RepositoryFactory.CreateRepository();

        // GET api/<controller>
        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult All()
        {
            return Ok(_repository.GetAll());
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDVDById(int id)
        {
            DVD dvd = _repository.GetById(id);

            if (dvd == null)
            {
                return NotFound();
            }
            return Ok(dvd);
        }

        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDVDSByTitle(string title)
        {
            var dvd = _repository.GetByTitle(title);

            if (dvd == null)
            {
                return NotFound();
            }
            return Ok(dvd);
        }

        [Route("dvds/year/{year}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDVDSByYear(int year)
        {
            List<DVD> dvdList = _repository.GetByYear(year);

            if (dvdList == null)
            {
                return NotFound();
            }
            return Ok(dvdList);
        }

        [Route("dvds/director/{director}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDVDSByDirector(string director)
        {
            List<DVD> dvdList = _repository.GetByDirector(director);

            if (dvdList == null)
            {
                return NotFound();
            }
            return Ok(dvdList);
        }

        [Route("dvd/add")]
        [AcceptVerbs("POST")]
        [HttpPost]
        public IHttpActionResult AddDVD(DVD model)
        {
            //return Ok(_repository.AddDVD(dvd));

            List<DVD> dvdList = _repository.AddDVD(model);
            return Ok(dvdList);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("PUT")]
        [HttpPut]
        public IHttpActionResult EditDVD(int id, DVD updated)
        {
            DVD original = _repository.GetAll().Where(d => d.DvdId == id).FirstOrDefault();
            if (original == null)
            {
                return NotFound();
            }
            List<DVD> dvdList = _repository.EditDVD(original, updated);

            return Ok(dvdList);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("DELETE")]
        [HttpDelete]
        public IHttpActionResult DeleteDVD(int id)
        {
            var exists = _repository.GetAll().Any(d => d.DvdId == id);
            if (!exists)
            {
                return NotFound();
            }
            List<DVD> dvdList = _repository.DeleteDVD(id);
            return Ok(dvdList);

        }

    }
}