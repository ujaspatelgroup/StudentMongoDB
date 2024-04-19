using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentCRUDMongoDB.Models;
using StudentCRUDMongoDB.Services.Student;

namespace StudentCRUDMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await _studentService.GetStudentsListAsync();

            if (students == null)
            {
                return NotFound();
            }

            return Ok(students);
        }

        // GET: api/Students/5ac
        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            var student = await _studentService.GetStudentAsync(id);
            if (student is null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // PUT: api/Students/5ac
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Put(string id, Students student)
        {
            var existingStudent = await _studentService.GetStudentAsync(id);
            if (existingStudent is null)
            {
                return BadRequest();
            }

            await _studentService.UpdateStudentAsync(student);

            return NoContent();
        }

        // POST: api/Students
        [HttpPost]
        public async Task<IActionResult> Post(Students student)
        {
            await _studentService.InsertStudentAsync(student);

            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }

        // DELETE: api/Students/5ac
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existingStudent = await _studentService.GetStudentAsync(id);
            if (existingStudent is null)
            {
                return NotFound();
            }

            await _studentService.DeleteStudentAsync(id);
            return NoContent();
        }

    }
}
