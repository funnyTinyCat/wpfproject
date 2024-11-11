// using Microsoft.VisualBasic.ApplicationServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Somes.Domain.Models;
using WpfDataGridToSql02.Data;
using WpfDataGridToSql02.Interfaces;

namespace WpfDataGridToSql02.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {  
        
            _context = context; 
        }    

        
        public User? GetById(int? id)
        {
            var existingUser = _context.User.FirstOrDefault(s => s.UserId == id);

            if (existingUser == null)
            {

                return null;
            }

            return existingUser;
        }
    }
}
