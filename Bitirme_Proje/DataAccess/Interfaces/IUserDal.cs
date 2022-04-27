using Bitirme_Proje.EntityFramework.Entities;
using System.Collections.Generic;

namespace Bitirme_Proje.DataAccess.Interfaces
{
    public interface IUserDal
    {
        public User GetByMailAndPassword(string mail, string password);
        public User GetByMail(string mail);
        public void Add(User user);
    }
}
