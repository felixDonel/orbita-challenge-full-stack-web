using Microsoft.AspNetCore.Mvc;
using Orbita.Application.DTOs;
using Orbita.Application;

namespace Orbita.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentApplication _studentApplication;

        public StudentController(IStudentApplication studentApplication)
        {
            _studentApplication = studentApplication;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentApplication.GetAllStudents();
            return Ok(students);
        }

        [HttpGet("{ra}")]
        public async Task<IActionResult> GetStudentByRA(int ra)
        {
            var student = await _studentApplication.GetStudentByRA(ra);
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentDTO studentDTO)
        {
            var createdStudent = await _studentApplication.CreateStudent(studentDTO);
            return CreatedAtAction("GetStudentByRA", new { RA = createdStudent.RA }, createdStudent);
        }

        [HttpDelete("{ra}")]
        public async Task<IActionResult> RemoveStudent(int ra)
        {
            await _studentApplication.RemoveStudent(ra);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent([FromBody] StudentDTO updateDto)
        {
            return Ok(await _studentApplication.UpdateStudent(updateDto));
        }
    }
}
