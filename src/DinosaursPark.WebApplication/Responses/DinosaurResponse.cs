namespace DinosaursPark.WebApplication.Responses
{
    public class DinosaurResponse : SimpleDinosaurResponse
    {
        public string Gender { get; set; }

        public int Age { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public string FoodType { get; set; }

        public string Description { get; set; }
    }
}