using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using DvdLibraryWebAPI.Interfaces;
using DvdLibraryWebAPI.Models;
using DvdLibraryWebAPI.Repositories;

namespace DvdLibraryWebAPI.Factories
{
    public class RepositoryFactory
    {
        public static IRepository CreateRepository()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "SampleData":
                    return new DVDRepositoryMock();
                case "ADO":
                    return new DVDRepositoryADO();
                case "EntityFramework":
                    return new DVDRepositoryEF();
                default: throw new Exception("Mode value in app config is not valid.");
            }
        }
    }
}