using Microsoft.EntityFrameworkCore;
using Somes.EntityFramework.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somes.EntityFramework
{
    public class SomeDbContext : DbContext
    {
        public SomeDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<SomeDto> Somes { get; set; }
    }
}
