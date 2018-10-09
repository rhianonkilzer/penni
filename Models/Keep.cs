using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace keepr.Models
{
    public class Keep
    {
        public int Id { get; set; }
        [Required]
        [MinLength(6)]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Img { get; set; }
        public int Views { get; set; } = 0;
        public int Shares { get; set; } = 0;
        public int Keeps { get; set; } = 0;
        [Required]
        public bool IsPrivate { get; set; }


    }
}