using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DvdLibraryWebAPI.Models
{
    [Table("DVDEF")]
    public class DVDEF
    {
        [Key]
        public int DvdId { get; set; }
        public int RatingId { get; set; }
        public int DirectorId { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Notes { get; set; }

        public virtual Director Director { get; set; }
        public virtual RatingClass Rating { get; set; }
    }
}