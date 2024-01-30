using FluentValidation;
using FluentValidation.TestHelper;
using Orbita.Model;
using Xunit;

namespace Orbita.Tests
{
    public class StudentTests
    {
        [Fact]
        public void ChangeName_InvalidName_ThrowsValidationException()
        {
            var student = HelperTest.StudentValid();

            Assert.Throws<ValidationException>(() => student.ChangeName(""));
        }

        [Fact]
        public void ChangeEmail_InvalidEmail_ThrowsValidationException()
        {
            var student = HelperTest.StudentValid();
            Assert.Throws<ValidationException>(() => student.ChangeEmail("emailInvalido"));
        }

        [Fact]
        public void student_InvalidCPF_ThrowsValidationException()
        {
            Assert.Throws<ValidationException>(() => HelperTest.StudentCPFInvalid());
        }

        [Fact]
        public void student_InvalidEmail_ThrowsValidationException()
        {
            Assert.Throws<ValidationException>(() => HelperTest.StudentEmailInvalid());
        }

        [Fact]
        public void student_InvalidName_ThrowsValidationException()
        {
            Assert.Throws<ValidationException>(() => HelperTest.StudentNameInvalid());
        }
    }
}
