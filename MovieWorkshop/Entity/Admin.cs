using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MovieWorkshop.Entity
{
    public partial class Admin
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please provide username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please provide password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
