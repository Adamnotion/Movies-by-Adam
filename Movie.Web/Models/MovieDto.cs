﻿using System.ComponentModel.DataAnnotations;

namespace Movie.Web.Models
{
    public class MovieDto
    {
        
        public int MovieId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price {  get; set; }
        public string category { get; set; }
        public string ImageUrl { get; set; }
    }
}
