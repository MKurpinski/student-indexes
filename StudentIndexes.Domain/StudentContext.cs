using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using StudentIndexes.Domain.Models;

namespace StudentIndexes.Domain
{
    public class StudentContext : IdentityDbContext<IdentityUser>
    {
        public StudentContext()
            : base("StudentContext", throwIfV1Schema: false) { }
        public IDbSet<StudentModel> Students { get; set; }
        public IDbSet<GradeModel> Grades { get; set; }
    }
}
