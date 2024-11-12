using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Somes.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfDataGridToSql02.HostBuilders
{
    public static class AddDbContextHostBuilderExtensions
    {
        public static IHostBuilder AddDbContext(this IHostBuilder hostBuilder)
        {

            hostBuilder.ConfigureServices((context, services) =>
            { 
                string connectionString = context.Configuration.GetConnectionString("sqlServer");

                services.AddSingleton<DbContextOptions>(new DbContextOptionsBuilder()
                    .UseSqlServer(connectionString).Options);
                services.AddSingleton<SomeDbContextFactory>();
            });

            return hostBuilder;
        }
    }
}
