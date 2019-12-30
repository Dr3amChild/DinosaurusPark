using Microsoft.AspNetCore.Mvc;

namespace DinosaursPark.WebApplication.Requests
{
    public class GenerationRequest
    {
        [FromBody]
        public Body Data { get; set; }

        public class Body
        {
            public int SpeciesCount { get; set; }

            public int DinosaursCount { get; set; }
        }
    }
}
