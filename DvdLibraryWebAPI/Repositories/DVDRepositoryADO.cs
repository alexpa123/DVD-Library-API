using DvdLibraryWebAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using DvdLibraryWebAPI.Interfaces;

namespace DvdLibraryWebAPI.Models
{
    public class DVDRepositoryADO : IRepository
    {
        public List<DVD> GetAll()
        {
            List<DVD> dvds = new List<DVD>();

            using (var connection = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand command = new SqlCommand("SelectAllDvds", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                using(SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        DVD currentRow = new DVD();
                        currentRow.DvdId = (int)dataReader["DvdId"];
                        currentRow.Rating = dataReader["Rating"].ToString();
                        currentRow.DirectorName = dataReader["DirectorName"].ToString();
                        currentRow.Title = dataReader["Title"].ToString();
                        currentRow.ReleaseYear = (int)dataReader["ReleaseYear"];
                        currentRow.Notes = dataReader["Notes"].ToString();
                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }

        public DVD GetById(int id)
        {
            DVD currentRow = new DVD();

            using (var connection = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand command = new SqlCommand("SelectDVDById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@DvdId", id);

                connection.Open();

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        
                        currentRow.DvdId = (int)dataReader["DvdId"];
                        currentRow.Rating = dataReader["Rating"].ToString();
                        currentRow.DirectorName = dataReader["DirectorName"].ToString();
                        currentRow.Title = dataReader["Title"].ToString();
                        currentRow.ReleaseYear = (int)dataReader["ReleaseYear"];
                        currentRow.Notes = dataReader["Notes"].ToString();

                    }
                }
            }
            return currentRow;
        }

        public DVD GetByTitle(string title)
        {
            DVD currentRow = new DVD();
            using (var connection = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand command = new SqlCommand("SelectDVDByTitle", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Title", title);

                connection.Open();

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        
                        currentRow.DvdId = (int)dataReader["DvdId"];
                        currentRow.Rating = dataReader["Rating"].ToString();
                        currentRow.DirectorName = dataReader["DirectorName"].ToString();
                        currentRow.Title = dataReader["Title"].ToString();
                        currentRow.ReleaseYear = (int)dataReader["ReleaseYear"];
                        currentRow.Notes = dataReader["Notes"].ToString();
                        
                    }
                    currentRow.Title = "Not Found";
                    return currentRow;
                }
            }
        }


        public List<DVD> GetByYear(int year)
        {
            List<DVD> dvds = new List<DVD>();

            using (var connection = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand command = new SqlCommand("SelectDVDByReleaseYear", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ReleaseYear", year);

                connection.Open();

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        DVD currentRow = new DVD();
                        currentRow.DvdId = (int)dataReader["DvdId"];
                        currentRow.Rating = dataReader["Rating"].ToString();
                        currentRow.DirectorName = dataReader["DirectorName"].ToString();
                        currentRow.Title = dataReader["Title"].ToString();
                        currentRow.ReleaseYear = (int)dataReader["ReleaseYear"];
                        currentRow.Notes = dataReader["Notes"].ToString();
                        dvds.Add(currentRow);

                    }
                }
            }
            return dvds;
        }

        public List<DVD> GetByDirector(string director)
        {
            List<DVD> dvds = new List<DVD>();

            using (var connection = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand command = new SqlCommand("SelectDVDByDirector", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@DirectorName", director);

                connection.Open();

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        DVD currentRow = new DVD();
                        currentRow.DvdId = (int)dataReader["DvdId"];
                        currentRow.Rating = dataReader["Rating"].ToString();
                        currentRow.DirectorName = dataReader["DirectorName"].ToString();
                        currentRow.Title = dataReader["Title"].ToString();
                        currentRow.ReleaseYear = (int)dataReader["ReleaseYear"];
                        currentRow.Notes = dataReader["Notes"].ToString();
                        dvds.Add(currentRow);

                    }
                }
            }
            return dvds;
        }

        public List<DVD> GetByRating(string rating)
        {
            List<DVD> dvds = new List<DVD>();

            using (var connection = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand command = new SqlCommand("SelectDVDByRating", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Rating", rating);

                connection.Open();

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        DVD currentRow = new DVD();
                        currentRow.DvdId = (int)dataReader["DvdId"];
                        currentRow.Rating = dataReader["Rating"].ToString();
                        currentRow.DirectorName = dataReader["DirectorName"].ToString();
                        currentRow.Title = dataReader["Title"].ToString();
                        currentRow.ReleaseYear = (int)dataReader["ReleaseYear"];
                        currentRow.Notes = dataReader["Notes"].ToString();
                        dvds.Add(currentRow);

                    }
                }
            }
            return dvds;
        }

        public List<DVD> AddDVD(DVD dvd)
        {
            

            using (var connection = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand command = new SqlCommand("AddDvd", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Title", dvd.Title);
                command.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                command.Parameters.AddWithValue("@Notes", dvd.Notes);
                command.Parameters.AddWithValue("@Rating", dvd.Rating);
                command.Parameters.AddWithValue("@DirectorName", dvd.DirectorName);

                command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
                command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;
                connection.Open();
                command.ExecuteNonQuery();
                dvd.DvdId = (int)command.Parameters["@RETURN_VALUE"].Value;


            }
            return GetAll();
        }

        public List<DVD> EditDVD(DVD original, DVD edit)
        {
            using (var connection = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand command = new SqlCommand("EditDvd", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@OriginalID", original.DvdId);
                command.Parameters.AddWithValue("@Title", edit.Title);
                command.Parameters.AddWithValue("@ReleaseYear", edit.ReleaseYear);
                command.Parameters.AddWithValue("@Notes", edit.Notes);
                command.Parameters.AddWithValue("@Rating", edit.Rating);
                command.Parameters.AddWithValue("@DirectorName", edit.DirectorName);

                command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
                command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;
                connection.Open();
                command.ExecuteNonQuery();
                edit.DvdId = (int)command.Parameters["@RETURN_VALUE"].Value;


            }
            return GetAll();

        }

        public List<DVD> DeleteDVD(int id)
        {
            using(var connection = new SqlConnection(Settings.GetConnectionString()))
            {
                var command = new SqlCommand("DeleteDvd", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@DvdId", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
            return GetAll();
        }
    }
}