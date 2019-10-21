using Microsoft.AspNetCore.Mvc;

namespace DinosaurusPark.WebApplication.Requests
{
    public class GetByIdRequest
    {
        [FromQuery]
        public int Id { get; set; }
    }
}
