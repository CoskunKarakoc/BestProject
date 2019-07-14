using Best.Entities.ComplexTypes;
using Best.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Best.BusinessLayer.Abstract
{
    public interface IUserService
    {
        User GetByUserNameAndPassword(string userName, string password);
        List<UserRoleDetail> GetUserRoles(User user);
    }
}
