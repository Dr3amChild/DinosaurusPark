using Microsoft.AspNetCore.Mvc;

namespace DinosaursPark.WebApplication.Requests
{
    public class GetByIdRequest
    {
        [FromQuery]
        public int Id { get; set; }
    }
}
