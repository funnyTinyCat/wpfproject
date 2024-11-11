using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somes.EntityFramework
{
    public class SomeDbContextFactory
    {
        private readonly string _connectionString;
        private readonly DbContextOptions _options;

        public SomeDbContextFactory(DbContextOptions options)
        {
            _options = options;
        }
        public SomeDbContext Create()
        {
            return new SomeDbContext(_options);
        }

    }
}
