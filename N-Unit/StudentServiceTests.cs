using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;


namespace Nunit_testing
{
    [TestFixture]
    public class StudentServiceTests
    {
        private Mock<IStudentRepository> _mockRepo;
        private StudentService _service;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IStudentRepository>();
            _service = new StudentService(_mockRepo.Object);
        }

        [Test]
        public void GetAllStudents_ReturnsAll()
        {
            var list = new List<Student> {
            new Student { RollNo = 1, Name = "John", Email = "john@example.com" }
        };
            _mockRepo.Setup(r => r.GetAll()).Returns(list);

            var result = _service.GetAllStudents();

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Name, Is.EqualTo("John"));

        }

        [Test]
        public void AddStudent_CallsRepositoryAdd()
        {
            var student = new Student { RollNo = 2, Name = "Alice", Email = "alice@example.com" };

            _service.AddStudent(student);

            _mockRepo.Verify(r => r.Add(student), Times.Once);
        }

        [Test]
        public void DeleteStudent_CallsRepositoryDelete()
        {
            _service.DeleteStudent(1);
            _mockRepo.Verify(r => r.Delete(1), Times.Once);
        }

        [Test]
        public void UpdateStudent_CallsRepositoryUpdate()
        {
            var student = new Student { RollNo = 3, Name = "Bob", Email = "bob@example.com" };

            _service.UpdateStudent(student);

            _mockRepo.Verify(r => r.Update(student), Times.Once);
        }

        [Test]
        public void GetStudentByRollNo_ReturnsCorrectStudent()
        {
            var student = new Student { RollNo = 5, Name = "Eva", Email = "eva@example.com" };
            _mockRepo.Setup(r => r.GetByRollNo(5)).Returns(student);

            var result = _service.GetStudentByRollNo(5);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo("Eva"));

        }
    }


}
