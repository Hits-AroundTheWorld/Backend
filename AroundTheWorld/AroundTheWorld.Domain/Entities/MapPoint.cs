﻿using System.ComponentModel.DataAnnotations;

namespace AroundTheWorld.Domain.Entities
{
    public class MapPoint
    {
        [Key]       
        public Guid pointId { get; set; }
        public Double XCoordinate { get; set; }
        public Double YCoordinate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
