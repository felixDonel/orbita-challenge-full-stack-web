using Microsoft.AspNetCore.Mvc;
using Orbita.Application.DTOs;
using Orbita.Application;
using Orbita.Model.Exceptions;
using FluentValidation;

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
            try
            {
                var students = await _studentApplication.GetAllStudents();
                return Ok(students);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet("{ra}")]
        public async Task<IActionResult> GetStudentByRA(int ra)
        {
            try
            {
                var student = await _studentApplication.GetStudentByRA(ra);
                return Ok(student);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentDTO studentDTO)
        {
            try
            {
                var createdStudent = await _studentApplication.CreateStudent(studentDTO);
                return CreatedAtAction("GetStudentByRA", new { RA = createdStudent.RA }, createdStudent);
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        [HttpDelete("{ra}")]
        public async Task<IActionResult> RemoveStudent(int ra)
        {
            try
            {
                await _studentApplication.RemoveStudent(ra);
                return NoContent();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent([FromBody] StudentDTO updateDto)
        {
            try
            {
                return Ok(await _studentApplication.UpdateStudent(updateDto));
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
