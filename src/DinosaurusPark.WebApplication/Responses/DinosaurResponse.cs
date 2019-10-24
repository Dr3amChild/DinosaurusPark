using DinosaurusPark.Contracts.Models;

namespace DinosaurusPark.WebApplication.Responses
{
    public class DinosaurResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public string Species { get; set; }

        public string Description { get; set; }
    }
}