using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using StudentIndexes.Domain.Models;
using StudentIndexes.Domain.Repositories.Interfaces;

namespace StudentIndexes.Domain.Repositories
{
    public class StudentRepository:IStudentRepository
    {
        private readonly StudentContext _context;

        public StudentRepository()
        {
            _context = new StudentContext();
        }

        public StudentModel AddStudent(StudentModel student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }

        public void DeleteStudent(StudentModel student)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
        }

        public List<StudentModel> GetAll()
        {
            return _context.Students.Include(x=>x.Grades).AsNoTracking().ToList();
        }

        public StudentModel GetStudent(int id)
        {
            return _context.Students.Include(x => x.Grades).FirstOrDefault(x => x.Id == id);
        }

        public void UpdateStudent(StudentModel student,StudentModel dbEntry)
        {
            dbEntry.Index = student.Index;
            dbEntry.Name = student.Name;
            dbEntry.Surname = student.Surname;
            for (var index = 0; index < dbEntry.Grades.Count; index++)
            {
                _context.Grades.Remove(dbEntry.Grades[index]);
            }
            dbEntry.Grades = student.Grades;
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
