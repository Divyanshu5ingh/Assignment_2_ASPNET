using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignments_2.Models;

namespace Assignments_2.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext (DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Assignments_2.Models.Employees> Employees { get; set; } = default!;

        public DbSet<Assignments_2.Models.Departments> Departments { get; set; }
    }
}
