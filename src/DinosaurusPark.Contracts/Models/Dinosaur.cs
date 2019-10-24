﻿namespace DinosaurusPark.Contracts.Models
{
    public class Dinosaur
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Gender Gender { get; set; }

        public int Age { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public int SpeciesId { get; set; }

        public Species Species { get; set; }
    }
}