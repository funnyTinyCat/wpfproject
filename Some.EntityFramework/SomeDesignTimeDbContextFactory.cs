using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somes.EntityFramework
{
    public class SomeDesignTimeDbContextFactory : IDesignTimeDbContextFactory<SomeDbContext>
    {


        public SomeDbContext CreateDbContext(string[] args = null)
        {
            return new SomeDbContext(
                new DbContextOptionsBuilder()
                .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Zadatak;").Options);
        }

    }
}
