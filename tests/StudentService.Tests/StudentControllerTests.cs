using Microsoft.AspNetCore.Mvc;
using Moq;
using StudentService.BLL.Interfaces;
using StudentService.DAL.Models;
using StudentService.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StudentService.Tests
{
    public class StudentControllerTests
    {
        [Fact]
        public void GetReturnsStudents()
        {
            // Arrange
            var mock = new Mock<IStudentManager>();
            mock.Setup(manager => manager.GetStudents()).Returns(GetTestStudents());
            StudentController controller = new StudentController(mock.Object);

            // Act
            var result = controller.GetStudents();

            // Assert
            var model = Assert.IsAssignableFrom<IEnumerable<Student>>(
                result);
            Assert.Equal(GetTestStudents().ToList().Count, model.ToList().Count);
        }

        [Fact]
        public void PostAddTestStudent()
        {
            // Arrange
            var mock = new Mock<IStudentManager>();
            var controller = new StudentController(mock.Object);
            var student = new Student { Id = 1, Name = "Tom", DateOfBirth = new DateTime(1980, 10, 5), Email = "tom@gmail.com" };

            // Act
            var result = controller.AddStudent(student);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(student, okObjectResult?.Value);
        }

        [Fact]
        public void PostAddNotValidTestStudent()
        {
            // Arrange
            var mock = new Mock<IStudentManager>();
            var controller = new StudentController(mock.Object);
            controller.ModelState.AddModelError("Name", "Required");
            var student = new Student { DateOfBirth = new DateTime(1980, 10, 5), Email = "tom@gmail.com" };

            // Act
            var result = controller.AddStudent(student);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void DeleteTestStudent()
        {
            // Arrange
            int testStudentId = 1;
            var mock = new Mock<IStudentManager>();
            var controller = new StudentController(mock.Object);
            mock.Setup(manager => manager.DeleteStudent(testStudentId))
                .Returns(GetTestStudents().FirstOrDefault(s => s.Id == testStudentId));

            // Act
            var result = controller.DeleteStudent(testStudentId);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<Student>(okObjectResult?.Value);
            Assert.Equal(1, model.Id);
            Assert.Equal("Tom", model.Name);
            Assert.Equal(new DateTime(1980, 10, 5), model.DateOfBirth);
            Assert.Equal("tom@gmail.com", model.Email);
        }

        private IEnumerable<Student> GetTestStudents()
        {
            var students = new List<Student>
            {
                new Student { Id=1, Name="Tom", DateOfBirth = new DateTime(1980, 10, 5), Email = "tom@gmail.com"},
                new Student { Id=2, Name="Bob", DateOfBirth = new DateTime(1990, 10, 5), Email = "bob@gmail.com"},
                new Student { Id=3, Name="Sam", DateOfBirth = new DateTime(1996, 10, 5), Email = "sam@gmail.com"}
            };
            return students;
        }
    }
}
