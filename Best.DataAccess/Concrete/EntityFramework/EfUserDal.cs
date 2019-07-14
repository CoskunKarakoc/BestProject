using Best.Core.DataAccess.EntityFramework;
using Best.DataAccess.Abstract;
using Best.Entities.ComplexTypes;
using Best.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Best.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<UserRoleDetail> GetUserRoles(User user)//Sistemdeki kullanıcının rollerini complextype'a liste şeklinde bütün roollerini atadık
        {
            using (var context=new NorthwindContext())
            {
                var result = from ur in context.UserRoles
                           join r in context.Roles on ur.RoleId equals r.Id
                           where ur.UserId==user.Id
                           select new UserRoleDetail
                           {
                               RoleName = r.Name
                           };
                return result.ToList();
            }
        }
    }
}
