using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DvdLibraryWebAPI.Models
{
    [Table("Rating")]
    public class RatingClass
    {
        [Key]
        public int RatingId { get; set; }
        public string Rating { get; set; }
    }
}