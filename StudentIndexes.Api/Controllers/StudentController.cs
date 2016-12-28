using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using StudentIndexes.Api.Attributes;
using StudentIndexes.Domain.DTOs;
using StudentIndexes.Domain.Models;
using StudentIndexes.Domain.Repositories.Interfaces;

namespace StudentIndexes.Api.Controllers
{
    [Authorize]
    [ValidateModelState]
    [RoutePrefix("api/Student")]
    public class StudentController : ApiController
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [HttpGet, Route("")]
        [ResponseType(typeof(IEnumerable<StudentDto>))]
        public IHttpActionResult Get()
        {
            return Ok(AutoMapper.Mapper.Map<List<StudentModel>, List<StudentDto>>(_studentRepository.GetAll()));
        }

        [HttpGet, Route("{id}", Name = "GetStudent")]
        [ResponseType(typeof(StudentDto))]
        public IHttpActionResult Get(int id)
        {
            var student = _studentRepository.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(AutoMapper.Mapper.Map<StudentModel,StudentDto>(student));
        }

        [HttpPost, Route("")]
        [ResponseType(typeof(StudentDto))]
        public IHttpActionResult Post([FromBody]StudentDto student)
        {
            var addedStudent = _studentRepository.AddStudent(AutoMapper.Mapper.Map<StudentDto,StudentModel>(student));
            return CreatedAtRoute("GetStudent",new {id=addedStudent.Id},AutoMapper.Mapper.Map<StudentModel, StudentDto> (addedStudent));
        }

        [HttpPut, Route("{id}")]
        public IHttpActionResult Put(int id, [FromBody]StudentDto student)
        {
            var dbEntry = _studentRepository.GetStudent(id);
            if (dbEntry == null)
            {
                return NotFound();
            }
            student.Id = id;
            _studentRepository.UpdateStudent(AutoMapper.Mapper.Map<StudentDto,StudentModel>(student),dbEntry);
            return Ok();
        }

        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var student = _studentRepository.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            _studentRepository.DeleteStudent(student);
            return Ok();
        }
    }
}
