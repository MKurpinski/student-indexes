using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using Moq;
using NUnit.Framework;
using StudentIndexes.Api;
using StudentIndexes.Api.Controllers;
using StudentIndexes.Domain.DTOs;
using StudentIndexes.Domain.Models;
using StudentIndexes.Domain.Repositories.Interfaces;

namespace StudentIndexes.Tests
{
    [TestFixture]
    public class StudentControllerTest
    {
        private readonly string DEFAULT_INDEX = "111111";
        private readonly string DEFAULT_NAME = "Maciej";
        private readonly string DEFAULT_SURNAME = "Kowalski";
        private readonly int DEFAULT_GRADES_LENGTH = 2;
        private readonly int DEFAULT_ID = 1;

        [OneTimeSetUp]
        public void SetUp()
        {
            AutomapperConfiguration.Configure();
        }
        [Test]
        public void GetShouldReturnAllStudents()
        {
            // Arrange
            var mockRepository = new Mock<IStudentRepository>();
            mockRepository.Setup(x => x.GetAll())
                .Returns(new List<StudentModel> { new StudentModel {Id = 1,Index = "111111",Name = "Jan",Surname = "Kowalski", Grades = new List<GradeModel>()},
                    new StudentModel { Id = 2, Index = "222222", Name = "Maciej", Surname = "Nowak", Grades = new List<GradeModel>() } });

            var controller = new StudentController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<List<StudentDto>>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(2, contentResult.Content.Count());
        }

        [Test]
        public void GetWithIdParameterShouldReturnStudentDtoWithGradesIfStudentExists()
        {
            // Arrange
            var mockRepository = new Mock<IStudentRepository>();
            mockRepository.Setup(x => x.GetStudent(It.IsAny<int>()))
                .Returns(FakeUser());

            var controller = new StudentController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.Get(DEFAULT_ID);
            var contentResult = actionResult as OkNegotiatedContentResult<StudentDto>;


            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(DEFAULT_GRADES_LENGTH, contentResult.Content.Grades.Count());
            Assert.AreEqual(2, contentResult.Content.Grades.Count());
            Assert.AreEqual(DEFAULT_INDEX, contentResult.Content.Index);
        }

        [Test]
        public void GetWithIdParameterShouldReturnNotFoundIfUserDoesntExist()
        {
            // Arrange
            var mockRepository = new Mock<IStudentRepository>();
            var controller = new StudentController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.Get(DEFAULT_ID);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(actionResult);
        }

        [Test]
        public void DeleteShouldReturnOkWhenSucceded()
        {
            // Arrange
            var mockRepository = new Mock<IStudentRepository>();
            mockRepository.Setup(x => x.GetStudent(It.IsAny<int>()))
                .Returns(FakeUser());

            var controller = new StudentController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.Delete(DEFAULT_ID);
            var contentResult = actionResult as OkNegotiatedContentResult<StudentDto>;

            // Assert
            Assert.IsInstanceOf<OkResult>(actionResult);
        }

        [Test]
        public void DeleteShouldReturnNotFoundWhenUserDoesntExist()
        {
            // Arrange
            var mockRepository = new Mock<IStudentRepository>();
            var controller = new StudentController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.Delete(DEFAULT_ID);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(actionResult);
        }

        [Test]
        public void PostShouldReturnAddedStudent()
        {
            // Arrange
            var user = FakeUser();
            var mockRepository = new Mock<IStudentRepository>();
            mockRepository.Setup(x => x.AddStudent(It.IsAny<StudentModel>()))
                .Returns(user);

            var controller = new StudentController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.Post(FakeUserDto());
            var contentResult = actionResult as CreatedAtRouteNegotiatedContentResult<StudentDto>;


            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(DEFAULT_GRADES_LENGTH, contentResult.Content.Grades.Count());
            Assert.AreEqual(2, contentResult.Content.Grades.Count());
            Assert.AreEqual(DEFAULT_INDEX, contentResult.Content.Index);
        }

        [Test]
        public void PutShouldReturnNotFoundIfUserDoesntExist()
        {
            // Arrange
            var mockRepository = new Mock<IStudentRepository>();
            var controller = new StudentController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.Put(DEFAULT_ID,FakeUserDto());

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(actionResult);
        }

        [Test]
        public void PutShouldReturnOkIfSucceded()
        {
            // Arrange
            var mockRepository = new Mock<IStudentRepository>();
            mockRepository.Setup(x => x.GetStudent(It.IsAny<int>()))
                .Returns(FakeUser());

            var controller = new StudentController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.Put(DEFAULT_ID,FakeUserDto());
            var contentResult = actionResult as OkNegotiatedContentResult<StudentDto>;

            // Assert
            Assert.IsInstanceOf<OkResult>(actionResult);
        }

        private StudentModel FakeUser()
        {
            return new StudentModel()
            {
                Index = DEFAULT_INDEX,
                Name = DEFAULT_NAME,
                Surname = DEFAULT_SURNAME,
                Id = 1,
                Grades = new List<GradeModel>() {new GradeModel(), new GradeModel()}
            };
        }

        private StudentDto FakeUserDto()
        {
            return new StudentDto()
            {
                Index = DEFAULT_INDEX,
                Name = DEFAULT_NAME,
                Surname = DEFAULT_SURNAME,
                Id = 1,
                Grades = new List<GradeDto>() { new GradeDto(), new GradeDto() }
            };
        }
    }
}
