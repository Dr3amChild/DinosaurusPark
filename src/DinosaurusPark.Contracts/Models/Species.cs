namespace DinosaurusPark.Contracts.Models
{
    public class Species
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public FoodType FoodType { get; set; }

        public string Description { get; set; }
    }
}
