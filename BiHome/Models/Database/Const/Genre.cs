﻿using System.ComponentModel.DataAnnotations;

namespace BiHome.Models.Database.Product
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
    }
}
