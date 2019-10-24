namespace DinosaurusPark.Contracts.Models
{
    public class Dinosaur
    {
        public Dinosaur()
        {
        }

        public Dinosaur(Dinosaur dinosaur)
        {
            Id = dinosaur.Id;
            Name = dinosaur.Name;
            Image = dinosaur.Image;
            Species = new Species
            {
                Id = dinosaur.SpeciesId,
                Name = dinosaur.Species.Name,
            };
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public Gender Gender { get; set; }

        public int Age { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public string Image { get; set; }

        public int SpeciesId { get; set; }

        public Species Species { get; set; }
    }
}