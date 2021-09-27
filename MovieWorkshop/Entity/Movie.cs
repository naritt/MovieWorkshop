using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MovieWorkshop.Entity
{
    public partial class Movie
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please provide Name")]
        public string Name { get; set; }
        public int TypeId { get; set; }
        [Required(ErrorMessage = "Please provide Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please provide ImageUrl")]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Please provide TrailerUrl")]
        public string TrailerUrl { get; set; }

        public virtual MovieType Type { get; set; }
    }
}
