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
            var data = await context.StudentTbls.ToListAsync();
            return Ok(data);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<StudentTbl>> GetStudent(int id)
        {
            var student = await context.StudentTbls.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<StudentTbl>> CreateStudent(StudentTbl student)
        {
            context.StudentTbls.Add(student);
            await context.SaveChangesAsync();
            return Ok(student);
            //return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<StudentTbl>> UpdateStudent(int Id,StudentTbl student)
        {
           if(Id != student.Id)
            {
                return BadRequest();
            }
           context.Entry(student).State = EntityState.Modified;
           
           await context.SaveChangesAsync();
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            var student = await context.StudentTbls.FindAsync(id);
            if(student == null)
            {
                return NotFound();
            }
            context.StudentTbls.Remove(student);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
