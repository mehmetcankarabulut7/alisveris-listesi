
using Bitirme_Proje.EntityFramework.Entities;

namespace Bitirme_Proje.Business.Interfaces
{
    public interface IUserService
    {
        public User GetByMailAndPassword(string mail, string password);
        public User GetByMail(string mail);
        public void Add(User user);
    }
}
