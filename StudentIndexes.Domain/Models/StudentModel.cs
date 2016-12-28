using System.Collections.Generic;

namespace StudentIndexes.Domain.Models
{
    public class StudentModel:ModelBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Index { get; set; }
        public IList<GradeModel> Grades { get; set; }
    }
}
