using System;
using System.ComponentModel.DataAnnotations;

namespace DapperTest.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        
        [Required]
        [MaxLength(80)]
        public string Title { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Director { get; set; }
        public string Genre { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseYear { get; set; }
    }
}