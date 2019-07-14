using Best.BusinessLayer.Abstract;
using Best.DataAccess.Abstract;
using Best.Entities.ComplexTypes;
using Best.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Best.BusinessLayer.Concrete.Managers
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User GetByUserNameAndPassword(string userName, string password)
        {
            return _userDal.Get(u => u.UserName == userName && u.Password == password);
        }

        public List<UserRoleDetail> GetUserRoles(User user)
        {
            return _userDal.GetUserRoles(user);
        }
    }
}
