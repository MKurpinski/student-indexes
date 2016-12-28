using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using StudentIndexes.Domain.Models;

namespace StudentIndexes.Domain
{
    public class StudentContext : IdentityDbContext<IdentityUser>
    {
        public StudentContext()
            : base("StudentContext") { }
        public IDbSet<StudentModel> Students { get; set; }
    }
}
