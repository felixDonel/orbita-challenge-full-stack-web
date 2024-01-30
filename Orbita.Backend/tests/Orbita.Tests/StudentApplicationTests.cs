using Moq;
using Orbita.Model.Interfaces;
using Orbita.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Orbita.Application;

namespace Orbita.Tests
{
    public class StudentApplicationTests
    {
        [Fact]
        public async Task RemoveStudent_StudentExists_StudentRemovedSuccessfully()
        {
            // Arrange
            int studentRA = HelperTest.StudentValid().RA;

            var mockStudentRepository = new Mock<IStudentRepository>();
            var studentService = new StudentApplication(mockStudentRepository.Object);

            var existingStudent = HelperTest.StudentValid();
            mockStudentRepository.Setup(repo => repo.GetById(studentRA)).ReturnsAsync(existingStudent);

            // Act
            await studentService.RemoveStudent(studentRA);

            // Assert
            mockStudentRepository.Verify(repo => repo.Delete(existingStudent), Times.Once);
        }

        [Fact]
        public async Task RemoveStudent_StudentNotFound_ExceptionThrown()
        {
            // Arrange
            int nonExistingStudentRA = 0;

            var mockStudentRepository = new Mock<IStudentRepository>();
            var studentService = new StudentApplication(mockStudentRepository.Object);

            mockStudentRepository.Setup(repository => repository.GetById(nonExistingStudentRA)).ReturnsAsync((Student)null);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => studentService.RemoveStudent(nonExistingStudentRA));
        }
    }
}
