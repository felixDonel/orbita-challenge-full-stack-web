using FluentValidation;

namespace Orbita.Model
{
    public class Student
    {
        private readonly IValidator<Student> _validator;
        public int RA { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public int CPF { get; private set; }
        public Student()
        {
            _validator = new StudentValidator();
        }

        public Student(int ra, string name, string email, int cpf) : this()
        {
            RA = ra;
            Name = name;
            Email = email;
            CPF = cpf;
            _validator.ValidateAndThrow(this);
        }

        public void ChangeName(string newName)
        {
            Name = newName;
            _validator.ValidateAndThrow(this);
        }

        public void ChangeEmail(string newEmail)
        {
            Email = newEmail;
            _validator.ValidateAndThrow(this);
        }
    }
}
