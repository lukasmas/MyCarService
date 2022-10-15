﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCarService.Models.DatabaseModels
{
    [Table("Vehicle")]
    public class Vehicle
    {
        public long Id { get; set; }
        [Required]
        public long OwnerId { get; set; }
        [Required]
        public long ModelId { get; set; }
        [Range(1940,2022)]
        [Required]
        public int ProductionYear { get; set; }
        [MinLength(17)]
        [MaxLength(17)]
        public string? VIN { get; set; }
        public string? Plate { get; set; }
        [Required]
        public uint CurrentMillage { get; set; }
    }
}
