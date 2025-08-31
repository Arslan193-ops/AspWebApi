using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportsController : ControllerBase
    {
        public List<string> sports = new List<string>
        {
            "Soccer",
            "Basketball",
            "Baseball",
            "Tennis",
            "Cricket"
        };

        [HttpGet]
        public List<string> GetSports()
        {
            return sports;
        }

        [HttpGet("{Id}")]
        public string GetSportsbyId(int Id)
        {
            return sports.ElementAt(Id);
        }
    }
}
