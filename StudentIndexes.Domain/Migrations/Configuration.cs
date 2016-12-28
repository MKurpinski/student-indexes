using System.Collections.Generic;
using StudentIndexes.Domain.Models;

namespace StudentIndexes.Domain.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentIndexes.Domain.StudentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "StudentIndexes.Domain.StudentContext";
        }

        protected override void Seed(StudentIndexes.Domain.StudentContext context)
        {
            context.Students.AddOrUpdate(x => x.Id,
                new StudentModel()
                {
                    Index = "112233",
                    Name = "Jan",
                    Surname = "Kowalski",
                    Grades = new List<GradeModel>()
                    {
                        new GradeModel() {NameOfCourse = "Analiza",Rating = 4.5,NumberOfEcts = 5},
                        new GradeModel(){NameOfCourse = "Teleinformatyka",Rating = 3,NumberOfEcts = 2}
                    },
                },
                new StudentModel()
                {
                    Index = "223300",
                    Name = "Maciej",
                    Surname = "Nowak",
                    Grades = new List<GradeModel>()
                    {
                        new GradeModel() {NameOfCourse = "Analiza",Rating = 2,NumberOfEcts = 5},
                        new GradeModel(){NameOfCourse = "Teleinformatyka",Rating = 5,NumberOfEcts = 2}
                    },
                },
                new StudentModel()
                {
                    Index = "223300",
                    Name = "Karol",
                    Surname = "Janik",
                    Grades = new List<GradeModel>()
                }
                );

        }
    }
}
