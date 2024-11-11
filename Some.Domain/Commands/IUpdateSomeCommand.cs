using Somes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somes.Domain.Commands
{
    public interface IUpdateSomeCommand
    {
        Task Execute(Some some);
    }
}
