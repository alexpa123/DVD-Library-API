using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DvdLibraryWebAPI.Models
{
    public class DVDModel
    {
        [Key]
        public int DvdId { get; set; }
        public int RatingId { get; set; }
        public int DirectorId { get; set; }
        public string Rating { get; set; }
        public string DirectorName { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Notes { get; set; }

    }
}