using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentInformation.Models;

namespace StudentInformation.Data
{
    public class StudentInformationContext : DbContext
    {
        public StudentInformationContext (DbContextOptions<StudentInformationContext> options)
            : base(options)
        {
        }

        public DbSet<StudentInformation.Models.StudentInfo> StudentInfo { get; set; } = default!;
        public DbSet<StudentInformation.Models.User> TBUser { get; set; } = default!;
        
    }
}
