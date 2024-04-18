﻿using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Meeting
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public string DocumentURL { get; set; }
    }
}
