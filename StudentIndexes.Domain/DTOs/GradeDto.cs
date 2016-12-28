using System.ComponentModel.DataAnnotations;

namespace StudentIndexes.Domain.DTOs
{
    public class GradeDto:DtoBase
    {
        [Required]
        public string NameOfCourse { get; set; }
        [Required]
        [Range(2.0,5.5,ErrorMessage = "Incorrect value of rating")]
        public double Rating { get; set; }
        [Required]
        [Range(0,30,ErrorMessage = "Incorrect number of ECTS")]
        public double NumberOfEcts { get; set; }
    }
}
