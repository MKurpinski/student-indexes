using System;
using System.Collections.Generic;
using StudentIndexes.Domain.Models;

namespace StudentIndexes.Domain.Repositories.Interfaces
{
    public interface IStudentRepository:IDisposable
    {
        StudentModel AddStudent(StudentModel student);
        void DeleteStudent(StudentModel student);
        List<StudentModel> GetAll();
        StudentModel GetStudent(int id);
        void UpdateStudent(StudentModel student, StudentModel dbEntry);
    }
}
