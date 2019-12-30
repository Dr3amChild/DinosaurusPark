using Microsoft.AspNetCore.Mvc;

namespace DinosaursPark.WebApplication.Requests
{
    public class PagingRequest
    {
        [FromQuery]
        public int PageNumber { get; set; }

        [FromQuery]
        public int PageSize { get; set; }
    }
}
