using Microsoft.AspNetCore.Mvc;

namespace DinosaurusPark.WebApplication.Requests
{
    public class GetAllRequest
    {
        [FromQuery]
        public int Count { get; set; }

        [FromQuery]
        public int Offset { get; set; }
    }
}
