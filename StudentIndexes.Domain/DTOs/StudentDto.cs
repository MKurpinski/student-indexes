using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentIndexes.Domain.DTOs
{
    public class StudentDto:DtoBase
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [StringLength(6,MinimumLength = 6)]
        public string Index { get; set; }
        public IList<GradeDto> Grades { get; set; }
    }
}
