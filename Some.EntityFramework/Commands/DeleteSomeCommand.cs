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
    public class DeleteSomeCommand : IDeleteSomeCommand
    {
        private readonly SomeDbContextFactory _contextFactory;

        public DeleteSomeCommand(SomeDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Guid id)
        {
            //throw new Exception();

            using (SomeDbContext context = _contextFactory.Create())
            {
                await Task.Delay(5000);

                SomeDto someDto = new SomeDto()
                {
                    Id = id
                };

                context.Somes.Remove(someDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
