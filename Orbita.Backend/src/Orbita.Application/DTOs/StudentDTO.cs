using Orbita.Model;

namespace Orbita.Application.DTOs
{
    public class StudentDTO
    {
        public int RA { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long CPF { get; set; }
        public StudentDTO()
        {

        }
        public StudentDTO(Student student)
        {
            RA = student.RA;
            Name = student.Name;
            Email = student.Email;
            CPF = student.CPF;
        }

        public Student MapToStudent()
        {
            return new Student(RA, Name, Email, CPF);
        }
    }
}
