//using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Somes.Domain.Models;

namespace WpfDataGridToSql02.Interfaces
{
    public interface IUserRepository
    {
        public User? GetById(int? id);
    }
}
