using AspWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly WebApicrudContext context;

        public StudentAPIController(WebApicrudContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentTbl>>> GetStudents()
        {
            var data =await context.StudentTbls.ToListAsync();
            return Ok(data);
        }
    }
}
