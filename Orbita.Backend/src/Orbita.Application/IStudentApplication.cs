using Orbita.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orbita.Application
{
    public interface IStudentApplication
    {
        Task<IEnumerable<StudentDTO>> GetAllStudents();
        Task<StudentDTO> GetStudentByRA(int ra);
        Task<StudentDTO> CreateStudent(StudentDTO studentDTO);
        Task RemoveStudent(int ra);
        Task<StudentDTO> UpdateStudent(StudentDTO updateDto);
    }
}
