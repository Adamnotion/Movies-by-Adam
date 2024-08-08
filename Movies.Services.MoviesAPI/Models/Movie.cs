using System.ComponentModel.DataAnnotations;

namespace Movies.Services.MovieAPI.Models
{

    public class Movie
    {
        [Key]
        public int MovieId {  get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string category {  get; set; }
        public string ImageUrl { get; set; }
    }
}
