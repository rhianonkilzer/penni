using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace keepr.Models
{
    public class Pin
    {
        public int Id { get; set; }
        [Required]
        [MinLength(6)]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        public string UserId { get; set; }
        public string Img { get; set; }
        public int Views { get; set; }
        public int Shares { get; set; }
        public int Keeps { get; set; }

        public SqlByte IsPrivate { get; set; }


    }
}