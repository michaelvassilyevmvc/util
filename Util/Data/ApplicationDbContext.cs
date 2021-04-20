using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Core.Models;
using Util.Data.Entities;

namespace Util.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Firm> Firms { get; set; }
    }
}
