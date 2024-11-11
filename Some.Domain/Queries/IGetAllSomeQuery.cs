using Somes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somes.Domain.Queries
{
    public interface IGetAllSomeQuery
    {
        Task<IEnumerable<Some>> Execute();
    }
}
