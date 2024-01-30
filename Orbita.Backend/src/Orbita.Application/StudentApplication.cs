using Orbita.Application.DTOs;
using Orbita.Model.Interfaces;

namespace Orbita.Application
{
    public class StudentApplication : IStudentApplication
    {
        private readonly IStudentRepository _studentRepository;

        public StudentApplication(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<StudentDTO>> GetAllStudents()
        {
            var students = await _studentRepository.GetAll();
            return students.Select(student => new StudentDTO(student));
        }

        public async Task<StudentDTO> GetStudentByRA(int ra)
        {
            var student = await _studentRepository.GetById(ra);
            if (student == null)
            {
                throw new Exception("Estudante não encontrado");
            }
            return new StudentDTO(student);
        }

        public async Task<StudentDTO> CreateStudent(StudentDTO studentDTO)
        {
            var student = studentDTO.MapToStudent();
            return new StudentDTO(await _studentRepository.Add(student)); ;
        }

        public async Task RemoveStudent(int ra)
        {
            var student = await _studentRepository.GetById(ra);

            if (student == null)
            {
                throw new Exception("Estudante não encontrado");
            }

            await _studentRepository.Delete(student);
        }

        public async Task<StudentDTO> UpdateStudent(StudentDTO updateDto)
        {
            var student = await _studentRepository.GetById(updateDto.RA);

            if (student == null)
            {
                throw new Exception("Estudante não encontrado");
            }

            student.ChangeName(updateDto.Name);
            student.ChangeEmail(updateDto.Email);

            await _studentRepository.Update(student);

            return new StudentDTO(student);
        }
    }
}
