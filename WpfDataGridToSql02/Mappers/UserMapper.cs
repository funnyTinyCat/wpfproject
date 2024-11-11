using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDataGridToSql02.Dtos;
using WpfDataGridToSql02.Migrations.ApplicationDb;
using Somes.Domain.Models;

namespace WpfDataGridToSql02.Mappers
{
    public static class UserMapper
    {

        public static UserForDataGridDto ToUserForDataGrid(this User userModel, string createdBy, string modifiedBy)
        {

            return new UserForDataGridDto
            {
                UserId = userModel.UserId,
                UserName = userModel.Username,
                CreatedDate = userModel.CreatedDate,
                CreatedBy = createdBy,
                ModifiedBy = modifiedBy
            };
        }
    }
}
