
using Bitirme_Proje.Business.Interfaces;
using Bitirme_Proje.DataAccess.Interfaces;
using Bitirme_Proje.EntityFramework.Entities;

namespace Bitirme_Proje.Business.Classes
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByMail(string mail)
        {
            return _userDal.GetByMail(mail);
        }

        public User GetByMailAndPassword(string mail, string password)
        {
            return _userDal.GetByMailAndPassword(mail, password);
        }
    }
}
