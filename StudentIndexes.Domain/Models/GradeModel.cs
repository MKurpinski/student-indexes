namespace StudentIndexes.Domain.Models
{
    public class GradeModel:ModelBase
    {
        public string NameOfCourse { get; set; }
        public double Rating { get; set; }
        public double NumberOfEcts { get; set; }
    }
}
