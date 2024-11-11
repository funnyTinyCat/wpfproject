using Microsoft.EntityFrameworkCore;
using Somes.Domain.Commands;
using Somes.Domain.Models;
using Somes.EntityFramework.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somes.EntityFramework.Commands
{
    public class CreateSomeCommand : ICreateSomeCommand
    {
        private readonly SomeDbContextFactory _contextFactory;

        public CreateSomeCommand(SomeDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Some some)
        {
            //throw new Exception();

            using (SomeDbContext context = _contextFactory.Create())
            {
                

                SomeDto someDto = new SomeDto()
                {
                    Id = some.Id,
                    Username = some.Username,
                    IsSubscribed = some.IsSubscribed,
                    IsMember = some.IsMember
                };

                context.Somes.Add(someDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
