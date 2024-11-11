using Microsoft.EntityFrameworkCore;
using Somes.Domain.Models;
using Somes.Domain.Queries;
using Somes.EntityFramework.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somes.EntityFramework.Queries
{
    public class GetAllSomeQuery : IGetAllSomeQuery
    {
        private readonly SomeDbContextFactory _contextFactory;

        public GetAllSomeQuery(SomeDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task<IEnumerable<Some>> Execute()
        {
            //throw new Exception();

            using(SomeDbContext context = _contextFactory.Create())            
            {
                IEnumerable<SomeDto>  someDtos = await context.Somes.ToListAsync();

                return someDtos.Select(y => new Some(y.Id, y.Username, y.IsSubscribed, y.IsMember));
            }
                
        }
    }
}
