using Best.Core.DataAccess;
using Best.Entities.ComplexTypes;
using Best.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Best.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<UserRoleDetail> GetUserRoles(User user);//Sistemdeki kullanıcının rollerini alıyoruz.
    }
}
